using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class ShippingRate
    {
        private string country;
        private int rate;

        public ShippingRate(string country, int rate) {
            this.country = country;
            this.rate = rate;
        }

        public int getRate()
        {
            return this.rate;
        }

        public string getCountry() {
            return this.country;
        }
    }
}
