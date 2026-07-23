// using System;
// using System.Collections.Generic;

// public class Student
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public string Department { get; set; }
//     public string Type { get; set; } // Regular, Scholarship, Part-Time
// }

// public class Course
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public int Credits { get; set; }
// }

// class Jul11
// {
//     static List<Student> students = new List<Student>();
//     static List<Course> courses = new List<Course>();
//     static Dictionary<int, List<Course>> registrations = new Dictionary<int, List<Course>>();

//     static void Main()
//     {
//         try
//         {
//             while (true)
//             {
//                 Console.WriteLine("\n--- Student Management System ---");
//                 Console.WriteLine("1. Register Student");
//                 Console.WriteLine("2. View Students");
//                 Console.WriteLine("3. Search Student by ID");
//                 Console.WriteLine("4. Add Course");
//                 Console.WriteLine("5. View Courses");
//                 Console.WriteLine("6. Register Course for Student");
//                 Console.WriteLine("7. Display Student Details");
//                 Console.WriteLine("8. Exit");
//                 Console.Write("Enter choice: ");
            
//                 int choice = int.Parse(Console.ReadLine() ?? "0");

//                 switch (choice)
//                 {
//                     case 1: RegisterStudent(); break;
//                     case 2: ViewStudents(); break;
//                     case 3: SearchStudent(); break;
//                     case 4: AddCourse(); break;
//                     case 5: ViewCourses(); break;
//                     case 6: RegisterCourse(); break;
//                     case 7: DisplayStudentDetails(); break;
//                     case 8: return; // Exit program
//                     default: Console.WriteLine("Invalid choice!"); break;
//                 }
//             }
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine("An error occurred: " + ex.Message);
//         }
//     }

//     static void RegisterStudent()
//     {
//         Console.Write("Enter Student ID: ");
//         int id = int.Parse(Console.ReadLine() ?? "0");
//         bool exists = students.Exists(s => s.Id == id);
//         if (exists)
//         {
//             Console.WriteLine("Student ID already exists!");
//             return;
//         }
//         Console.Write("Enter Name: ");
//         string name = Console.ReadLine();
//         Console.Write("Enter Department: ");
//         string dept = Console.ReadLine();
//         Console.Write("Enter Type (Regular/Scholarship/Part-Time): ");
//         string type = Console.ReadLine();

//         students.Add(new Student { Id = id, Name = name, Department = dept, Type = type });
//         Console.WriteLine("Student registered successfully!");
//     }

//     static void ViewStudents()
//     {
//         foreach (var s in students)
//             Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Dept: {s.Department}, Type: {s.Type}");
//     }

//     static void SearchStudent()
//     {
//         Console.Write("Enter Student ID: ");
//         int id = int.Parse(Console.ReadLine() ?? "0");
//         var student = students.Find(s => s.Id == id);
//         if (student != null)
//             Console.WriteLine($"Found: {student.Name}, Dept: {student.Department}, Type: {student.Type}");
//         else
//             Console.WriteLine("Student not found!");
//     }

//     static void AddCourse()
//     {
//         Console.Write("Enter Course ID: ");
//         int id = int.Parse(Console.ReadLine() ?? "0");
//         Console.Write("Enter Course Name: ");
//         string name = Console.ReadLine();
//         Console.Write("Enter Credits: ");
//         int credits = int.Parse(Console.ReadLine() ?? "0");

//         courses.Add(new Course { Id = id, Name = name, Credits = credits });
//         Console.WriteLine("Course added successfully!");
//     }

//     static void ViewCourses()
//     {
//         foreach (var c in courses)
//             Console.WriteLine($"ID: {c.Id}, Name: {c.Name}, Credits: {c.Credits}");
//     }

//     static void RegisterCourse()
//     {
//         Console.Write("Enter Student ID: ");
//         int sid = int.Parse(Console.ReadLine() ?? "0");
//         var student = students.Find(s => s.Id == sid);
//         if (student == null) { Console.WriteLine("Student not found!"); return; }

//         Console.Write("Enter Course ID: ");
//         int cid = int.Parse(Console.ReadLine() ?? "0");
//         var course = courses.Find(c => c.Id == cid);
//         if (course == null) { Console.WriteLine("Course not found!"); return; }

//         if (!registrations.ContainsKey(sid))
//             registrations[sid] = new List<Course>();

//         if (registrations[sid].Contains(course))
//         {
//             Console.WriteLine("Course already registered!");
//             return;
//         }

//         if (registrations[sid].Count >= 5)
//         {
//             Console.WriteLine("Maximum course limit reached!");
//             return;
//         }

//         registrations[sid].Add(course);
//         Console.WriteLine("Course registered successfully!");
//     }

//     static void DisplayStudentDetails()
//     {
//         Console.Write("Enter Student ID: ");
//         int sid = int.Parse(Console.ReadLine() ?? "0");
//         var student = students.Find(s => s.Id == sid);
//         if (student == null) { Console.WriteLine("Student not found!"); return; }

//         Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Dept: {student.Department}, Type: {student.Type}");

//         if (registrations.ContainsKey(sid))
//         {
//             int totalCredits = 0;
//             Console.WriteLine("Enrolled Courses:");
//             foreach (var c in registrations[sid])
//             {
//                 Console.WriteLine($"   {c.Name} ({c.Credits} credits)");
//                 totalCredits += c.Credits;
//             }

//             Console.WriteLine($"Total Credits: {totalCredits}");
//             Console.WriteLine($"Total Fee: {CalculateFee(student.Type, totalCredits)}");
//         }
//         else
//         {
//             Console.WriteLine("No courses registered.");
//         }
//     }

//     static double CalculateFee(string type, int credits)
//     {
//         double rate = 1000; // base fee per credit
//         switch (type.ToLower())
//         {
//             case "regular": rate = 1000; break;
//             case "scholarship": rate = 500; break;
//             case "part-time": rate = 1500; break;
//         }
//         return credits * rate;
//     }
// }
