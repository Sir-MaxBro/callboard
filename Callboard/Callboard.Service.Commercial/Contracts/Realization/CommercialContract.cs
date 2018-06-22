using Callboard.Service.Commercial.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;

namespace Callboard.Service.Commercial
{
    public class CommercialContract : ICommercialContract
    {
        private IDictionary<string, string> _pathways;
        private const int COMMERCIAL_COUNT = 3;
        private const string SECTION_NAME = "commercialSettings";
        public CommercialContract()
        {
            this.FillPathways();
        }

        private void FillPathways()
        {
            _pathways = new Dictionary<string, string>();
            var pathwaysSection = this.GetPathwaysSection();

            foreach (ImagePathElement item in pathwaysSection)
            {
                DirectoryInfo directory = new DirectoryInfo(item.Path);

                if (!directory.Exists)
                {
                    CommercialNotFound faultDetails = new CommercialNotFound
                    {
                        Message = "Commercials folder not found. Please, check path to image."
                    };
                    throw new FaultException<CommercialNotFound>(faultDetails);
                }

                FileInfo[] files = directory.GetFiles();
                foreach (var fileInfo in files)
                {
                    _pathways.Add(fileInfo.FullName, fileInfo.Extension);
                }
            }
        }

        private ImagePathCollection GetPathwaysSection()
        {
            var configSection = ConfigurationManager.GetSection(SECTION_NAME) as CommercialConfigSection;
            var pathwaysSection = configSection?.Pathways;

            if (pathwaysSection == null)
            {
                CommercialNotFound faultDetails = new CommercialNotFound
                {
                    Message = "Commercial not found. Please, check path to image."
                };
                throw new FaultException<CommercialNotFound>(faultDetails);
            }

            return pathwaysSection;
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
                    Id = i + 1,
                    Image = image
                };
                resultCollection.Add(commercial);
            }
            return resultCollection.ToArray();
        }
    }
}
