using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class ShoppingCart
    {
        public int[] indexOfproducts { get; }
        private double subtotal;
        private double shipping;

        public ShoppingCart() {
            indexOfproducts = new int[Product.numberOfItems + 1];
        }

        public double getSubtotal(List<Product> products) {
            this.subtotal = 0;
            foreach (Product product in this.getProductsFromCart(products))
            {
               this.subtotal = this.subtotal + product.getPrice() * indexOfproducts[product.getId()-1];
            }
            return this.subtotal;
        }

        private List<Product> getProductsFromCart(List<Product> products) {
            List<Product> productsFromCart = new List<Product>();
            for (int index = 0; index < indexOfproducts.Length; index++)
            {
                if (this.indexOfproducts[index] != 0)
                {
                    productsFromCart.Add(products[index]);
                }
            }
            return productsFromCart;
        }

        public void diplayProducts(List<Product> products)
        {
            foreach (Product product in getProductsFromCart(products))
            {
                Console.WriteLine(product.getName() + " X " + this.indexOfproducts[product.getId()-1]);
            }
        }

        public double getShipping(List<Product> products, List<ShippingRate> shippingRate) {
            this.shipping = 0;
            foreach (Product product in getProductsFromCart(products)) {
                foreach (ShippingRate rate in shippingRate) {
                    if (product.getCountry() == rate.getCountry()) {
                        this.shipping = this.shipping + (product.getWeight() / 0.1) * rate.getRate() * this.indexOfproducts[product.getId() - 1];
                    }
                }
            }
            return this.shipping;
        }

        public double getTotalWithPromotions(List<Product> products)
        {
            int numberOfKeyBoards = this.indexOfproducts[this.getIdByName(products, "Keyboard")-1];

            double promotionKeyboard = 0;
            bool sem = false;
            while (numberOfKeyBoards != 0)
            {
                promotionKeyboard = promotionKeyboard + 0.1 * this.getPriceByName(products, "Keyboard");
                numberOfKeyBoards--;
                sem = true;
            }

            if (sem)
            {
                Console.WriteLine("10% off keyboards: -${0}", promotionKeyboard);
            }
           
            int numberOfMonitors = this.indexOfproducts[this.getIdByName(products,"Monitor") - 1];
            int numberOfLamps = this.indexOfproducts[this.getIdByName(products, "Desk Lamp") - 1];
            double priceLamp = this.getPriceByName(products, "Desk Lamp");
            double promotion = 0;
            sem = false;
            while ((numberOfLamps > 0) && (numberOfMonitors >= 2))
            {
                promotion = promotion + priceLamp / 2;
                numberOfLamps--;
                numberOfMonitors -= 2;
                sem = true;
            }
            if (sem)
            {
                Console.WriteLine("{0}$ off Desk Lamp", promotion);
            }

            if (this.getProductsFromCart(products).Count >= 2)
            {
                this.shipping = this.shipping - 10;
                Console.WriteLine("10$ off shipping: -${0}", 10);
            }
            double total = 0;
            total = this.subtotal + this.shipping - promotion - promotionKeyboard;          
            return total;
        }

       public int getIdByName(List<Product> products, string name) {
            foreach (Product product in products) {
                if (name == product.getName()) {
                    return product.getId();
                }
            }
            return -1;
        }

        private double getPriceByName(List<Product> products, string name)
        {
            foreach (Product product in products)
            {
                if (name == product.getName())
                {
                    return product.getPrice();
                }
            }
            return -1;
        }
    }
}
