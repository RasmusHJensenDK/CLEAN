using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Models
{
    public class Employee
    {
        public int EmployeeNumber { get; set; }
        public string Name { get; set; }
        public List<string> Specializations { get; set; }
        public List<Offer> AssignedOffers { get; set; } = new List<Offer>();


        public Employee()
        {
            Specializations = new List<string>();
        }
    }


}
