// using System;
// using System.Collections.Generic;

// // Abstract Employee class
// abstract class Employee
// {
//     public int EmployeeId { get; set; }
//     public string Name { get; set; }
//     public string Department { get; set; }
//     public int LeaveBalance { get; protected set; }

//     public void DisplayDetails()
//     {
//         Console.WriteLine($"ID: {EmployeeId}, Name: {Name}, Department: {Department}, Leave Balance: {LeaveBalance}");
//     }

//     public abstract void SetLeaveBalance();
// }

// // PermanentEmployee class
// class PermanentEmployee : Employee
// {
//     public override void SetLeaveBalance()
//     {
//         LeaveBalance = 24;
//     }
// }

// // ContractEmployee class
// class ContractEmployee : Employee
// {
//     public override void SetLeaveBalance()
//     {
//         LeaveBalance = 12;
//     }
// }

// // LeaveRequest class
// class LeaveRequest
// {
//     public int LeaveId { get; set; }
//     public int EmployeeId { get; set; }
//     public int NumberOfDays { get; set; }
//     public string Reason { get; set; }

//     public void DisplayLeave()
//     {
//         Console.WriteLine($"LeaveId: {LeaveId}, EmployeeId: {EmployeeId}, Days: {NumberOfDays}, Reason: {Reason}");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         // Task 1: Create List<Employee>
//         List<Employee> employees = new List<Employee>
//         {
//             new PermanentEmployee { EmployeeId = 101, Name = "Srushti", Department = "IT" },
//             new ContractEmployee { EmployeeId = 102, Name = "Amit", Department = "HR" },
//             new PermanentEmployee { EmployeeId = 103, Name = "Neha", Department = "Finance" },
//             new ContractEmployee { EmployeeId = 104, Name = "Raj", Department = "Marketing" }
//         };

//         // Set leave balances
//         foreach (var emp in employees)
//         {
//             emp.SetLeaveBalance();
//         }

//         // Task 2: Display all employee details
//         Console.WriteLine("\n--- Employee Details ---");
//         foreach (var emp in employees)
//         {
//             emp.DisplayDetails();
//         }

//         // Task 3: Create List<LeaveRequest>
//         List<LeaveRequest> leaveRequests = new List<LeaveRequest>
//         {
//             new LeaveRequest { LeaveId = 1, EmployeeId = 101, NumberOfDays = 5, Reason = "Vacation" },
//             new LeaveRequest { LeaveId = 2, EmployeeId = 103, NumberOfDays = 3, Reason = "Medical" }
//         };

//         // Task 4: Display all leave requests
//         Console.WriteLine("\n--- Leave Requests ---");
//         foreach (var leave in leaveRequests)
//         {
//             leave.DisplayLeave();
//         }

//         // Task 5: Display only Permanent Employees
//         Console.WriteLine("\n--- Permanent Employees ---");
//         foreach (var emp in employees)
//         {
//             if (emp is PermanentEmployee)
//                 emp.DisplayDetails();
//         }

//         // Task 6: Find employee with EmployeeId = 103
//         Console.WriteLine("\n--- Employee with ID 103 ---");
//         Employee foundEmp = employees.Find(e => e.EmployeeId == 103);
//         if (foundEmp != null)
//             foundEmp.DisplayDetails();

//         // Task 7: Display total number of employees
//         Console.WriteLine($"\nTotal Employees: {employees.Count}");

//         // Task 8: Display total number of leave requests
//         Console.WriteLine($"Total Leave Requests: {leaveRequests.Count}");
//     }
// }
