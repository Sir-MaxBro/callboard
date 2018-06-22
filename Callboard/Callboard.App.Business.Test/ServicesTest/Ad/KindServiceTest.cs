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
    public class KindServiceTest
    {
        [TestMethod]
        public void GetAll_KindsCollection()
        {
            var kinds = new List<Kind>
            {
                new Kind
                {
                    KindId = 1,
                    Type = "MyType-1"
                },
                new Kind
                {
                    KindId = 2,
                    Type = "MyType-2"
                }
            };

            var mockKindRepository = new Mock<IRepository<Kind>>();
            mockKindRepository.Setup(repo => repo.GetAll())
                .Returns(new SuccessResult<IReadOnlyCollection<Kind>>(kinds));

            var kindProvider = new KindService(mockKindRepository.Object);

            var resultKinds = kindProvider.GetAll().GetSuccessResult();

            Assert.AreNotEqual(resultKinds, null);
            Assert.AreEqual(kinds.Count, resultKinds.Count);
            mockKindRepository.Verify(mock => mock.GetAll(), Times.Once());
        }

        [TestMethod]
        public void GetById_ValidId_KindElement()
        {
            int validId = 1;
            var kind = new Kind
            {
                KindId = 1,
                Type = "Product"
            };

            var mockKindRepository = new Mock<IRepository<Kind>>();
            mockKindRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    if (id == validId)
                    {
                        return new SuccessResult<Kind>(kind);
                    }
                    return new NoneResult<Kind>();
                });

            var kindService = new KindService(mockKindRepository.Object);

            var resultKind = kindService.GetById(validId).GetSuccessResult();

            Assert.AreNotEqual(resultKind, null);
            Assert.AreEqual(resultKind.KindId, validId);
            Assert.AreEqual(resultKind.Type, kind.Type);
            mockKindRepository.Verify(mock => mock.GetById(validId), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidIdException))]
        public void GetById_InvalidId_Throws()
        {
            int invalidId = 0;

            var mockKindRepository = new Mock<IRepository<Kind>>();
            mockKindRepository.Setup(repo => repo.GetById(It.IsAny<int>()));

            var kindService = new KindService(mockKindRepository.Object);

            var resultKind = kindService.GetById(invalidId);

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
            mockKindRepository.Setup(repo => repo.Save(It.IsAny<Kind>()))
                .Callback((Kind value) => kinds.Add(value));

            var kindService = new KindService(mockKindRepository.Object);

            kindService.Save(kind);

            Assert.AreEqual(kinds.Count, 1);
            Assert.IsTrue(kinds.Contains(kind));
            mockKindRepository.Verify(mock => mock.Save(kind), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Save_Null_Throws()
        {
            Kind invalidObj = null;
            var mockKindRepository = new Mock<IRepository<Kind>>();
            mockKindRepository.Setup(repo => repo.Save(It.IsAny<Kind>()));

            var kindProvider = new KindService(mockKindRepository.Object);

            kindProvider.Save(invalidObj);

            mockKindRepository.Verify(mock => mock.Save(invalidObj), Times.Once());
        }

        [TestMethod]
        public void Delete_ValidId_ObjDeleted()
        {
            int validId = 1;
            var kinds = new List<Kind>
            {
                new Kind
                {
                    KindId = 1,
                    Type = "Product"
                },
                new Kind
                {
                    KindId = 2,
                    Type = "MyType-2"
                }
            };
            int countBeforeDelete = kinds.Count;

            var mockKindRepository = new Mock<IRepository<Kind>>();
            mockKindRepository.Setup(repo => repo.Delete(It.IsAny<int>()))
                .Callback((int id) =>
                {
                    if (id == validId)
                    {
                        kinds.RemoveAll(kind => kind.KindId == id);
                    }
                });

            var kindProvider = new KindService(mockKindRepository.Object);

            kindProvider.Delete(validId);

            Assert.AreEqual(kinds.Count, countBeforeDelete - 1);
            Assert.IsFalse(kinds.Exists(kind => kind.KindId == validId));
            mockKindRepository.Verify(mock => mock.Delete(validId), Times.Once());
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