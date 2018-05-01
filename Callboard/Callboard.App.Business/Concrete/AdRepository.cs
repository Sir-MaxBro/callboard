using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Callboard.App.Business.Abstract;
using Callboard.App.General.Entities;

namespace Callboard.App.Business.Concrete
{
    internal class AdRepository : IAdRepository
    {
        private ICollection<Ad> _source = new List<Ad>();
        public AdRepository()
        {
            for (int i = 0; i < 5; i++)
            {
                Ad ad = new Ad();
                ad.ID = i;
                ad.Name = $"Name {i}";
                ad.Description = $"Description {i}";
                ad.Price = i + 1000;
                ad.Categories = new List<Category>
                {
                    new Category { ID = i, Name = $"Category {i}"}
                };
                _source.Add(ad);
            }
        }

        public IReadOnlyCollection<Ad> Items
        {
            get { return _source.ToList(); }
            set { throw new NotImplementedException(); }
        }

        public Ad GetAd(int adID)
        {
            return _source.First(x => x.ID == adID);
        }

        public IReadOnlyCollection<Ad> GetCategoryAds(int categoryID)
        {
            return _source.Where(x => x.Categories?.Select(y => y.ID == categoryID).Count() != 0).ToList(); // replace on stored procedure
        }
    }
}
