namespace StationeryStore
{
    public abstract class Product
    {
        public abstract double CalculateDiscount(double price, int qty);
    }

    public interface IBill
    {
        void GenerateBill(StationeryItem item, int qty);
    }
}
