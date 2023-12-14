using clean.Models;
using System.Collections.Generic;
using System.Linq;

namespace clean.Services
{
    public class EmployeeManager
    {
        private List<Employee> employees;

        public EmployeeManager()
        {
            employees = new List<Employee>();
            // Add initialization logic if needed
        }

        public void AddEmployee(Employee employee)
        {
            // Add validation logic if needed
            employees.Add(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        // Add your logic to get available employees
        public List<Employee> GetAvailableEmployees()
        {
            // For example, you might consider employees who are not currently assigned to any offers
            return employees.Where(e => e.AssignedOffers.Count == 0).ToList();
        }
        public void AssignEmployee(Offer offer, Employee employee)
        {
            // Add validation or other logic as needed
            employee.AssignedOffers.Add(offer);
            offer.AssignEmployee(employee);
        }

        // Add other methods as needed
    }
}
