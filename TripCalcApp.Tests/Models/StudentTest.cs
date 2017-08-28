using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using TripCalcApp;
using TripCalcApp.Controllers;
using TripCalcApp.Models;

namespace TripCalcApp.Tests.Models
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void StudentInitilizationTest()
        {
            Student s = new Student();
            Student two = new Student("Bob", "Smith", 12.34M);

            Assert.AreEqual(s.firstName, "");
            Assert.AreEqual(s.lastName, "");
            Assert.AreEqual(s.paidAmount, 0);
            Assert.AreEqual(two.firstName, "Bob");
            Assert.AreEqual(two.lastName, "Smith");
            Assert.AreEqual(two.paidAmount, 12.34M);
        }
    }
}
