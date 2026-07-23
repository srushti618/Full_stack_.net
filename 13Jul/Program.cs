using System;
class Program
{
    //oc example
 public void Pay(string method)
    {
        if(method == "CreditCard")
        {
            Console.WriteLine("Paying with Credit Card");
        }
        else if(method == "UPI")
        {
            Console.WriteLine("Paying with UPI");
        }
        else if(method == "cash")
        {
            Console.WriteLine("Paying with Cash");
        }
        else
        {
            Console.WriteLine("Payment method not supported");
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
