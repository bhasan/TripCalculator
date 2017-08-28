using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TripCalcApp.Models
{
    public class Student
    {
        public Student()
        {
        }

        public Student(string firstName, string lastName, decimal paidAmount)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.paidAmount = paidAmount;
        }
        public string firstName { get; set; }
        
        public string lastName { get; set; }

        public string Name { get { return String.Format("{0} {1}", this.firstName, this.lastName); } }
        
        [DataType(DataType.Currency)]
        public decimal paidAmount { get; set; }

        [DataType(DataType.Currency)]
        public decimal owedAmount { get; set; }
    }
}