using Callboard.App.Business.Services.Realizations;
using Callboard.App.Data.Repositories;
using Callboard.App.General.Entities;
using Callboard.App.General.Exceptions;
using Callboard.App.General.ResultExtensions;
using Callboard.App.General.Results.Realizations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Callboard.App.Business.Test.ProvidersTest.Ad
{
    [TestClass]
    public class KindProviderTest
    {
        [TestMethod]
        public void GetAll_KindsCollection()
        {
            var kinds = new List<Kind>();
            var mockKindRepository = new Mock<IRepository<Kind>>();
            mockKindRepository.Setup(repo => repo.GetAll()).Returns(new SuccessResult<IReadOnlyCollection<Kind>>(kinds));

            var kindProvider = new KindService(mockKindRepository.Object);

            var resultKinds = kindProvider.GetAll().GetSuccessResult();

            Assert.AreEqual(kinds.Count, resultKinds.Count);
            mockKindRepository.Verify(mock => mock.GetAll(), Times.Once());
        }

        [TestMethod]
        public void GetById_ValidId_KindElement()
        {
            int id = 1;
            var kind = new Kind
            {
                KindId = 1,
                Type = "Product"
            };

            var mockKindRepository = new Mock<IRepository<Kind>>();
            mockKindRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(new SuccessResult<Kind>(kind));

            var kindProvider = new KindService(mockKindRepository.Object);

            var resultKind = kindProvider.GetById(id).GetSuccessResult();

            Assert.AreEqual(resultKind.KindId, kind.KindId);
            Assert.AreEqual(resultKind.Type, kind.Type);
            mockKindRepository.Verify(mock => mock.GetById(id), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidIdException))]
        public void GetById_InvalidId_Throws()
        {
            int invalidId = 0;
            var mockKindRepository = new Mock<IRepository<Kind>>();
            mockKindRepository.Setup(repo => repo.GetById(It.IsAny<int>()));

            var kindProvider = new KindService(mockKindRepository.Object);

            var resultKind = kindProvider.GetById(invalidId);

            mockKindRepository.Verify(mock => mock.GetById(invalidId), Times.Once());
        }

        [TestMethod]
        public void Save_ValidKindObj_ObjSaved()
        {
            var kinds = new List<Kind>();
            var kind = new Kind
            {
                KindId = 1,
                Type = "Product"
            };

            var mockKindRepository = new Mock<IRepository<Kind>>();
            mockKindRepository.Setup(repo => repo.Save(It.IsAny<Kind>())).Callback((Kind value) => kinds.Add(value));

            var kindProvider = new KindService(mockKindRepository.Object);

            kindProvider.Save(kind);

            Assert.AreEqual(kinds.Count, 1);
            Assert.IsTrue(kinds.Contains(kind));
            mockKindRepository.Verify(mock => mock.Save(kind), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Save_Null_Throws()
        {
            var mockKindRepository = new Mock<IRepository<Kind>>();
            mockKindRepository.Setup(repo => repo.Save(It.IsAny<Kind>()));

            var kindProvider = new KindService(mockKindRepository.Object);

            kindProvider.Save(null);
            mockKindRepository.Verify(mock => mock.Save(null), Times.Once());
        }

        [TestMethod]
        public void Delete_ValidId_ObjDeleted()
        {
            int id = 1;
            var kinds = new List<Kind> {
                new Kind
                {
                    KindId = 1,
                    Type = "Product"
                }
            };

            var mockKindRepository = new Mock<IRepository<Kind>>();
            mockKindRepository.Setup(repo => repo.Delete(It.IsAny<int>())).Callback(() => kinds.RemoveAt(0));

            var kindProvider = new KindService(mockKindRepository.Object);

            kindProvider.Delete(id);

            Assert.AreEqual(kinds.Count, 0);
            mockKindRepository.Verify(mock => mock.Delete(id), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidIdException))]
        public void Delete_InvalidId_Throws()
        {
            int invalidId = 0;
            var mockKindRepository = new Mock<IRepository<Kind>>();
            mockKindRepository.Setup(repo => repo.Delete(It.IsAny<int>()));

            var kindProvider = new KindService(mockKindRepository.Object);

            kindProvider.Delete(invalidId);
            mockKindRepository.Verify(mock => mock.Delete(invalidId), Times.Once());
        }
    }
}
