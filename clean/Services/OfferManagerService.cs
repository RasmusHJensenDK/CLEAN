using clean.Enums;
using clean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
 
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
            offer.OfferNumber = GenerateOfferNumber();
            offer.Status = OfferStatus.Created;
            offer.AssignedEmployees = new List<Employee>();
            offer.SelectedServices = new List<CleaningService>();
            offer.AppliedDiscounts = new List<Discount>();
            offers.Add(offer);
        }
        public void CreateOffer(string title, Customer customer, Employee contactPerson, List<CleaningService> services)
        {
 
            var offer = new Offer
            {
                OfferNumber = GenerateOfferNumber(),
                Title = title,
                Customer = customer,
                ContactPerson = contactPerson,
                Services = services,
                Status = OfferStatus.Created,
                AssignedEmployees = new List<Employee>(),
                SelectedServices = new List<CleaningService>(),
                AppliedDiscounts = new List<Discount>(),
                StartDate = DateTime.Now 
            };
 
            offers.Add(offer);
 
            SaveOffersToJson();
        }
 
private void SaveOffersToJson()
{
 
    List<Offer> existingOffers = new List<Offer>();
 
    try
    {
        string jsonExistingOffers = File.ReadAllText("offers.json");
        existingOffers = JsonSerializer.Deserialize<List<Offer>>(jsonExistingOffers);
    }
    catch (FileNotFoundException)
    {
 
    }
 
 
    existingOffers.AddRange(offers);
 
 
    string jsonOffers = JsonSerializer.Serialize(existingOffers, new JsonSerializerOptions
    {
        WriteIndented = true 
    });
 
 
    File.WriteAllText("offers.json", jsonOffers);
}
 
 
public void LoadOffersFromJson()
{
    try
    {
 
        string jsonOffers = File.ReadAllText("offers.json");
 
 
        List<Offer> loadedOffers = JsonSerializer.Deserialize<List<Offer>>(jsonOffers);
 
 
        offers.AddRange(loadedOffers);
    }
    catch (FileNotFoundException)
    {
 
        offers = new List<Offer>();
    }
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
 
            Offer offerToUpdate = GetOfferByOfferNumber(offerNumber);
 
            if (offerToUpdate != null)
            {
 
                offerToUpdate.ApplyDiscount(discount);
            }
        }
 
        private Offer GetOfferByOfferNumber(int offerNumber)
        {
 
 
            return offers.FirstOrDefault(offer => offer.OfferNumber == offerNumber);
        }
 
 
        public List<Offer> GetAllOffers()
        {
            return offers;
        }
 
        private int GenerateOfferNumber()
        {
 
            return offers.Count + 1;
        }
    }
}
 