using clean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Services
{
    public class EmployeeManager
    {
        private List<Employee> employees;

        public EmployeeManager()
        {
            this.employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            // Add validation logic if needed
            this.employees.Add(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return this.employees;
        }
    }

}
