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
            
            
            this.AppliedDiscounts.Add(discount);

            
            RecalculateOfferPrice();
        }

        
        private void RecalculateOfferPrice()
        {
            decimal totalPrice = 0;

            
            foreach (var service in SelectedServices)
            {
                totalPrice += service.Price;
            }

            
            foreach (var discount in AppliedDiscounts)
            {
                
                totalPrice -= totalPrice * discount.Percentage;
            }
        }

        public void AssignEmployee(Employee employee)
        {
            
            this.AssignedEmployees.Add(employee);

            
        }

        public void SelectService(CleaningService cleaningservice)
        {
            this.Services.Add(cleaningservice);
        }
    }
}