namespace StationeryStore
{
    public class Billing : IBill
    {
        public void GenerateBill(StationeryItem item, int qty)
        {
            double total = item.Price * qty;
            double discount = item.CalculateDiscount(item.Price, qty);
            double gst = 0.18 * (total - discount);
            double finalAmount = total - discount + gst;

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Item: {item.ItemName}");
            Console.WriteLine($"Price: {item.Price}");
            Console.WriteLine($"Quantity: {qty}");
            Console.WriteLine($"Discount: {discount}");
            Console.WriteLine($"GST: {gst}");
            Console.WriteLine($"Total: {finalAmount}");
            Console.WriteLine("--------------------------------");
        }
    }
}
