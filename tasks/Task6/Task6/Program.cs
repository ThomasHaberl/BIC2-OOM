using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        private static Random random = new Random();



        static void Main(string[] args)
        {
            // Initialize the dictionary of example methods
            var examples = new Dictionary<Action, string>()
            {
                { PullExample, nameof(PullExample) },
                { SubjectExample, nameof(SubjectExample) },
                { TasksExample, nameof(TasksExample) },
            };


            // Print the list of examples
            int index = 0;
            Console.WriteLine("Select:");

            foreach (var item in examples)
            {
                Console.WriteLine($"[{index}] {item.Value}");

                index++;
            }


            // Let the user select one
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selectedIndex))
            {
                Action action = examples.Keys.ElementAtOrDefault(selectedIndex);

                if (action == null)
                    Console.WriteLine("ERROR: Invalid input!");

                action();
            }
            else
            {
                Console.WriteLine("ERROR: Invalid input!");
            }
        }


        private static IEnumerable<int> N()
        {
            for (int i = 1; i <= int.MaxValue; i++)
            {
                yield return i;
            }
        }


        private static void PullExample()
        {
            IEnumerable<int> evenNumbers = N().Where((int i) => (i % 2) == 0).Take(10);
            IEnumerable<int> oddNumbers = N().Where((int i) => (i % 2) != 0).Take(10);
            IEnumerable<int> sums = evenNumbers.Zip(oddNumbers, (int first, int second) => (first + second));


            Console.WriteLine("Evens:");

            foreach (int i in evenNumbers)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine();
            Console.WriteLine("Odds:");

            foreach (int i in oddNumbers)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine();
            Console.WriteLine("Sums:");

            foreach (int i in sums)
            {
                Console.WriteLine(i);
            }
        }

        private static void SubjectExample()
        {
            Subject<Car> parkingGarage = new Subject<Car>();
            int carCount = 0;

            parkingGarage.TakeWhile((Car car) => (carCount <= 10)).Subscribe((Car car) => Console.WriteLine($"Car \"{car.ToString()}\" added! Number of cars in garage: {++carCount}"));

            while (true)
            {
                Console.WriteLine("Do you want to add a new car? (type: yes/no/exit)");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "exit":
                        return;

                    case "yes":
                    case "y":
                        Car newCar = new Car($"Car {carCount}", "Unknown model");
                        parkingGarage.OnNext(newCar);
                        
                        break;
                }
            }


        }


        private static void TasksExample()
        {
            var tasks = new List<Task<Car>>();


            for (int i = 0; i < 5; i++)
            {
                var task = Task.Run(() =>
                {
                    Car car = new Car($"Car {i}", "Unknown model");
                    return WashCar(car);
                });

                tasks.Add(task);
            }

            Console.WriteLine("Meanwhile in the car wash...");

            var tasks2 = new List<Task>();

            foreach (var task in tasks)
            {
                tasks2.Add(
                    task.ContinueWith(t => { Console.WriteLine("Your car is like new!"); })
                );
            }
            Console.ReadLine();
            Console.WriteLine("Have a good day, sir!");
        }


        private async static Task<Car> WashCar(Car car)
        {
            Car washedCar = new Car(car.Manufacturer, car.Model);

            int delay = (int)(1000 + random.NextDouble() * 5000);
            await Task.Delay(delay);

            return washedCar;
        }
    }
}
