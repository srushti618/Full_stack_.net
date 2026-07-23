using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopEase
{
    // -------------------- Models --------------------
    class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    class Admin
    {
        public string Username { get; set; } = "admin";
        public string Password { get; set; } = "admin123";
    }

    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public double Discount { get; set; } // percentage
        public double Rating { get; set; }

        public void Display()
        {
            Console.WriteLine($"{ProductId,-5} {Name,-15} {Category,-12} {Brand,-10} Rs.{Price,-10} Qty:{Quantity}");
        }
    }

    class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public List<CartItem> Items { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public double GST { get; set; }
        public double GrandTotal { get; set; }
    }

    // -------------------- Services --------------------
    class AuthService
    {
        private List<Customer> customers = new List<Customer>();
        private Admin admin = new Admin();

        public Customer Register(string name, string email, string password)
        {
            var c = new Customer { CustomerId = customers.Count + 1, Name = name, Email = email, Password = password };
            customers.Add(c);
            return c;
        }

        public Customer LoginCustomer(string email, string password)
        {
            return customers.FirstOrDefault(c => c.Email == email && c.Password == password);
        }

        public bool LoginAdmin(string username, string password)
        {
            return username == admin.Username && password == admin.Password;
        }
    }

    class ProductService
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product p)
        {
            if (products.Any(x => x.ProductId == p.ProductId))
                throw new Exception("Duplicate Product ID");
            if (p.Price <= 0) throw new Exception("Invalid Price");
            if (p.Quantity <= 0) throw new Exception("Invalid Quantity");
            products.Add(p);
        }

        public void UpdateProduct(int id, double newPrice, int newQty)
        {
            var p = products.FirstOrDefault(x => x.ProductId == id);
            if (p == null) throw new Exception("Product Not Found");
            p.Price = newPrice;
            p.Quantity = newQty;
        }

        public void DeleteProduct(int id)
        {
            var p = products.FirstOrDefault(x => x.ProductId == id);
            if (p == null) throw new Exception("Product Not Found");
            products.Remove(p);
        }

        public Product SearchProduct(int id)
        {
            return products.FirstOrDefault(x => x.ProductId == id);
        }

        public void ViewAllProducts()
        {
            Console.WriteLine("ID   Name            Category     Brand      Price      Qty");
            foreach (var p in products) p.Display();
        }

        public List<Product> GetProducts() => products;
    }

    class CartService
    {
        private List<CartItem> cart = new List<CartItem>();

        public void AddToCart(Product p, int qty)
        {
            if (qty > p.Quantity) throw new Exception("Insufficient Stock");
            var existing = cart.FirstOrDefault(x => x.Product.ProductId == p.ProductId);
            if (existing != null) existing.Quantity += qty;
            else cart.Add(new CartItem { Product = p, Quantity = qty });
        }

        public void ViewCart()
        {
            Console.WriteLine("Cart:");
            foreach (var item in cart)
                Console.WriteLine($"{item.Product.Name} x{item.Quantity}");
        }

        public List<CartItem> GetCart() => cart;
        public void ClearCart() => cart.Clear();
    }

    class OrderService
    {
        private List<Order> orders = new List<Order>();
        private int orderCounter = 1000;

        public Order PlaceOrder(Customer c, List<CartItem> cart)
        {
            double total = cart.Sum(x => x.Product.Price * x.Quantity);
            double discount = cart.Sum(x => (x.Product.Discount / 100) * x.Product.Price * x.Quantity);
            double gst = 0.18 * (total - discount);
            double grandTotal = total - discount + gst;

            var order = new Order
            {
                OrderId = ++orderCounter,
                Date = DateTime.Now,
                Customer = c,
                Items = cart,
                Total = total,
                Discount = discount,
                GST = gst,
                GrandTotal = grandTotal
            };
            orders.Add(order);
            return order;
        }

        public void ViewOrders(Customer c)
        {
            var custOrders = orders.Where(o => o.Customer.CustomerId == c.CustomerId);
            foreach (var o in custOrders)
            {
                Console.WriteLine($"Order {o.OrderId} | Date:{o.Date} | Total:{o.GrandTotal}");
            }
        }
    }

    class PaymentService
    {
        public void ProcessPayment(string method)
        {
            switch (method.ToLower())
            {
                case "credit card":
                case "debit card":
                case "upi":
                case "cod":
                    Console.WriteLine("Payment Successful");
                    break;
                default:
                    Console.WriteLine("Payment Failed");
                    break;
            }
        }
    }

    // -------------------- Main Program --------------------
    class 17Julassign
    {
        static void Main(string[] args)
        {
            AuthService auth = new AuthService();
            ProductService productService = new ProductService();
            CartService cartService = new CartService();
            OrderService orderService = new OrderService();
            PaymentService paymentService = new PaymentService();

            // Demo flow
            var cust = auth.Register("Rahul", "rahul@mail.com", "pass123");
            var login = auth.LoginCustomer("rahul@mail.com", "pass123");
            Console.WriteLine($"Welcome {login.Name}");

            productService.AddProduct(new Product { ProductId = 1001, Name = "Laptop", Category = "Electronics", Description = "Dell Inspiron", Price = 65000, Quantity = 20, Brand = "Dell", Discount = 10, Rating = 4.6 });
            productService.ViewAllProducts();

            cartService.AddToCart(productService.SearchProduct(1001), 2);
            cartService.ViewCart();

            var order = orderService.PlaceOrder(login, cartService.GetCart());
            Console.WriteLine($"Order Placed: {order.OrderId}, Grand Total: {order.GrandTotal}");

            paymentService.ProcessPayment("Credit Card");
            orderService.ViewOrders(login);
        }
    }
}
