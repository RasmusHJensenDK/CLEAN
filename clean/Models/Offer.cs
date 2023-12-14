using clean.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Models
{
    public class Offer
    {
        public int OfferNumber { get; set; }
        public string Title { get; set; }
        public Customer Customer { get; set; }
        public Employee ContactPerson { get; set; }
        public List<CleaningService> Services { get; set; }
        public OfferStatus Status { get; set; }
        public List<Employee> AssignedEmployees { get; set; }
        public List<CleaningService> SelectedServices { get; set; }
        public List<Discount> AppliedDiscounts { get; set; }

        public Offer()
        {
            AssignedEmployees = new List<Employee>();
            SelectedServices = new List<CleaningService>();
            AppliedDiscounts = new List<Discount>();
        }

        public void AssignEmployee(Employee employee)
        {
            // Add validation logic if needed
            AssignedEmployees.Add(employee);
        }

        public void SelectService(CleaningService service)
        {
            // Add validation logic if needed
            SelectedServices.Add(service);
        }

        public void ApplyDiscount(Discount discount)
        {
            // Add validation logic if needed
            AppliedDiscounts.Add(discount);
        }

        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (var service in SelectedServices)
            {
                totalPrice += service.Price;
            }

            // You can add additional logic for price calculation based on other factors

            // Apply discounts if any
            foreach (var discount in AppliedDiscounts)
            {
                totalPrice -= totalPrice * discount.Percentage;
            }

            return totalPrice;
        }
    }

}
