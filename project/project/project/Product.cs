using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Product
    {
        private string name;
        private double price;
        private string country;
        private double weight;
        private int id;
        public static int numberOfItems = 0;

        public Product(string itemName, double itemPrice, string country, double weight)
        {
            this.name = itemName;
            this.price = itemPrice;
            this.country = country;
            this.weight = weight;
            this.id = ++numberOfItems;
        }

        public int getId() {
            return this.id;
        }

        public string getName() {
            return this.name;
        }

        public double getPrice() {
            return this.price;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

        public double getWeight()
        {
            return this.weight;
        }

        public string getCountry()
        {
            return this.country;
        }

        public string productInCatalog() {
            return this.id + ". " + this.getName() + " - $" + this.getPrice(); 
        }

       

    }
}
