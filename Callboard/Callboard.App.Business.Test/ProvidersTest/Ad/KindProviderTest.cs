using Callboard.App.Business.Providers.Realization;
using Callboard.App.Data.Repositories.Main;
using Callboard.App.General.Entities;
using Callboard.App.General.Exceptions;
using Callboard.App.General.Helpers.Main;
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
            var mockKindRepository = new Mock<IKindRepository>();
            mockKindRepository.Setup(repo => repo.GetAll()).Returns(kinds);
            var mockChecker = new Mock<IChecker>();

            var kindProvider = new KindProvider(mockKindRepository.Object, mockChecker.Object);

            var resultKinds = kindProvider.GetAll();

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

            var mockKindRepository = new Mock<IKindRepository>();
            mockKindRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(kind);

            var mockChecker = new Mock<IChecker>();

            var kindProvider = new KindProvider(mockKindRepository.Object, mockChecker.Object);

            var resultKind = kindProvider.GetById(id);

            Assert.AreEqual(resultKind.KindId, kind.KindId);
            Assert.AreEqual(resultKind.Type, kind.Type);
            mockKindRepository.Verify(mock => mock.GetById(id), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidIdException))]
        public void GetById_InvalidId_Throws()
        {
            int invalidId = 0;
            var mockKindRepository = new Mock<IKindRepository>();
            mockKindRepository.Setup(repo => repo.GetById(It.IsAny<int>()));

            var mockChecker = new Mock<IChecker>();
            mockChecker.Setup(checker => checker.CheckId(It.IsAny<int>())).Callback((int id) =>
            {
                if (id < 1)
                {
                    throw new InvalidIdException();
                }
            });

            var kindProvider = new KindProvider(mockKindRepository.Object, mockChecker.Object);

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

            var mockKindRepository = new Mock<IKindRepository>();
            mockKindRepository.Setup(repo => repo.Save(It.IsAny<Kind>())).Callback((Kind value) => kinds.Add(value));

            var mockChecker = new Mock<IChecker>();

            var kindProvider = new KindProvider(mockKindRepository.Object, mockChecker.Object);

            kindProvider.Save(kind);

            Assert.AreEqual(kinds.Count, 1);
            Assert.IsTrue(kinds.Contains(kind));
            mockKindRepository.Verify(mock => mock.Save(kind), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Save_Null_Throws()
        {
            var mockKindRepository = new Mock<IKindRepository>();
            mockKindRepository.Setup(repo => repo.Save(It.IsAny<Kind>()));

            var mockChecker = new Mock<IChecker>();
            mockChecker.Setup(checker => checker.CheckForNull(It.IsAny<object>())).Callback((object obj) =>
            {
                if (Equals(obj, null))
                {
                    throw new NullReferenceException();
                }
            });

            var kindProvider = new KindProvider(mockKindRepository.Object, mockChecker.Object);

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

            var mockKindRepository = new Mock<IKindRepository>();
            mockKindRepository.Setup(repo => repo.Delete(It.IsAny<int>())).Callback(() => kinds.RemoveAt(0));

            var mockChecker = new Mock<IChecker>();

            var kindProvider = new KindProvider(mockKindRepository.Object, mockChecker.Object);

            kindProvider.Delete(id);

            Assert.AreEqual(kinds.Count, 0);
            mockKindRepository.Verify(mock => mock.Delete(id), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidIdException))]
        public void Delete_InvalidId_Throws()
        {
            int invalidId = 0;
            var mockKindRepository = new Mock<IKindRepository>();
            mockKindRepository.Setup(repo => repo.Delete(It.IsAny<int>()));

            var mockChecker = new Mock<IChecker>();
            mockChecker.Setup(checker => checker.CheckId(It.IsAny<int>())).Callback((int id) =>
            {
                if (id < 1)
                {
                    throw new InvalidIdException();
                }
            });

            var kindProvider = new KindProvider(mockKindRepository.Object, mockChecker.Object);

            kindProvider.Delete(invalidId);
            mockKindRepository.Verify(mock => mock.Delete(invalidId), Times.Once());
        }
    }
}
