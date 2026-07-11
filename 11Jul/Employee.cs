using System;
using System.Collections.Generic;
using System.Linq;
 public class Employee{

    public int Id { get; set; }
    public string Name { get; set; }
    public double salary { get; set; }


public Employee(int i,string m,double s)
{
    Id = i;
    Name = m ?? "Unknown"; 
    salary = s;
}
public virtual double GetSalary()
{
    return salary * 12 ;
}
public virtual void Display()
{
    Console.WriteLine("Id: " + Id);
    Console.WriteLine("Name: " + Name);
    Console.WriteLine("Salary: " + salary);
    Console.WriteLine("Annual Salary: " + GetSalary());
    Console.WriteLine("-----------------------------");
}
}
