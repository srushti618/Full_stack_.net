using System;
using System.Collections.Generic;
using System.Linq;

namespace ABCMotors
{
    // Vehicle Class
    class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleType { get; set; } // Car, Bike, Truck
        public string Brand { get; set; }
        public double Price { get; set; }
        public int ManufacturingYear { get; set; }

        public void Display()
        {
            Console.WriteLine($"{VehicleId,-5} {VehicleName,-10} {Brand,-10} {VehicleType,-10} {Price,-10}");
        }
    }

    class 15Julassign
    {
        static List<Vehicle> vehicles = new List<Vehicle>();

        static void Main(string[] args)
        {
            // 1. Login
            Console.WriteLine("Enter Employee Name:");
            string empName = Console.ReadLine();
            Console.WriteLine("Enter Employee ID:");
            string empId = Console.ReadLine();
            Console.WriteLine($"Welcome {empName}\n");

            int choice;
            do
            {
                // 2. Main Menu
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
                Console.WriteLine("Enter your choice:");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddVehicle(); break;
                    case 2: ViewAllVehicles(); break;
                    case 3: SearchVehicle(); break;
                    case 4: UpdatePrice(); break;
                    case 5: DeleteVehicle(); break;
                    case 6: CalculateDiscount(); break;
                    case 7: ShowVehicleDetails(); break;
                    case 8: Console.WriteLine("Thank you for using ABC Motors System."); break;
                    default: Console.WriteLine("Invalid Choice."); break;
                }
            } while (choice != 8);
        }

        // 3. Add Vehicle
        static void AddVehicle()
        {
            Vehicle v = new Vehicle();
            Console.WriteLine("Enter Vehicle ID:");
            v.VehicleId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Vehicle Name:");
            v.VehicleName = Console.ReadLine();
            Console.WriteLine("Enter Vehicle Type (Car/Bike/Truck):");
            v.VehicleType = Console.ReadLine();
            Console.WriteLine("Enter Brand:");
            v.Brand = Console.ReadLine();
            Console.WriteLine("Enter Price:");
            v.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Manufacturing Year:");
            v.ManufacturingYear = int.Parse(Console.ReadLine());

            vehicles.Add(v);
            Console.WriteLine("Vehicle Added Successfully!\n");
        }

        // 4. Display Vehicles
        static void ViewAllVehicles()
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
            Console.WriteLine("Enter Vehicle ID:");
            int id = int.Parse(Console.ReadLine());
            Vehicle v = vehicles.FirstOrDefault(x => x.VehicleId == id);
            if (v != null)
            {
                Console.WriteLine($"ID:{v.VehicleId}, Name:{v.VehicleName}, Type:{v.VehicleType}, Brand:{v.Brand}, Price:{v.Price}, Year:{v.ManufacturingYear}");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        // 6. Update Price
        static void UpdatePrice()
        {
            Console.WriteLine("Enter Vehicle ID:");
            int id = int.Parse(Console.ReadLine());
            Vehicle v = vehicles.FirstOrDefault(x => x.VehicleId == id);
            if (v != null)
            {
                Console.WriteLine("Enter New Price:");
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
            Console.WriteLine("Enter Vehicle ID:");
            int id = int.Parse(Console.ReadLine());
            Vehicle v = vehicles.FirstOrDefault(x => x.VehicleId == id);
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
            Console.WriteLine("Enter Vehicle ID:");
            int id = int.Parse(Console.ReadLine());
            Vehicle v = vehicles.FirstOrDefault(x => x.VehicleId == id);
            if (v != null)
            {
                double discount = 0;
                switch (v.VehicleType.ToLower())
                {
                    case "car": discount = 0.10 * v.Price; break;
                    case "bike": discount = 0.05 * v.Price; break;
                    case "truck": discount = 0.12 * v.Price; break;
                }
                double finalPrice = v.Price - discount;
                Console.WriteLine($"Vehicle Price : {v.Price}");
                Console.WriteLine($"Discount : {discount}");
                Console.WriteLine($"Final Price : {finalPrice}");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        // 9. Show Vehicle Details
        static void ShowVehicleDetails()
        {
            Console.WriteLine("Enter Vehicle Type (Car/Bike/Truck):");
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
