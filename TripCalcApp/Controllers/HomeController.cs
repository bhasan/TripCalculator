using TripCalcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TripCalcApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Calculate()
        {
            ViewBag.warning = false;
            ViewBag.warningMessage = "";
            var students = new List<Student>();
            students.Add(new Student());
            students.Add(new Student());
            students.Add(new Student());

            return View(students);
        }

        [HttpPost]
        public ActionResult Calculate(IEnumerable<Student> students)
        {
            TripDetails trip = new TripDetails();
            foreach (Student s in students)
            {
                if (s.Name == " ")
                {
                    ViewBag.warningMessage = "Please fill out all fields";
                    return View(students);
                }

                trip.total += s.paidAmount;
                trip.students.Add(s);
            }

            trip = trip.calculateExpenses();

            //Build string
            string output = "";
            foreach (var i in trip.oweTable)
            {
                Student from = i.Item1;
                Student to = i.Item2;
                decimal amount = i.Item3;

                output += string.Format("{0} owes {1} ${2:f2}. <br>", from.Name, to.Name, amount);
            }

            ViewBag.output = output;

            return View(students);
        }

        public ActionResult Index()
        {
            return RedirectToAction("Calculate", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}