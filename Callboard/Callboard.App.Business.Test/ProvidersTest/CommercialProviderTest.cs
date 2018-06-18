﻿using Callboard.App.Business.Services.Realizations;
using Callboard.App.Data.Services;
using Callboard.App.General.Cache.Main;
using Callboard.App.General.Entities.Commercial;
using Callboard.App.General.ResultExtensions;
using Callboard.App.General.Results.Realizations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Callboard.App.Business.Test.ProvidersTest
{
    [TestClass]
    public class CommercialProviderTest
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
                }
            };

            var mockStorage = new Mock<ICacheStorage>();
            mockStorage.Setup(storage => storage.Get<IReadOnlyCollection<Commercial>>(It.IsAny<string>()))
                .Returns((string value) => null);

            var mockCommecrialDataProvider = new Mock<ICommercialService>();
            mockCommecrialDataProvider.Setup(prov => prov.GetCommercials())
                .Returns(new SuccessResult<IReadOnlyCollection<Commercial>>(commercials));

            var commercialProvider = new CommercialService(mockStorage.Object, mockCommecrialDataProvider.Object);

            var resultCommercials = commercialProvider.GetCommercials().GetSuccessResult();

            Assert.AreEqual(resultCommercials.Count, commercials.Count);
            mockCommecrialDataProvider.Verify(mock => mock.GetCommercials(), Times.Once());
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
                }
            };

            var mockStorage = new Mock<ICacheStorage>();
            mockStorage.Setup(storage => storage.Get<IReadOnlyCollection<Commercial>>(It.IsAny<string>()))
                .Returns(commercials);

            var mockCommecrialDataProvider = new Mock<ICommercialService>();

            var commercialProvider = new CommercialService(mockStorage.Object, mockCommecrialDataProvider.Object);

            var resultCommercials = commercialProvider.GetCommercials().GetSuccessResult();

            Assert.AreEqual(resultCommercials.Count, commercials.Count);
            mockStorage.Verify(mock => mock.Get<IReadOnlyCollection<Commercial>>(It.IsAny<string>()), Times.Once());
        }
    }
}