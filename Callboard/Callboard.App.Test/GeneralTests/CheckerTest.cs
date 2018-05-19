using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Callboard.App.General.Helpers;
using Callboard.App.General.Exceptions;

namespace Callboard.App.Test.GeneralTests
{
    [TestClass]
    public class CheckerTest
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CanCheckForNull()
        {
            object obj = null;
            Checker.CheckForNull(obj);
        }

        [TestMethod]
        public void CanCheckId()
        {
            int id = 1;
            Checker.CheckId(id);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidIdException))]
        public void CanCheckInvalidId()
        {
            int id = -1;
            Checker.CheckId(id);
        }
    }
}
