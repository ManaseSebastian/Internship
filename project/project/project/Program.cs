using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<ShippingRate> shippingRates = new List<ShippingRate>();
            ShoppingCart cart;
            int option = -1;

            products.Add(new Product("Mouse", 10.99, "RO", 0.2));
            products.Add(new Product("Keyboard", 40.99, "UK", 0.7));
            products.Add(new Product("Monitor", 164.99, "US", 1.9));
            products.Add(new Product("Webcam", 84.99, "RO", 0.2));
            products.Add(new Product("Headphones", 59.99, "US", 0.6));
            products.Add(new Product("Desk Lamp", 89.99, "UK", 1.3));       
            shippingRates.Add(new ShippingRate("RO", 1));
            shippingRates.Add(new ShippingRate("UK", 2));
            shippingRates.Add(new ShippingRate("US", 3));
            cart = new ShoppingCart();
            do
            {
                Console.Clear();
                Console.WriteLine("List of products: ");
                foreach (Product product in products)
                {
                    Console.WriteLine(product.productInCatalog());
                }
               
                int numberTypesOfProducts = Product.numberOfItems + 1;
                Console.WriteLine("Press " + numberTypesOfProducts + " for exit.");
                Console.WriteLine();
                Console.Write("Select an Item: ");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                    if (option > numberTypesOfProducts)
                    {
                        Console.WriteLine("Select a number from [" + 1 + "," + numberTypesOfProducts + "]");
                    }
                    else {
                        if (option != 7) {
                            cart.indexOfproducts[option - 1]++;
                            cart.diplayProducts(products);
                            double subtotal = cart.getSubtotal(products);
                            double shipping = cart.getShipping(products, shippingRates);
                            Console.WriteLine("Subtotal: ${0}", subtotal);
                            Console.WriteLine("Shipping: ${0}", shipping);
                            Console.WriteLine("VAT:${0}",subtotal*0.19);
                            Console.WriteLine();
                            Console.WriteLine("Total: $ {0}", cart.getTotalWithPromotions(products) + subtotal * 0.19);      
                        }
                    }
                }
                catch (FormatException ex) {
                    Console.WriteLine("Insert just numbers!" + ex.Message);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            } while (option != (Product.numberOfItems + 1));
        }
    }
}
