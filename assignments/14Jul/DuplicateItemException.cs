public class DuplicateItemException : Exception 
{
    public DuplicateItemException() : base("Item with same ID already exists.") { }
}