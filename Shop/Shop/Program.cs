using System;
using System.Collections.Generic;
using System.Globalization;
using Shop.Entities;
using Shop.Entities.Enums;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Enter the client data:");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Bith Date (DD/MM/YYYY): ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());
            
            Console.WriteLine();

            Order order = new Order
            {
                Moment = DateTime.Now,
                Status = OrderStatus.Processing,
                Client = new Client(clientName, email, birthdate)
            };

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            Console.WriteLine(order.Status.ToString());

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                
                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine());

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);
                OrderItem orderItem = new OrderItem(quantity, productPrice, product);

                order.AddItem(orderItem);

                Console.WriteLine();
            }

            Console.WriteLine(order.ToString());
            */

            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Product #" + i + " data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                String name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (type == 'c')
                {
                    list.Add(new Product(name, price));
                }
                else if (type == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, date));
                }
                else
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, customsFee));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach (Product prod in list)
            {
                Console.WriteLine(prod.PriceTag());
            }

        }
    }
}
