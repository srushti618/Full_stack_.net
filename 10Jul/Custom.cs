using System;
using System.Security.Cryptography;
class Custom{
    static void checkage(int age){
        if(age<18){
            throw new Invalidage("Age is less than 18");
        }
        else{
            Console.WriteLine($"The age is : {age}");
        }
    }

    static void Main(){
        
        try{
           Console.WriteLine("Enter the age : ");
           int age=Convert.ToInt32(Console.ReadLine());
           checkage(age);
        }
        catch(Invalidage e){
            Console.WriteLine($"The exception is : {e.Message}");
        }
        catch(FormatException e){
            Console.WriteLine($"The exception is : {e.Message}");
        }
       
    }
}