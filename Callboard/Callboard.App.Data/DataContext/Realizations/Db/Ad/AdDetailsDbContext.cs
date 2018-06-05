using Callboard.App.Data.DataContext.Main;
using Callboard.App.Data.DbContext.Main;
using Callboard.App.Data.Mappers;
using Callboard.App.General.Entities;
using Callboard.App.General.Helpers.Main;
using Callboard.App.General.Loggers.Main;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Callboard.App.Data.DataContext.Realizations.Db
{
    internal class AdDetailsDbContext : EntityDbContext<AdDetails>, IAdDetailsContext
    {
        public AdDetailsDbContext(IDbContext context, ILoggerWrapper logger, IChecker checker) 
            : base(context, logger, checker) { }

        public AdDetails GetById(int id)
        {
            var procedureName = "sp_get_addetails_by_adid";
            var values = new Dictionary<string, object>
            {
                { "AdId", id }
            };
            var mapper = new Mapper<DataSet, AdDetails> { MapItem = MapAdDetails };
            var adDetails = base.Get(procedureName, mapper, values);
            return adDetails;
        }

        public void Save(AdDetails adDetails)
        {
            var procedureName = "sp_save_addetails";
            var mapper = new Mapper<DataSet, AdDetails> { MapValues = this.MapAdDetailsToValues };
            base.Save(adDetails, procedureName, mapper);
        }

        private IDictionary<string, object> MapAdDetailsToValues(AdDetails adDetails)
        {
            return new Dictionary<string, object>
            {
                { "AdId", adDetails.AdId },
                { "UserId", adDetails.User.UserId },
                { "LocationId", adDetails.Location.LocationId },
                { "Name", adDetails.Name },
                { "State", adDetails.State },
                { "Kind", adDetails.Kind },
                { "Price", adDetails.Price },
                { "CreationDate", adDetails.CreationDate },
                { "AddressLine", adDetails.AddressLine },
                { "Description", adDetails.Description },
                { "Images", this.GetImageRecords(adDetails.Images) },
                { "Categories", this.GetCategoriesRecords(adDetails.Categories) }
            };
        }

        private IReadOnlyCollection<SqlDataRecord> GetImageRecords(IReadOnlyCollection<Image> images)
        {
            var records = new List<SqlDataRecord>();
            var metadata = new SqlMetaData[]
            {
                new SqlMetaData("ImageId", SqlDbType.Int),
                new SqlMetaData("Data", SqlDbType.VarBinary, 8000),
                new SqlMetaData("MimeType", SqlDbType.NVarChar, 50),
            };
            foreach (var item in images)
            {
                SqlDataRecord record = new SqlDataRecord(metadata);
                record.SetValue(0, item.ImageId);
                record.SetValue(1, item.Data);
                record.SetString(2, item.Extension);
                records.Add(record);
            }
            return records;
        }

        private IReadOnlyCollection<SqlDataRecord> GetCategoriesRecords(IReadOnlyCollection<Category> categories)
        {
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

        private AdDetails MapAdDetails(DataSet dataSet)
        {
            return dataSet.Tables[0].AsEnumerable().Select(adDetails =>
            {
                var categories = dataSet.Tables[1];
                var images = dataSet.Tables[2];
                var user = dataSet.Tables[3];
                var mails = dataSet.Tables[4];
                var phones = dataSet.Tables[5];
                return MapAdDetails(adDetails, categories, images, user, mails, phones);
            }).First();
        }

        private AdDetails MapAdDetails(DataRow row, DataTable categories, DataTable images, DataTable users, DataTable mails, DataTable phones)
        {
            int adId = row.Field<int>("AdId");
            int userId = row.Field<int>("UserId");
            return new AdDetails
            {
                AdId = adId,
                Kind = row.Field<string>("Kind"),
                State = row.Field<string>("State"),
                Name = row.Field<string>("Name"),
                Price = row.Field<decimal>("Price"),
                CreationDate = row.Field<DateTime>("CreationDate"),
                AddressLine = row.Field<string>("AddressLine"),
                Description = row.Field<string>("Description"),
                Location = new Location
                {
                    LocationId = row.Field<int>("LocationId"),
                    City = row.Field<string>("City"),
                    Area = row.Field<string>("Area"),
                    Country = row.Field<string>("Country")
                },
                Categories = this.MapCategories(categories, adId),
                Images = this.MapImages(images, adId),
                User = this.MapUser(users, mails, phones, userId)
            };
        }

        private User MapUser(DataTable users, DataTable mails, DataTable phones, int userId)
        {
            return users.AsEnumerable().Where(user => user.Field<int>("UserId") == userId)
                .Select(user =>
                {
                    return new User
                    {
                        UserId = userId,
                        Name = user.Field<string>("Name"),
                        PhotoData = user.Field<byte[]>("PhotoData"),
                        PhotoExtension = user.Field<string>("PhotoExtension"),
                        Mails = this.MapMailCollection(mails, userId),
                        Phones = this.MapPhoneCollection(phones, userId)
                    };
                }).FirstOrDefault();
        }

        private IReadOnlyCollection<Phone> MapPhoneCollection(DataTable phones, int userId)
        {
            return phones.AsEnumerable()
                        .Where(phone => phone.Field<int>("UserId") == userId)
                        .Select(phone =>
                        {
                            return new Phone
                            {
                                PhoneId = phone.Field<int>("PhoneId"),
                                Number = phone.Field<string>("Number")
                            };
                        }).ToList();
        }

        private IReadOnlyCollection<Mail> MapMailCollection(DataTable mails, int userId)
        {
            return mails.AsEnumerable()
                        .Where(mail => mail.Field<int>("UserId") == userId)
                        .Select(mail =>
                        {
                            return new Mail
                            {
                                MailId = mail.Field<int>("MailId"),
                                Email = mail.Field<string>("Email")
                            };
                        }).ToList();
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