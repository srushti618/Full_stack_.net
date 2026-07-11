using System;
using System.Text.Json;
class Serializing
{
    static void Main()
    {
        Employee employee = new Employee(101, "John Doe", 4500);
        string jsonString = JsonSerializer.Serialize(employee);
        Console.WriteLine(jsonString);
        Employee deserializedEmployee = JsonSerializer.Deserialize<Employee>(jsonString);
        Console.WriteLine("Deserialized Employee:");
        deserializedEmployee.Display();
    }
}