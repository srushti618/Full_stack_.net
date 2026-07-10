using System;

class CompiletimePoly
{
    // Overloaded methods
    public void Search(int id)
    {
        Console.WriteLine($"Search by employee id {id}");
    }

    public void Search(string firstname, string lastname)
    {
        Console.WriteLine($"Search by name {firstname} {lastname}");
    }

    public void Search(long phone)
    {
        Console.WriteLine($"Search by phone {phone}");
    }

    static void Main()
    {
        CompiletimePoly obj = new CompiletimePoly();

        obj.Search(12);                        // calls int version
        obj.Search("Srushti", "Patil");        // calls string version
        obj.Search(9876543210);                // calls long version
    }
}
