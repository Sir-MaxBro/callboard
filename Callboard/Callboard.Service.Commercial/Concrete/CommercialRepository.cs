using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Callboard.Service.Commercial.Config;

namespace Callboard.Service.Commercial
{
    public class CommercialRepository : ICommercialRepository
    {
        private IDictionary<string, string> _pathways;
        private const int COMMERCIAL_COUNT = 3;
        public CommercialRepository()
        {
            _pathways = new Dictionary<string, string>();
            var pathwaysSection = ((StartupCommercialConfigSection)ConfigurationManager.GetSection("commercialSettings")).Pathways;
            foreach (CommercialPathElement item in pathwaysSection)
            {
                DirectoryInfo directory = new DirectoryInfo(item.Path);
                FileInfo[] files = directory.GetFiles();
                foreach (var fileInfo in files)
                {
                    _pathways.Add(fileInfo.FullName, fileInfo.Extension);
                }
            }
        }

        public Commercial[] GetCommercials()
        {
            var resultCollection = new List<Commercial>();
            Random random = new Random();
            for (int i = 0; i < COMMERCIAL_COUNT; i++)
            {
                int index = random.Next(0, _pathways.Count);
                byte[] image = File.ReadAllBytes(_pathways.Keys.ElementAt(index));
                Commercial commercial = new Commercial
                {
                    ImageData = image,
                    ImageExtension = _pathways.Values.ElementAt(index).TrimStart('.')
                };
                resultCollection.Add(commercial);
            }

            return resultCollection.ToArray();
        }
    }
}
