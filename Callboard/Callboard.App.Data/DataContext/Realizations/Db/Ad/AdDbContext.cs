﻿using Callboard.App.Data.DbContext;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Entities.Data;
using Callboard.App.General.Loggers.Main;
using Callboard.App.General.Results;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class AdDbContext : EntityDbContext<Ad>, IAdContext
    {
        public AdDbContext(IDbContext context, ILoggerWrapper logger)
            : base(context, logger) { }

        public IResult<Ad> Delete(int id)
        {
            string procedureName = "sp_delete_ad_by_id";
            var values = new Dictionary<string, object>
            {
                { "AdId", id }
            };
            return base.Execute(procedureName, values);
        }

        public IResult<IReadOnlyCollection<Ad>> GetAdsByCategoryId(int categoryId)
        {
            string procedureName = "sp_select_ad_by_categoryid";
            var values = new Dictionary<string, object>
            {
                { "CategoryId", categoryId }
            };
            var mapper = new Mapper<DataSet, Ad> { MapCollection = MapAdCollection };

            return base.GetAll(procedureName, mapper, values);
        }

        public IResult<IReadOnlyCollection<Ad>> GetAdsForUser(int userId)
        {
            string procedureName = "sp_select_ad_by_userid";
            var values = new Dictionary<string, object>
            {
                { "UserId", userId }
            };
            var mapper = new Mapper<DataSet, Ad> { MapCollection = MapAdCollection };

            return base.GetAll(procedureName, mapper, values);
        }

        public IResult<IReadOnlyCollection<Ad>> GetAll()
        {
            var procedureName = "sp_select_ad";
            var mapper = new Mapper<DataSet, Ad> { MapCollection = MapAdCollection };

            return base.GetAll(procedureName, mapper);
        }

        public IResult<IReadOnlyCollection<Ad>> SearchByName(string name)
        {
            var procedureName = "sp_search_ad_by_name";
            var mapper = new Mapper<DataSet, Ad> { MapCollection = MapAdCollection };
            var values = new Dictionary<string, object>
            {
                { "SearchName", name }
            };

            return base.GetAll(procedureName, mapper, values);
        }

        public IResult<IReadOnlyCollection<Ad>> Search(SearchConfiguration searchConfiguration)
        {
            string procedureName = "sp_search_ad";
            var mapper = new Mapper<DataSet, Ad> { MapCollection = MapAdCollection };
            var values = new Dictionary<string, object>
            {
                { "Name", searchConfiguration.Name },
                { "State", searchConfiguration.State },
                { "Kind", searchConfiguration.Kind },
                { "CountryId", searchConfiguration.CountryId },
                { "AreaId", searchConfiguration.AreaId },
                { "CityId", searchConfiguration.CityId },
                { "MinPrice", searchConfiguration.MinPrice },
                { "MaxPrice", searchConfiguration.MaxPrice },
                { "Categories", this.MapCategoriesToValues(searchConfiguration.Categories) }
            };

            return base.GetAll(procedureName, mapper, values);
        }

        private IReadOnlyCollection<SqlDataRecord> MapCategoriesToValues(IReadOnlyCollection<Category> categories)
        {
            if (categories == null || categories?.Count < 1)
            {
                return null;
            }

            var records = new List<SqlDataRecord>();
            var metadata = new SqlMetaData[]
            {
                new SqlMetaData("CategoryId", SqlDbType.Int)
            };
            foreach (var item in categories)
            {
                SqlDataRecord record = new SqlDataRecord(metadata);
                record.SetValue(0, item.CategoryId);
                records.Add(record);
            }
            return records;
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