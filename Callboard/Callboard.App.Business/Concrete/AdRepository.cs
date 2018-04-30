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
                ad.Name = $"Name {i}";
                ad.Description = $"Description {i}";
                ad.Price = i + 1000;
                _source.Add(ad);
            }
        }

        public IReadOnlyCollection<Ad> Items
        {
            get { return _source.ToList(); }
            set { throw new NotImplementedException(); }
        }
    }
}
