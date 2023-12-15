using System;
using System.Collections.Generic;
using System.Linq;
using clean.Enums;

namespace clean.Models
{
    public class Offer
    {
        public int OfferNumber { get; set; }
        public string Title { get; set; }
        public Customer Customer { get; set; }
        public Employee ContactPerson { get; set; }
        public List<CleaningService> Services { get; set; }
        public List<Employee> AssignedEmployees { get; set; }
        public List<CleaningService> SelectedServices { get; set; }
        public List<Discount> AppliedDiscounts { get; set; }
        public OfferStatus Status { get; set; }
        public DateTime StartDate { get; set; }

        public Offer()
        {
            this.AssignedEmployees = new List<Employee>();
            this.SelectedServices = new List<CleaningService>();
            this.AppliedDiscounts = new List<Discount>();
            this.Status = OfferStatus.Created;
        }

        public override string ToString()
        {
            string customerName = Customer != null ? Customer.Name : "N/A";
            string contactPersonName = ContactPerson != null ? ContactPerson.Name : "N/A";

            string assignedEmployees = string.Join(", ", AssignedEmployees.Select(e => e.Name));
            string selectedServices = string.Join(", ", SelectedServices.Select(s => s.ServiceName));
            string appliedDiscounts = string.Join(", ", AppliedDiscounts.Select(d => d.DiscountName));

            return $"OfferNumber: {OfferNumber} - Title: {Title} - Customer: {customerName} - ContactPerson: {contactPersonName} - " +
                   $"Services: {string.Join(", ", Services?.Select(s => s.ServiceName) ?? Enumerable.Empty<string>())} - " +
                   $"AssignedEmployees: {assignedEmployees} - SelectedServices: {selectedServices} - " +
                   $"AppliedDiscounts: {appliedDiscounts} - Status: {Status} - StartDate: {StartDate.ToShortDateString()}";
        }


        public void ApplyDiscount(Discount discount)
        {
            // Add logic to apply the discount to the offer
            // For example, add the discount to the list of applied discounts
            this.AppliedDiscounts.Add(discount);

            // You might want to recalculate the offer price or perform other actions here
            RecalculateOfferPrice();
        }

        // Method to recalculate the offer price based on services and discounts
        private void RecalculateOfferPrice()
        {
            decimal totalPrice = 0;

            // Calculate the total price of selected services
            foreach (var service in SelectedServices)
            {
                totalPrice += service.Price;
            }

            // Apply discounts
            foreach (var discount in AppliedDiscounts)
            {
                // Apply discount percentage to the total price
                totalPrice -= totalPrice * discount.Percentage;
            }
        }

        public void AssignEmployee(Employee employee)
        {
            // Add logic to assign an employee to the offer
            this.AssignedEmployees.Add(employee);

            // You might want to perform additional actions related to assigning employees here
        }

        public void SelectService(CleaningService cleaningservice)
        {
            this.Services.Add(cleaningservice);
        }
    }
}