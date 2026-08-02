namespace StationeryStore
{
    class Program
    {
        static List<StationeryItem> items = new List<StationeryItem>();

        static void Main(string[] args)
        {
            try
            {
                Login();
                ShowMenu();
            }
            catch (LoginFailedException)
            {
                Console.WriteLine("Login failed after 3 attempts. Exiting...");
            }
        }

        static void Login()
        {
            int attempts = 3;
            while (attempts > 0)
            {
                Console.WriteLine("Enter Username:");
                string user = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                string pass = Console.ReadLine();

                if (user == "admin" && pass == "admin123")
                {
                    Console.WriteLine("Login Successful!");
                    return;
                }
                else
                {
                    attempts--;
                    Console.WriteLine($"Invalid Login. Attempts Left: {attempts}");
                }
            }
            throw new LoginFailedException();
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Stationery Store Management System");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1. Add Stationery Item");
                Console.WriteLine("2. Display All Items");
                Console.WriteLine("3. Search Item");
                Console.WriteLine("4. Update Item");
                Console.WriteLine("5. Delete Item");
                Console.WriteLine("6. Purchase Item");
                Console.WriteLine("7. View Low Stock Items");
                Console.WriteLine("8. Sort Items");
                Console.WriteLine("9. Exit");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: AddItem(); break;
                    case 2: DisplayItems(); break;
                    case 3: SearchItem(); break;
                    case 4: UpdateItem(); break;
                    case 5: DeleteItem(); break;
                    case 6: PurchaseItem(); break;
                    case 7: LowStock(); break;
                    case 8: SortItems(); break;
                    case 9: Console.WriteLine("Thank You. Visit Again."); return;
                    default: Console.WriteLine("Invalid Choice."); break;
                }
            }
        }

        // Module 6: Add Item
        static void AddItem()
        {
            Console.WriteLine("Enter Item Id:");
            int id = int.Parse(Console.ReadLine());
            if (items.Any(x => x.ItemId == id)) throw new DuplicateItemException();

            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Category:");
            string category = Console.ReadLine();
            Console.WriteLine("Enter Brand:");
            string brand = Console.ReadLine();
            Console.WriteLine("Enter Price:");
            double price = double.Parse(Console.ReadLine());
            if (price <= 0) throw new InvalidPriceException();
            Console.WriteLine("Enter Quantity:");
            int qty = int.Parse(Console.ReadLine());
            if (qty <= 0) throw new InvalidQuantityException();

            StationeryItem item = new StationeryItem
            {
                ItemId = id,
                ItemName = name,
                Category = category,
                Brand = brand,
                Price = price,
                Quantity = qty
            };
            items.Add(item);
            Console.WriteLine("Item Added Successfully!");
        }

        // Module 7: Display Items
        static void DisplayItems()
        {
            foreach (var item in items) item.DisplayDetails();
        }

        // Module 8: Search Item
        static void SearchItem()
        {
            Console.WriteLine("Enter Item Id or Name:");
            string input = Console.ReadLine();
            StationeryItem item = items.FirstOrDefault(x => x.ItemId.ToString() == input || x.ItemName == input);
            if (item == null) throw new ItemNotFoundException();
            item.DisplayDetails();
        }

        // Module 9: Update Item
        static void UpdateItem()
        {
            Console.WriteLine("Enter Item Id:");
            int id = int.Parse(Console.ReadLine());
            StationeryItem item = items.FirstOrDefault(x => x.ItemId == id);
            if (item == null) throw new ItemNotFoundException();

            Console.WriteLine("Enter New Price:");
            item.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Quantity:");
            item.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Brand:");
            item.Brand = Console.ReadLine();

            Console.WriteLine("Item Updated Successfully!");
        }

        // Module 10: Delete Item
        static void DeleteItem()
        {
            Console.WriteLine("Enter Item Id to delete:");
            int id = int.Parse(Console.ReadLine());
            StationeryItem item = items.FirstOrDefault(x => x.ItemId == id);
            if (item == null) throw new ItemNotFoundException();

            Console.WriteLine("Delete ? Y/N");
            string confirm = Console.ReadLine();
            if (confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                items.Remove(item);
                Console.WriteLine("Item Deleted Successfully!");
            }
            else Console.WriteLine("Delete Cancelled.");
        }

       

        // Module 11: Purchase Item
        static void PurchaseItem()
        {
            Console.WriteLine("Enter Item Id:");
            int id = int.Parse(Console.ReadLine());
            StationeryItem item = items.FirstOrDefault(x => x.ItemId == id);
            if (item == null) throw new ItemNotFoundException();

            Console.WriteLine("Enter Quantity:");
            int qty = int.Parse(Console.ReadLine());
            if (qty > item.Quantity) throw new InsufficientStockException();

            item.Quantity -= qty;

            Billing bill = new Billing();
            bill.GenerateBill(item, qty);
        }

        // Module 12: Low Stock
        static void LowStock()
        {
            var lowStockItems = items.Where(x => x.Quantity < 5).ToList();
            if (lowStockItems.Count == 0)
            {
                Console.WriteLine("No low stock items.");
                return;
            }
            Console.WriteLine("Low Stock Items:");
            foreach (var item in lowStockItems) item.DisplayDetails();
        }

        // Module 13: Sorting
        static void SortItems()
        {
            Console.WriteLine("Sort By: 1.Price 2.Name 3.Quantity");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var byPrice = items.OrderBy(x => x.Price).ToList();
                    foreach (var item in byPrice) item.DisplayDetails();
                    break;
                case 2:
                    var byName = items.OrderBy(x => x.ItemName).ToList();
                    foreach (var item in byName) item.DisplayDetails();
                    break;
                case 3:
                    var byQty = items.OrderByDescending(x => x.Quantity).ToList();
                    foreach (var item in byQty) item.DisplayDetails();
                    break;
                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }
        }
    }
}
