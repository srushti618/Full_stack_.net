using System.Collections.Generic;
class Collection{
    static void Main(){
        List <string> names=new List <string>();
        names.Add("Srushti");
        names.Add("amruta");
        names.Add("achal");
        names.Add("sanskruti");
        names.Add("Sneha");
        names.Add("bhakti");
        names.Add("Shraddha");

        names.Add("astha");
        foreach(string n in names){
            Console.WriteLine(n);
        }
    }
} 
// Scenario array
// A company stores the monthly sales (in ₹) of 6 employees in an array. Display all sales, calculate the total sales, average sales, highest sales, and lowest sales.
// Scenario list coln
// A library stores the names of available books in a List. Display all books, add one new book, remove one old book, and display the updated list along with the total number of books.