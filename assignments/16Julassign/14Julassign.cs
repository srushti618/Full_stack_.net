using System;
using System.Collections.Generic;
using System.Linq;

// -------------------- Custom Exceptions --------------------
public class InvalidPriceException : Exception
{
    public InvalidPriceException() : base("Price must be greater than 0.") { }
}
public class InvalidQuantityException : Exception
{
    public InvalidQuantityException() : base("Quantity must be greater than 0.") { }
}
public class DuplicateItemException : Exception
{
    public DuplicateItemException() : base("Item ID already exists.") { }
}
public class ItemNotFoundException : Exception
{
    public ItemNotFoundException() : base("Item not found.") { }
}
public class InsufficientStockException : Exception
{
    public InsufficientStockException() : base("Insufficient stock available.") { }
}
public class LoginFailedException : Exception
{
    public LoginFailedException() : base("Login failed after 3 attempts.") { }
}

// -------------------- Abstraction --------------------
public abstract class Product
{
    public abstract double CalculateDiscount(double price, int qty);
}

// -------------------- Interface --------------------
public interface IBill
{
    void GenerateBill(StationeryItem item, int qty);
}

// -------------------- Parent Class --------------------
public class StationeryItem : Product
{
    private int quantity;
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public string Brand { get; set; }

    public int Quantity
    {
        get { return quantity; }
        set
        {
            if (value <= 0) throw new InvalidQuantityException();
            quantity = value;
        }
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"{ItemId} | {ItemName} | {Category} | {Brand} | Rs.{Price} | Qty:{Quantity}");
    }

    public void UpdateQuantity(int qty)
    {
        if (qty <= 0) throw new InvalidQuantityException();
        Quantity = qty;
    }

    public override double CalculateDiscount(double price, int qty)
    {
        return 0; // base class default
    }
}

// -------------------- Child Classes --------------------
public class Notebook : StationeryItem
{
    public int Pages { get; set; }
    public string PaperType { get; set; }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Pages:{Pages}, PaperType:{PaperType}");
    }

    public override double CalculateDiscount(double price, int qty)
    {
        return 0.10 * price * qty; // 10% discount
    }
}

public class Pen : StationeryItem
{
    public string InkColor { get; set; }
    public string PenType { get; set; }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"InkColor:{InkColor}, PenType:{PenType}");
    }

    public override double CalculateDiscount(double price, int qty)
    {
        return 0.05 * price * qty; // 5% discount
    }
}

public class Marker : StationeryItem
{
    public bool Permanent { get; set; }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Permanent:{Permanent}");
    }

    public override double CalculateDiscount(double price, int qty)
    {
        return 0.08 * price * qty; // 8% discount
    }
}

// -------------------- Billing --------------------
public class Billing : IBill
{
    public void GenerateBill(StationeryItem item, int qty)
    {
        double total = item.Price * qty;
        double discount = item.CalculateDiscount(item.Price, qty);
        double gst = 0.18 * (total - discount);
        double final = total - discount + gst;

        Console.WriteLine("--------------------------------");
        Console.WriteLine("Item\tPrice\tQty\tDiscount\tGST\tTotal");
        Console.WriteLine($"{item.ItemName}\t{item.Price}\t{qty}\t{discount}\t{gst}\t{final}");
        Console.WriteLine("--------------------------------");
    }
}

// -------------------- Main Program --------------------
class 14Julassign
{
    static List<StationeryItem> items = new List<StationeryItem>();

    static void Main(string[] args)
    {
        // Module 1: Login
        int attempts = 0;
        while (attempts < 3)
        {
            Console.WriteLine("Enter Username:");
            string user = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string pass = Console.ReadLine();

            if (user == "admin" && pass == "admin123")
            {
                Console.WriteLine("\nLogin Successful!\n");
                ShowMenu();
                return;
            }
            else
            {
                attempts++;
                Console.WriteLine($"Invalid Login. Attempts Left: {3 - attempts}");
            }
        }
        throw new LoginFailedException();
    }

    static void ShowMenu()
    {
        int choice;
        do
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
            Console.WriteLine("Enter Choice:");
            choice = int.Parse(Console.ReadLine());

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
                case 9: Console.WriteLine("Thank You. Visit Again!"); break;
                default: Console.WriteLine("Invalid Choice."); break;
            }
        } while (choice != 9);
    }

    // -------------------- Module 6: Add Item --------------------
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

    // -------------------- Module 7: Display Items --------------------
    static void DisplayItems()
    {
        foreach (var item in items)
        {
            item.DisplayDetails();
        }
    }

    // -------------------- Module 8: Search Item --------------------
    static void SearchItem()
    {
        Console.WriteLine("Search by (1) ID or (2) Name:");
        int opt = int.Parse(Console.ReadLine());
        StationeryItem found = null;

        if (opt == 1)
        {
            Console.WriteLine("Enter Item Id:");
            int id = int.Parse(Console.ReadLine());
            found = items.FirstOrDefault(x => x.ItemId == id);
        }
        else
        {
            Console.WriteLine("Enter Item Name:");
            string name = Console.ReadLine();
            found = items.FirstOrDefault(x => x.ItemName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        if (found == null) throw new ItemNotFoundException();
        found.DisplayDetails();
    }

    // -------------------- Module 9: Update Item --------------------
    static void UpdateItem()
    {
        Console.WriteLine("Enter Item Id to update:");
        int id = int.Parse(Console.ReadLine());
        StationeryItem item = items.FirstOrDefault(x => x.ItemId == id);
        if (item == null) throw new ItemNotFoundException();

        Console.WriteLine("Enter new Price:");
        double price = double.Parse(Console.ReadLine());
        if (price <= 0) throw new InvalidPriceException();
        item.Price = price;

        Console.WriteLine("Enter new Quantity:");
        int qty = int.Parse(Console.ReadLine());
        if (qty <= 0) throw new InvalidQuantityException();
        item.Quantity = qty;

        Console.WriteLine("Enter new Brand:");
        item.Brand = Console.ReadLine();

        Console.WriteLine("Item Updated Successfully!");
    }

    
        // -------------------- Module 10: Delete Item --------------------
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
        else
        {
            Console.WriteLine("Delete Cancelled.");
        }
    }

    // -------------------- Module 11: Purchase Item --------------------
    static void PurchaseItem()
    {
        Console.WriteLine("Enter Item Id to purchase:");
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

    // -------------------- Module 12: Low Stock --------------------
    static void LowStock()
    {
        Console.WriteLine("Items with Quantity < 5:");
        var lowStockItems = items.Where(x => x.Quantity < 5).ToList();
        if (lowStockItems.Count == 0)
        {
            Console.WriteLine("No low stock items.");
        }
        else
        {
            foreach (var item in lowStockItems)
            {
                item.DisplayDetails();
            }
        }
    }

    // -------------------- Module 13: Sorting --------------------
    static void SortItems()
    {
        Console.WriteLine("Sort by: 1.Price  2.Name  3.Quantity");
        int opt = int.Parse(Console.ReadLine());

        switch (opt)
        {
            case 1:
                var sortedByPrice = items.OrderBy(x => x.Price).ToList();
                foreach (var item in sortedByPrice) item.DisplayDetails();
                break;
            case 2:
                var sortedByName = items.OrderBy(x => x.ItemName).ToList();
                foreach (var item in sortedByName) item.DisplayDetails();
                break;
            case 3:
                var sortedByQty = items.OrderByDescending(x => x.Quantity).ToList();
                foreach (var item in sortedByQty) item.DisplayDetails();
                break;
            default:
                Console.WriteLine("Invalid Option.");
                break;
        }
    }
}
