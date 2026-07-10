using System;
public class Invalidage : Exception
{
    public Invalidage(string message) : base(message)
    {
        Console.WriteLine($"The exception is : {message}");
    }
}