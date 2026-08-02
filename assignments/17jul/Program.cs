using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopEase
{
    // ==============================
    // Models
    // ==============================

    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void UpdateProfile(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public double Discount { get; set; }
        public double Rating { get; set; }

        public void Display()
        {
            Console.WriteLine($"{ProductId,-5} {Name,-15} {Category,-10} {Brand,-10} {Price,-10} {Quantity,-5} {Discount,-5} % {Rating,-5}");
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public double Total { get; set; }
        public double Discount { get; set; }
        public double GST { get; set; }
        public double GrandTotal { get; set; }
        public DateTime Date { get; set; }

        public void GenerateInvoice()
        {
            Console.WriteLine("===================================");
            Console.WriteLine($"Order ID: {OrderId}");
            Console.WriteLine($"Customer: {Customer.Name}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine("Items:");
            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Product.Name} x{item.Quantity} = {item.Product.Price * item.Quantity}");
            }
            Console.WriteLine($"Total: {Total}");
            Console.WriteLine($"Discount: {Discount}");
            Console.WriteLine($"GST: {GST}");
            Console.WriteLine($"Grand Total: {GrandTotal}");
            Console.WriteLine("===================================");
        }
    }

    // ==============================
    // Main Program
    // ==============================
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Product> products = new List<Product>();
        static List<Order> orders = new List<Order>();
        static List<CartItem> cart = new List<CartItem>();
        static Customer loggedInCustomer = null;

        static void Main(string[] args)
        {
            AdminLogin();
            ShowMenu();
        }

        // Module 1: Authentication
        static void AdminLogin()
        {
            Console.WriteLine("Enter Admin Username:");
            string user = Console.ReadLine();
            Console.WriteLine("Enter Admin Password:");
            string pass = Console.ReadLine();

            if (user == "admin" && pass == "admin123")
                Console.WriteLine("Admin Login Successful!");
            else
            {
                Console.WriteLine("Invalid Admin Credentials!");
                Environment.Exit(0);
            }
        }

        // Main Menu
        static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("ShopEase Management System");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Manage Categories");
                Console.WriteLine("7. Shopping Cart");
                Console.WriteLine("8. Checkout & Order");
                Console.WriteLine("9. View Orders");
                Console.WriteLine("10. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: AddProduct(); break;
                    case 2: ViewProducts(); break;
                    case 3: SearchProduct(); break;
                    case 4: UpdateProduct(); break;
                    case 5: DeleteProduct(); break;
                    case 6: ManageCategories(); break;
                    case 7: ShoppingCart(); break;
                    case 8: Checkout(); break;
                    case 9: ViewOrders(); break;
                    case 10: Console.WriteLine("Thank you for using ShopEase!"); return;
                    default: Console.WriteLine("Invalid Choice."); break;
                }
            }
        }

        // Module 2: Product Management
        static void AddProduct()
        {
            Product p = new Product();
            Console.Write("Enter Product Id: "); p.ProductId = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: "); p.Name = Console.ReadLine();
            Console.Write("Enter Category: "); p.Category = Console.ReadLine();
            Console.Write("Enter Description: "); p.Description = Console.ReadLine();
            Console.Write("Enter Price: "); p.Price = double.Parse(Console.ReadLine());
            Console.Write("Enter Quantity: "); p.Quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Brand: "); p.Brand = Console.ReadLine();
            Console.Write("Enter Discount (%): "); p.Discount = double.Parse(Console.ReadLine());
            Console.Write("Enter Rating: "); p.Rating = double.Parse(Console.ReadLine());

            products.Add(p);
            Console.WriteLine("Product Added Successfully!");
        }

        static void ViewProducts()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("ID   Name            Category   Brand      Price      Qty  Disc Rating");
            Console.WriteLine("-------------------------------------------------------------");
            foreach (var p in products) p.Display();
        }

        static void SearchProduct()
        {
            Console.Write("Enter Product Id: ");
            int id = int.Parse(Console.ReadLine());
            var p = products.FirstOrDefault(x => x.ProductId == id);
            if (p != null) p.Display();
            else Console.WriteLine("Product not found.");
        }

        static void UpdateProduct()
        {
            Console.Write("Enter Product Id: ");
            int id = int.Parse(Console.ReadLine());
            var p = products.FirstOrDefault(x => x.ProductId == id);
            if (p != null)
            {
                Console.Write("Enter New Price: ");
                p.Price = double.Parse(Console.ReadLine());
                Console.Write("Enter New Quantity: ");
                p.Quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Product Updated Successfully!");
            }
            else Console.WriteLine("Product not found.");
        }

        static void DeleteProduct()
        {
            Console.Write("Enter Product Id: ");
            int id = int.Parse(Console.ReadLine());
            var p = products.FirstOrDefault(x => x.ProductId == id);
            if (p != null)
            {
                products.Remove(p);
                Console.WriteLine("Product Deleted Successfully!");
            }
            else Console.WriteLine("Product not found.");
        }

        // Module 3: Category Management (simplified)
        static void ManageCategories()
        {
            Console.WriteLine("Categories: Electronics, Books, Fashion, Sports, Furniture, Groceries");
            Console.WriteLine("Feature: Add/Delete/Update categories (extendable).");
        }

        // Module 4: Shopping Cart
        static void ShoppingCart()
        {
            Console.WriteLine("1. Add to Cart");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Clear Cart");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Product Id: ");
                    int id = int.Parse(Console.ReadLine());
                    var p = products.FirstOrDefault(x => x.ProductId == id);
                    if (p != null)
                    {
                        Console.Write("Enter Quantity: ");
                        int qty = int.Parse(Console.ReadLine());
                        cart.Add(new CartItem { Product = p, Quantity = qty });
                        Console.WriteLine("Item Added to Cart!");
                    }
                    break;
                case 2:
                    Console.Write("Enter Product Id to remove: ");
                    int rid = int.Parse(Console.ReadLine());
                    var item = cart.FirstOrDefault(x => x.Product.ProductId == rid);
                    if (item != null) { cart.Remove(item); Console.WriteLine("Item Removed!"); }
                    break;
                case 3:
                    foreach (var c in cart)
                        Console.WriteLine($"{c.Product.Name} x{c.Quantity}");
                    break;
                case 4:
                    cart.Clear();
                    Console.WriteLine("Cart Cleared!");
                    break;
            }
        }

      
                    // Module 5: Checkout & Order
        static void Checkout()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            Order order = new Order();
            order.OrderId = orders.Count + 1;
            order.Customer = new Customer { Name = "Guest", Email = "guest@shopease.com" }; // Simplified
            order.Items = new List<CartItem>(cart);
            order.Date = DateTime.Now;

            // Calculate totals
            order.Total = cart.Sum(c => c.Product.Price * c.Quantity);
            order.Discount = cart.Sum(c => (c.Product.Price * c.Quantity) * (c.Product.Discount / 100));
            order.GST = 0.18 * (order.Total - order.Discount);
            order.GrandTotal = order.Total - order.Discount + order.GST;

            // Confirm address (simplified)
            Console.WriteLine("Enter Delivery Address:");
            string address = Console.ReadLine();

            // Payment
            Console.WriteLine("Select Payment Method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Debit Card");
            Console.WriteLine("3. UPI");
            Console.WriteLine("4. Cash On Delivery");
            int payChoice = int.Parse(Console.ReadLine());

            string status = ProcessPayment(payChoice);

            if (status == "Success")
            {
                orders.Add(order);
                cart.Clear();
                Console.WriteLine("Order Placed Successfully!");
                order.GenerateInvoice();
            }
            else
            {
                Console.WriteLine($"Payment {status}. Order not placed.");
            }
        }

        // Module 6: Payment Simulation
        static string ProcessPayment(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Processing Credit Card...");
                    return "Success";
                case 2:
                    Console.WriteLine("Processing Debit Card...");
                    return "Success";
                case 3:
                    Console.WriteLine("Processing UPI...");
                    return "Success";
                case 4:
                    Console.WriteLine("Cash On Delivery selected.");
                    return "Pending"; // COD is pending until delivery
                default:
                    return "Failed";
            }
        }

        // Module 7: Order History
        static void ViewOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Customer: {order.Customer.Name}, Date: {order.Date}, Grand Total: {order.GrandTotal}");
            }

            Console.WriteLine("Enter Order ID to view details:");
            int id = int.Parse(Console.ReadLine());
            var o = orders.FirstOrDefault(x => x.OrderId == id);
            if (o != null)
            {
                o.GenerateInvoice();
                Console.WriteLine("Cancel Order? Y/N");
                string ans = Console.ReadLine();
                if (ans.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    orders.Remove(o);
                    Console.WriteLine("Order Cancelled.");
                }
            }
            else
            {
                Console.WriteLine("Order not found.");
            }
        }
    }
}


