// using System;
// class Jul8assign{
//     static void Main(){
//Scenario array
// A company stores the monthly sales (in ₹) of 6 employees in an array. Display all sales, calculate the total sales, average sales, highest sales, and lowest sales.

// int [] sales={ 10000,20000,10000,30000,40000,20000};
// int totalsales=0;

// int highestsale=int.MinValue;
// int lowestsale=int.MaxValue;


// foreach(int salesop in sales){
//     Console.WriteLine($"The Sales are as Follows : {salesop}");
//     totalsales+=salesop;
//     if(highestsale<salesop){
//         highestsale=salesop;
//     }
//     if(lowestsale>salesop){
//         lowestsale=salesop;
//     }
// }

// int averagesales=(totalsales/6);
// Console.WriteLine($"The total sales is : {totalsales}");
// Console.WriteLine($"The Average sales  is : {averagesales}");
// Console.WriteLine($"The highest sales is : {highestsale}");
// Console.WriteLine($"The lowest sales is : {lowestsale}");





// Scenario list coln
// A library stores the names of available books in a List. Display all books, add one new book, remove one old book, and display the updated list along with the total number of books.
   




//    List <string> books=new List <string>();
//    books.Add("Wing of fire");
//    books.Add("Wise and otherwise");
//    books.Add("Atomic habits");
//    books.Add("The 5 AM club");
//    books.Add("The art of letting go");
//     books.Add("You become what you think");
//         Console.WriteLine("Original list of books:");
// foreach(string bookname in books){
//     Console.WriteLine(bookname);

// }

// int totalnobook=0;
//    books.Add("you can");
//    books.Remove("You become what you think");
//    Console.WriteLine("\nUpdated list of books:");

// foreach(string booknameall in books){
//     Console.WriteLine(booknameall);
//     totalnobook++;

// }
// Console.WriteLine($"The total number of books is : {totalnobook}");
   
//     }
// }