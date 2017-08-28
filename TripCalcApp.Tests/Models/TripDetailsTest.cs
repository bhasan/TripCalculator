using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripCalcApp;
using TripCalcApp.Controllers;
using TripCalcApp.Models;


namespace TripCalcApp.Tests.Models
{
    [TestClass]
    class TripDetailsTest
    {
        [TestMethod]
        public void studentListTest()
        {
            TripDetails trip = new TripDetails();
            Student one = new Student("Bob1", "Smith1", 132.54M);
            Student two = new Student("Bob", "Smith", 12.34M);
            Student three = new Student("Bob2", "Smith2", 32.32M);

            trip.students.Add(one);
            trip.students.Add(two);
            trip.students.Add(three);

            Assert.AreEqual(trip.students, new List<Student> { one, two, three });
        }

        [TestMethod]
        public void costPerStudentTest()
        {
            TripDetails trip = new TripDetails();
            Student one = new Student("Bob1", "Smith1", 132.54M);
            Student two = new Student("Bob", "Smith", 12.34M);
            Student three = new Student("Bob2", "Smith2", 32.32M);

            trip.students.Add(one);
            trip.students.Add(two);
            trip.students.Add(three);

            Assert.AreEqual(trip.costPerStudent(), ((132.54 + 12.34 + 32.32) / 3));
        }

        [TestMethod]
        public void totalCostTest()
        {
            TripDetails trip = new TripDetails();
            Student one = new Student("Bob1", "Smith1", 132.54M);
            Student two = new Student("Bob", "Smith", 12.34M);
            Student three = new Student("Bob2", "Smith2", 32.32M);

            trip.students.Add(one);
            trip.students.Add(two);
            trip.students.Add(three);

            Assert.AreEqual(trip.total, (132.54 + 12.34 + 32.32));
        }
    }
}
