public class ItemNotFoundException : Exception 
{
    public ItemNotFoundException() : base("Item not found.") { }
}