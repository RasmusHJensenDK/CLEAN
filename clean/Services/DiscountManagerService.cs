using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Services
{
    public class DiscountManager
    {
        private List<Discount> discounts;

        public DiscountManager()
        {
            this.discounts = new List<Discount>();
        }

        public void AddDiscount(Discount discount)
        {
            // Add validation logic if needed
            this.discounts.Add(discount);
        }

        public List<Discount> GetAllDiscounts()
        {
            return this.discounts;
        }

        
    }

}
