public class InsufficientStockException : Exception 
{
    public InsufficientStockException() : base("Purchase quantity exceeds available stock.") { }
}