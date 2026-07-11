// using System;
// using System.Collections.Generic;
// using System.Linq;
// class Program
// {
//     static void Main(string[] args)
//     {
//         List<Employee> employees = new List<Employee>();
//         List<Manager> managers = new List<Manager>();

//         while (true)
//         {
//             Console.WriteLine("Welcome to Employee Management System");
//             Console.WriteLine("1. Add Employee");
//             Console.WriteLine("2. Add Managers");
//             Console.WriteLine("3. Display Employees");
//             Console.WriteLine("4. Display Managers");
//             Console.WriteLine("5. Search Employee by Id");
//             Console.WriteLine("6. Exit");
//             Console.Write("Enter your choice 1-6 :  ");

//             try
//             {
//                 int choice = Convert.ToInt32(Console.ReadLine());
//                 switch (choice)
//                 {
//                     case 1:
//                         Console.Write("Enter Employee Id: ");
//                         int id = Convert.ToInt32(Console.ReadLine());
//                         bool exists = employees.Any(e => e.Id == id);
//                         if (exists)
//                         {
//                             Console.WriteLine("Employee with this Id already exists. Please enter a unique Id.");
//                             break;
//                         }
//                         Console.Write("Enter Employee Name: ");
//                         string name = Console.ReadLine();
//                         Console.Write("Enter Employee Salary: ");
//                         double salary = Convert.ToDouble(Console.ReadLine());
//                         Employee newEmployee = new Employee(id, name, salary);
//                         employees.Add(newEmployee);
//                         Console.WriteLine("Employee added successfully.");
//                         break;
//                     case 2:
//                         Console.Write("Enter Manager Id: ");
//                         int managerId = Convert.ToInt32(Console.ReadLine());
//                         bool managerExists = managers.Any(m => m.Id == managerId);
//                         if (managerExists)
//                         {
//                             Console.WriteLine("Manager with this Id already exists. Please enter a unique Id.");
//                             break;
//                         }
//                         Console.Write("Enter Manager Name: ");
//                         string managerName = Console.ReadLine();
//                         Console.Write("Enter Manager Salary: ");
//                         double managerSalary = Convert.ToDouble(Console.ReadLine());
//                         Console.Write("Enter Manager Department: ");
//                         string department = Console.ReadLine();
//                         Console.Write("Enter Manager Bonus: ");
//                         double bonus = Convert.ToDouble(Console.ReadLine());
//                         Manager newManager = new Manager(managerId, managerName, managerSalary, department, bonus);
//                         managers.Add(newManager);
//                         Console.WriteLine("Manager added successfully.");
//                         break;
//                     case 3:
//                         if (employees.Count == 0)
//                         {
//                             Console.WriteLine("No employees to display.");
//                         }
//                         else
//                         {
//                             foreach (var emp in employees)
//                             {
//                                 emp.Display();
//                             }
//                         }
//                         break;
//                         case 4:
//                         if (managers.Count == 0)
//                         {
//                             Console.WriteLine("No managers to display.");
//                         }
//                         else
//                         {
//                             foreach (var mgr in managers)
//                             {
//                                 mgr.Display();
//                             }
//                         }
//                         break;

//                     case 5:
//                         Console.WriteLine("Enter Employee Id");
//                         int searchId = Convert.ToInt32(Console.ReadLine());
//                         bool found = false;
//                         foreach (Employee emp in employees)
//                         {
//                             if (emp.Id == searchId)
//                             {
//                                 emp.Display();
//                                 found = true;
//                                 break;
//                             }
//                         }
//                         if (!found)
//                         {
//                             Console.WriteLine("Employee not found.");
//                         }
//                         break;

                   

//                     case 6:
//                         Console.WriteLine("Exiting the program.");
//                         return;

//                     default:
//                         Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
//                         break;
//                 }
//             }
//             catch (FormatException)
//             {
//                 Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine("An error occurred: " + e.Message);
//             }
//         }
//     }
// }