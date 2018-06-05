using Callboard.App.Data.DataContext.Main;
using Callboard.App.Data.DbContext.Main;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data.Ad;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class AdDbContext : EntityDbContext<Ad>, IAdContext
    {
        public AdDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker) 
            : base(context, logger, checker) { }

        public void Delete(int id)
        {
            string procedureName = "sp_delete_ad";
            var values = new Dictionary<string, object>
            {
                { "AdId", id }
            };
            base.Delete(procedureName, values);
        }

        public IReadOnlyCollection<Ad> GetAdsByCategoryId(int categoryId)
        {
            string procedureName = "sp_select_ad_by_categoryid";
            var values = new Dictionary<string, object>
            {
                { "CategoryId", categoryId }
            };
            var mapper = new Mapper<DataSet, Ad> { MapCollection = MapAdCollection };
            var ads = base.GetAll(procedureName, mapper, values);
            return ads;
        }

        public IReadOnlyCollection<Ad> GetAll()
        {
            var procedureName = "sp_select_ad";
            var mapper = new Mapper<DataSet, Ad> { MapCollection = MapAdCollection };
            var ads = base.GetAll(procedureName, mapper);
            return ads;
        }

        public IReadOnlyCollection<Ad> SearchByName(string name)
        {
            var procedureName = "sp_search_ad_by_name";
            var mapper = new Mapper<DataSet, Ad> { MapCollection = MapAdCollection };
            var values = new Dictionary<string, object>
            {
                { "SearchName", name }
            };
            var ads = base.GetAll(procedureName, mapper, values);
            return ads;
        }

        public IReadOnlyCollection<Ad> Search(SearchConfiguration searchConfiguration)
        {
            string procedureName = "sp_search_ad";
            var mapper = new Mapper<DataSet, Ad> { MapCollection = MapAdCollection };
            var values = new Dictionary<string, object>
            {
                { "Name", searchConfiguration.Name },
                { "State", searchConfiguration.State },
                { "Kind", searchConfiguration.Kind },
                { "CountryId", searchConfiguration.CoutryId },
                { "AreaId", searchConfiguration.AreaId },
                { "CityId", searchConfiguration.CityId },
                { "MinPrice", searchConfiguration.MinPrice },
                { "MaxPrice", searchConfiguration.MaxPrice }
            };
            var ads = base.GetAll(procedureName, mapper, values);
            return ads;
        }

        private IReadOnlyCollection<Ad> MapAdCollection(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(ad =>
            {
                Ad newAd = null;
                try
                {
                    newAd = this.MapAd(ad, dataSet.Tables[1], dataSet.Tables[2]);
                }
                catch (InvalidCastException ex)
                {
                    _logger.InfoFormat($"Cannot map Ad.\n{ ex.Message }");
                }
                return newAd;
            }).Where(x => x != null).ToList();
        }

        private Ad MapAd(DataRow row, DataTable categories, DataTable images)
        {
            int adId = row.Field<int>("AdId");
            return new Ad
            {
                AdId = adId,
                Kind = row.Field<string>("Kind"),
                State = row.Field<string>("State"),
                Name = row.Field<string>("Name"),
                Price = row.Field<decimal>("Price"),
                CreationDate = row.Field<DateTime>("CreationDate"),
                Location = new Location
                {
                    LocationId = row.Field<int>("LocationId"),
                    City = row.Field<string>("City"),
                    Area = row.Field<string>("Area"),
                    Country = row.Field<string>("Country")
                },
                Categories = this.MapCategories(categories, adId),
                Images = this.MapImages(images, adId)
            };
        }

        private IReadOnlyCollection<Image> MapImages(DataTable imagesTable, int adId)
        {
            return imagesTable.AsEnumerable()
                .Where(x => x.Field<int>("AdId") == adId)
                .Select(this.MapImage).ToList();
        }

        private IReadOnlyCollection<Category> MapCategories(DataTable categoriesTable, int adId)
        {
            return categoriesTable.AsEnumerable()
                .Where(x => x.Field<int>("AdId") == adId)
                .Select(this.MapCategory).ToList();
        }

        private Category MapCategory(DataRow row)
        {
            return new Category
            {
                CategoryId = row.Field<int>("CategoryId"),
                Name = row.Field<string>("Name"),
                ParentId = row.Field<int?>("ParentId") ?? default(int)
            };
        }

        private Image MapImage(DataRow row)
        {
            return new Image
            {
                ImageId = row.Field<int>("ImageId"),
                Data = row.Field<byte[]>("Data"),
                Extension = row.Field<string>("Extension")
            };
        }
    }
}
