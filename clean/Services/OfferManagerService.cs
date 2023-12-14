using clean.Enums;
using clean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Services
{
    public class OfferManager
    {
        private List<Offer> offers;
        private List<CleaningTask> tasks;
        private DiscountManager discountManager;

        public OfferManager()
        {
            offers = new List<Offer>();
            tasks = new List<CleaningTask>();
            discountManager = new DiscountManager();
        }

        public void AddOffer(Offer offer)
        {
            // Add validation logic if needed
            offer.OfferNumber = GenerateOfferNumber();
            offer.Status = OfferStatus.Created;
            offer.AssignedEmployees = new List<Employee>();
            offer.SelectedServices = new List<CleaningService>();
            offer.AppliedDiscounts = new List<Discount>();
            offers.Add(offer);
        }

        public void AssignEmployeeToOffer(int offerNumber, Employee employee)
        {
            var offer = offers.FirstOrDefault(o => o.OfferNumber == offerNumber);
            if (offer != null)
            {
                offer.AssignEmployee(employee);
            }
        }

        public void SelectServiceForOffer(int offerNumber, CleaningService service)
        {
            var offer = offers.FirstOrDefault(o => o.OfferNumber == offerNumber);
            if (offer != null)
            {
                offer.SelectService(service);
            }
        }

        public void ApplyDiscountToOffer(int offerNumber, Discount discount)
        {
            var offer = offers.FirstOrDefault(o => o.OfferNumber == offerNumber);
            if (offer != null)
            {
                offer.ApplyDiscount(discount);
            }
        }

        public List<Offer> GetAllOffers()
        {
            return offers;
        }

        private int GenerateOfferNumber()
        {
            // Implement logic to generate a unique offer number
            return offers.Count + 1;
        }
    }


}
