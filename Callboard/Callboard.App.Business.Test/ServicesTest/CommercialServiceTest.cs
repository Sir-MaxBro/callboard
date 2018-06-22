using Callboard.App.Business.Services.Realizations;
using Callboard.App.Data.Services;
using Callboard.App.General.Cache.Main;
using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.ResultExtensions;
using Callboard.App.General.Results.Realizations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Callboard.App.Business.Test.ProvidersTest
{
    [TestClass]
    public class CommercialServiceTest
    {
        [TestMethod]
        public void GetCommercials_CommercialCollection()
        {
            List<Commercial> commercials = new List<Commercial>
            {
                new Commercial
                {
                    Id = 1,
                    Image = null
                },
                new Commercial
                {
                    Id = 2,
                    Image = null
                }
            };

            var mockStorage = new Mock<ICacheStorage>();
            mockStorage.Setup(storage => storage.Get<IReadOnlyCollection<Commercial>>(It.IsAny<string>()))
                .Returns((string value) => null);

            var mockCommecrialDataService = new Mock<ICommercialService>();
            mockCommecrialDataService.Setup(prov => prov.GetCommercials())
                .Returns(new SuccessResult<IReadOnlyCollection<Commercial>>(commercials));

            var commercialProvider = new CommercialService(mockStorage.Object, mockCommecrialDataService.Object);

            var resultCommercials = commercialProvider.GetCommercials().GetSuccessResult();

            Assert.AreNotEqual(resultCommercials, null);
            Assert.AreEqual(resultCommercials.Count, commercials.Count);
            CollectionAssert.AreEqual(resultCommercials.ToList(), commercials);
            mockCommecrialDataService.Verify(mock => mock.GetCommercials(), Times.Once());
        }

        [TestMethod]
        public void GetCommercials_CommercialCollectionFromCache()
        {
            List<Commercial> commercials = new List<Commercial>
            {
                new Commercial
                {
                    Id = 1,
                    Image = null
                },
                new Commercial
                {
                    Id = 2,
                    Image = null
                }
            };

            var mockStorage = new Mock<ICacheStorage>();
            mockStorage.Setup(storage => storage.Get<IReadOnlyCollection<Commercial>>(It.IsAny<string>()))
                .Returns(commercials);

            var mockCommecrialDataService = new Mock<ICommercialService>();

            var commercialService = new CommercialService(mockStorage.Object, mockCommecrialDataService.Object);

            var resultCommercials = commercialService.GetCommercials().GetSuccessResult();

            Assert.AreNotEqual(resultCommercials, null);
            Assert.AreEqual(resultCommercials.Count, commercials.Count);
            CollectionAssert.AreEqual(resultCommercials.ToList(), commercials);
            mockStorage.Verify(mock => mock.Get<IReadOnlyCollection<Commercial>>(It.IsAny<string>()), Times.Once());
        }
    }
}