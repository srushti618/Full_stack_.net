// using System;
// class Manager : Employee
// {
//     public string Department ;
//     public double bonus;

//     public Manager(int id, string name, double salary, string department,double b)
//         : base(id, name, salary)
//     {
//         Department = department;
//         bonus = b;
//     }

//    public override double GetSalary()
//     {
//         return base.GetSalary() + bonus;
//     }

//     public override void Display()
//     {
//         base.Display();
//         Console.WriteLine("Department: " + Department);
//         Console.WriteLine("Bonus: " + bonus);
//         Console.WriteLine("-----------------------------");
//     }

// }