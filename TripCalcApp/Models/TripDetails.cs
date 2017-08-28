using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TripCalcApp.Models
{
    public class TripDetails
    {
        [DataType(DataType.Currency)]
        public decimal total { get; set; }

        public List<Student> students { get; set; } = new List<Student>();

        [DataType(DataType.Currency)]
        public decimal costPerStudent() => total / students.Count;

        //From, to, amount
        public List<Tuple<Student, Student, decimal>> oweTable { get; set; } = new List<Tuple<Student, Student, decimal>>();

        public TripDetails calculateExpenses()
        {
            decimal cps = this.costPerStudent();

            foreach (Student s in this.students)
            {
                s.owedAmount = cps - s.paidAmount;
            }

            List<Student> overPaidStudents = new List<Student>();
            List<Student> underPaidStudents = new List<Student>();
            foreach (Student s in this.students)
            {
                if (s.paidAmount < cps)
                {
                    underPaidStudents.Add(s);
                }
                else if (s.paidAmount > cps)
                {
                    overPaidStudents.Add(s);
                }
            }

            foreach (Student s in underPaidStudents)
            {
                decimal remainder = 1;
                while (((int)remainder) > 0)
                {
                    Student overPaidStud = overPaidStudents.First();
                    remainder = s.owedAmount + overPaidStud.owedAmount;
                    if (remainder > 0)
                    {
                        var zero = s.owedAmount - remainder + overPaidStud.owedAmount;
                        this.oweTable.Add(new Tuple<Student, Student, decimal>(s, overPaidStud, s.owedAmount - remainder));
                        overPaidStudents.Remove(overPaidStud);
                    }
                    else if (remainder < 0)
                    {
                        this.oweTable.Add(new Tuple<Student, Student, decimal>(s, overPaidStud, s.owedAmount));
                        overPaidStudents.First().owedAmount = remainder;
                    }
                }
            }

            return this;
        }
    }
}