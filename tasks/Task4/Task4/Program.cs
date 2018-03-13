using Newtonsoft.Json;
using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle[] vehicles = new IVehicle[]
            {
                new Car("Alpine", "A110"),
                new Plane("Boeing", "747"),
                new Car("Dacia", "Duster"),
                new Plane("Airbus", "A380"),
            };

            foreach (IVehicle vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.Manufacturer} {vehicle.Model} - Current speed: {vehicle.Speed}");

                vehicle.Accelerate();

                Console.WriteLine($"{vehicle.Manufacturer} {vehicle.Model} - Current speed: {vehicle.Speed}");
            }

            Console.WriteLine();


            string serializedText = JsonConvert.SerializeObject(vehicles);
            
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "vehicles.json");

            File.WriteAllText(filePath, serializedText);

            Console.WriteLine($"Successfully serialized information to file \"{filePath}\":");
            Console.WriteLine("\t" + serializedText);

            Console.WriteLine();


            string deserializedText = File.ReadAllText(filePath);

            Car[] carsDeserialized = JsonConvert.DeserializeObject<Car[]>(deserializedText);

            Console.WriteLine($"Successfully deserialized information from file \"{filePath}\":");
            Console.WriteLine("\t" + deserializedText);

            foreach (Car car in carsDeserialized)
            {
                Console.WriteLine($"{car.Manufacturer} {car.Model} - Current speed: {car.Speed}");
            }

            // Things to note:
            // - Planes have now been converted to Cars
            // - Speed is not publicly settable and hence has been lost during deserialization
        }
    }
}
