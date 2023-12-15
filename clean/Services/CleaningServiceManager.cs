using clean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Services
{
    public class CleaningServiceManager
    {
        private List<CleaningService> cleaningServices;

        public CleaningServiceManager()
        {
            this.cleaningServices = new List<CleaningService>();
        }

        public void AddCleaningService(CleaningService cleaningService)
        {
            // Add validation logic
            this.cleaningServices.Add(cleaningService);
        }

        public List<CleaningService> GetAllCleaningServices()
        {
            return this.cleaningServices;
        }
    }

}
