using System;
using System.Collections.Generic;

namespace ShoppingApp
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }

    class Jul13assign
    {
        static void Main(string[] args)
        {
            // Step 1: Registration
            Customer customer = new Customer();
            Console.WriteLine("Enter Customer ID:");
            customer.CustomerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Name:");
            customer.Name = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            customer.Email = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            customer.Password = Console.ReadLine();

            Console.WriteLine("Registration Successful!\n");

            // Step 2: Login
            int attempts = 0;
            bool loggedIn = false;
            while (attempts < 3)
            {
                Console.WriteLine("Enter Email:");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                string password = Console.ReadLine();

                if (email == customer.Email && password == customer.Password)
                {
                    Console.WriteLine($"Welcome {customer.Name}\n");
                    loggedIn = true;
                    break;
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Invalid credentials.");
                }
            }
            if (!loggedIn)
            {
                Console.WriteLine("Account Locked.");
                return;
            }

            // Step 3: Product Management
            List<Product> products = new List<Product>();
            Console.WriteLine("How many products do you want to add?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Product p = new Product();
                Console.WriteLine("Enter Product ID:");
                p.ProductId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Product Name:");
                p.ProductName = Console.ReadLine();

                Console.WriteLine("Enter Price:");
                p.Price = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Stock:");
                p.Stock = int.Parse(Console.ReadLine());

                products.Add(p);
            }

            Console.WriteLine("\nAvailable Products:");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductId} - {p.ProductName} - Rs.{p.Price} - Stock:{p.Stock}");
            }

            // Step 4: Search Product
            Console.WriteLine("\nEnter product name to search:");
            string searchName = Console.ReadLine();
            Product found = products.Find(x => x.ProductName.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (found != null)
            {
                Console.WriteLine("Product Found:");
                Console.WriteLine($"ID:{found.ProductId}, Name:{found.ProductName}, Price:{found.Price}, Stock:{found.Stock}");
            }
            else
            {
                Console.WriteLine("Product Not Found");
            }

            // Step 5: Cart System
            Dictionary<Product, int> cart = new Dictionary<Product, int>();
            string choice;
            do
            {
                Console.WriteLine("\nEnter Product ID to add to cart:");
                int pid = int.Parse(Console.ReadLine());
                Product prod = products.Find(x => x.ProductId == pid);

                if (prod != null)
                {
                    Console.WriteLine("Enter Quantity:");
                    int qty = int.Parse(Console.ReadLine());

                    if (qty <= prod.Stock)
                    {
                        prod.Stock -= qty;
                        if (cart.ContainsKey(prod))
                            cart[prod] += qty;
                        else
                            cart.Add(prod, qty);

                        Console.WriteLine("Added to cart.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient stock.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Product ID.");
                }

                Console.WriteLine("Do you want to add another product? (Yes/No)");
                choice = Console.ReadLine();
            } while (choice.Equals("Yes", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("\nCart:");
            foreach (var item in cart)
            {
                Console.WriteLine($"{item.Key.ProductName} x{item.Value}");
            }

            // Step 6: Billing
            double total = 0;
            foreach (var item in cart)
            {
                total += item.Key.Price * item.Value;
            }

            double discount = 0;
            if (total >= 1000 && total <= 4999) discount = 0.10 * total;
            else if (total >= 5000 && total <= 9999) discount = 0.20 * total;
            else if (total >= 10000) discount = 0.30 * total;

            double finalAmount = total - discount;

            Console.WriteLine($"\nTotal Amount: Rs.{total}");
            Console.WriteLine($"Discount: Rs.{discount}");
            Console.WriteLine($"Final Amount: Rs.{finalAmount}");

            // Step 7: Payment
            Console.WriteLine("\nChoose Payment Method:");
            Console.WriteLine("1. UPI\n2. Credit Card\n3. Debit Card\n4. Cash on Delivery");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    Console.WriteLine("Payment Successful");
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
    }
}
