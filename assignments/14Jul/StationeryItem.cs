namespace StationeryStore
{
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
            Console.WriteLine($"{ItemId} | {ItemName} | {Category} | {Brand} | {Price} | {Quantity}");
        }

        public void UpdateQuantity(int qty)
        {
            if (qty <= 0) throw new InvalidQuantityException();
            Quantity = qty;
        }

        public override double CalculateDiscount(double price, int qty)
        {
            return 0; // Default, overridden in child classes
        }
    }

    public class Notebook : StationeryItem
    {
        public int Pages { get; set; }
        public string PaperType { get; set; }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Pages: {Pages}, PaperType: {PaperType}");
        }

        public override double CalculateDiscount(double price, int qty)
        {
            return price * qty * 0.10; // 10% discount
        }
    }

    public class Pen : StationeryItem
    {
        public string InkColor { get; set; }
        public string PenType { get; set; }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"InkColor: {InkColor}, PenType: {PenType}");
        }

        public override double CalculateDiscount(double price, int qty)
        {
            return price * qty * 0.05; // 5% discount
        }
    }

    public class Marker : StationeryItem
    {
        public bool Permanent { get; set; }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Permanent: {Permanent}");
        }

        public override double CalculateDiscount(double price, int qty)
        {
            return price * qty * 0.08; // 8% discount
        }
    }
}
