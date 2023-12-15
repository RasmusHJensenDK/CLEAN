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
            // Add validation logic if needed
            offer.OfferNumber = GenerateOfferNumber();
            offer.Status = OfferStatus.Created;
            offer.AssignedEmployees = new List<Employee>();
            offer.SelectedServices = new List<CleaningService>();
            offer.AppliedDiscounts = new List<Discount>();
            offers.Add(offer);
        }
        public void CreateOffer(string title, Customer customer, Employee contactPerson, List<CleaningService> services)
        {
            // Add validation logic if needed
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
                StartDate = DateTime.Now // Set the creation date when creating the offer
            };

            offers.Add(offer);

            SaveOffersToJson();
        }

private void SaveOffersToJson()
{
    // Read existing JSON from the file, if it exists
    List<Offer> existingOffers = new List<Offer>();

    try
    {
        string jsonExistingOffers = File.ReadAllText("offers.json");
        existingOffers = JsonSerializer.Deserialize<List<Offer>>(jsonExistingOffers);
    }
    catch (FileNotFoundException)
    {
        // Handle the case where the file doesn't exist (first run, or offers.json was deleted)
    }

    // Add the current offers to the existing ones
    existingOffers.AddRange(offers);

    // Serialize the combined list to JSON
    string jsonOffers = JsonSerializer.Serialize(existingOffers, new JsonSerializerOptions
    {
        WriteIndented = true // Makes the JSON readable with indentation
    });

    // Write the JSON back to the file
    File.WriteAllText("offers.json", jsonOffers);
}


public void LoadOffersFromJson()
{
    try
    {
        // Read JSON from the file
        string jsonOffers = File.ReadAllText("offers.json");

        // Deserialize JSON to List<Offer>
        List<Offer> loadedOffers = JsonSerializer.Deserialize<List<Offer>>(jsonOffers);

        // Merge the loaded offers into the existing list
        offers.AddRange(loadedOffers);
    }
    catch (FileNotFoundException)
    {
        // Handle the case where the file doesn't exist (first run, or offers.json was deleted)
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

        // Inside OfferManager class
        public void ApplyDiscountToOffer(int offerNumber, Discount discount)
        {
            // Assuming you have a method to get the offer by its offer number
            Offer offerToUpdate = GetOfferByOfferNumber(offerNumber);

            if (offerToUpdate != null)
            {
                // Apply the discount to the offer
                offerToUpdate.ApplyDiscount(discount);
            }
        }

        private Offer GetOfferByOfferNumber(int offerNumber)
        {
            // Assuming you have a method to get the offer by its offer number
            // Implement the logic to find and return the offer with the specified offer number
            return offers.FirstOrDefault(offer => offer.OfferNumber == offerNumber);
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
