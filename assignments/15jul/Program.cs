using System;
using System.Collections.Generic;
using System.Linq;

namespace ABCMotors
{
    // Vehicle Class
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleType { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }

        public void Display()
        {
            Console.WriteLine($"{VehicleId,-5} {VehicleName,-10} {Brand,-10} {VehicleType,-10} {Price,-10}");
        }
    }

    class Program
    {
        static List<Vehicle> vehicles = new List<Vehicle>();

        static void Main(string[] args)
        {
            Login();
            ShowMenu();
        }

        // 1. User Login
        static void Login()
        {
            Console.WriteLine("Enter Employee Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Employee ID:");
            string id = Console.ReadLine();
            Console.WriteLine($"Welcome {name}");
        }

        // 2. Main Menu
        static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("ABC MOTORS");
                Console.WriteLine("Vehicle Management System");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. View All Vehicles");
                Console.WriteLine("3. Search Vehicle");
                Console.WriteLine("4. Update Vehicle Price");
                Console.WriteLine("5. Delete Vehicle");
                Console.WriteLine("6. Calculate Discount");
                Console.WriteLine("7. Show Vehicle Details");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: AddVehicle(); break;
                    case 2: ViewVehicles(); break;
                    case 3: SearchVehicle(); break;
                    case 4: UpdatePrice(); break;
                    case 5: DeleteVehicle(); break;
                    case 6: CalculateDiscount(); break;
                    case 7: ShowVehicleDetails(); break;
                    case 8: Console.WriteLine("Thank you for using ABC Motors System."); return;
                    default: Console.WriteLine("Invalid Choice."); break;
                }
            }
        }

        // 3. Add Vehicle
        static void AddVehicle()
        {
            Vehicle v = new Vehicle();
            Console.Write("Enter Vehicle ID: ");
            v.VehicleId = int.Parse(Console.ReadLine());
            Console.Write("Enter Vehicle Name: ");
            v.VehicleName = Console.ReadLine();
            Console.Write("Enter Vehicle Type (Car/Bike/Truck): ");
            v.VehicleType = Console.ReadLine();
            Console.Write("Enter Brand: ");
            v.Brand = Console.ReadLine();
            Console.Write("Enter Price: ");
            v.Price = double.Parse(Console.ReadLine());
            Console.Write("Enter Manufacturing Year: ");
            v.Year = int.Parse(Console.ReadLine());

            vehicles.Add(v);
            Console.WriteLine("Vehicle Added Successfully!");
        }

        // 4. Display Vehicles
        static void ViewVehicles()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("ID   Name     Brand     Type      Price");
            Console.WriteLine("-------------------------------------------------------------");
            foreach (var v in vehicles)
            {
                v.Display();
            }
        }

        // 5. Search Vehicle
        static void SearchVehicle()
        {
            Console.Write("Enter Vehicle ID: ");
            int id = int.Parse(Console.ReadLine());
            var v = vehicles.FirstOrDefault(x => x.VehicleId == id);
            if (v != null)
            {
                Console.WriteLine($"ID: {v.VehicleId}, Name: {v.VehicleName}, Brand: {v.Brand}, Type: {v.VehicleType}, Price: {v.Price}, Year: {v.Year}");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        // 6. Update Price
        static void UpdatePrice()
        {
            Console.Write("Enter Vehicle ID: ");
            int id = int.Parse(Console.ReadLine());
            var v = vehicles.FirstOrDefault(x => x.VehicleId == id);
            if (v != null)
            {
                Console.Write("Enter New Price: ");
                v.Price = double.Parse(Console.ReadLine());
                Console.WriteLine("Price Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Vehicle ID does not exist.");
            }
        }

        // 7. Delete Vehicle
        static void DeleteVehicle()
        {
            Console.Write("Enter Vehicle ID: ");
            int id = int.Parse(Console.ReadLine());
            var v = vehicles.FirstOrDefault(x => x.VehicleId == id);
            if (v != null)
            {
                vehicles.Remove(v);
                Console.WriteLine("Vehicle Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Vehicle not available.");
            }
        }

        // 8. Calculate Discount
        static void CalculateDiscount()
        {
            Console.Write("Enter Vehicle ID: ");
            int id = int.Parse(Console.ReadLine());
            var v = vehicles.FirstOrDefault(x => x.VehicleId == id);
            if (v != null)
            {
                double discount = 0;
                switch (v.VehicleType.ToLower())
                {
                    case "car": discount = v.Price * 0.10; break;
                    case "bike": discount = v.Price * 0.05; break;
                    case "truck": discount = v.Price * 0.12; break;
                }
                double finalPrice = v.Price - discount;
                Console.WriteLine($"Vehicle Price: {v.Price}");
                Console.WriteLine($"Discount: {discount}");
                Console.WriteLine($"Final Price: {finalPrice}");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        // 9. Show Vehicle Details
        static void ShowVehicleDetails()
        {
            Console.Write("Enter Vehicle Type (Car/Bike/Truck): ");
            string type = Console.ReadLine().ToLower();
            switch (type)
            {
                case "car":
                    Console.WriteLine("Car is a four wheeler. Suitable for family.");
                    break;
                case "bike":
                    Console.WriteLine("Bike is fuel efficient. Suitable for city rides.");
                    break;
                case "truck":
                    Console.WriteLine("Truck is used for transportation. Heavy load vehicle.");
                    break;
                default:
                    Console.WriteLine("Invalid Vehicle Type.");
                    break;
            }
        }
    }
}

