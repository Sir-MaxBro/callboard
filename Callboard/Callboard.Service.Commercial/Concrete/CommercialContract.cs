using Callboard.Service.Commercial.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Callboard.Service.Commercial
{
    public class CommercialContract : ICommercialContract
    {
        private IDictionary<string, string> _pathways;
        private const int COMMERCIAL_COUNT = 3;
        private const string SECTION_NAME = "commercialSettings";
        public CommercialContract()
        {
            _pathways = new Dictionary<string, string>();
            var pathwaysSection = ((CommercialConfigSection)ConfigurationManager.GetSection(SECTION_NAME)).Pathways;
            
            foreach (ImagePathElement item in pathwaysSection)
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
                byte[] byteImage = File.ReadAllBytes(_pathways.Keys.ElementAt(index));
                Image image = new Image
                {
                    Data = byteImage,
                    Extension = _pathways.Values.ElementAt(index).TrimStart('.')
                };

                Commercial commercial = new Commercial
                {
                    Image = image
                };

                resultCollection.Add(commercial);
            }

            return resultCollection.ToArray();
        }
    }
}
