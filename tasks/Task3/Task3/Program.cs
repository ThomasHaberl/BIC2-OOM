using System;

namespace Task3
{
    interface IVehicle
    {
        string Manufacturer { get;  }
        string Model { get; }

        double Speed { get; }


        void Accelerate();

        void Decelerate();
    }
    
    class Car
        :IVehicle
    {
        private double _speed;



        public Car(string manufacturer, string model)
        {
            if (string.IsNullOrEmpty(manufacturer))
                throw new ArgumentException("String cannot be null or empty", nameof(manufacturer));

            if (string.IsNullOrEmpty(model))
                throw new ArgumentException("String cannot be null or empty", nameof(model));


            Manufacturer = manufacturer;
            Model = model;
        }



        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        
        public double Speed
        {
            get { return _speed; }
        }



        public void Accelerate()
        {
            _speed += 1;
        }

        public void Decelerate()
        {
            if (_speed > 0)
                _speed -= 1;
        }
    }

    class Plane
        : IVehicle
    {
        private double _speed;



        public Plane(string manufacturer, string model)
        {
            if (string.IsNullOrEmpty(manufacturer))
                throw new ArgumentException("String cannot be null or empty", nameof(manufacturer));

            if (string.IsNullOrEmpty(model))
                throw new ArgumentException("String cannot be null or empty", nameof(model));


            Manufacturer = manufacturer;
            Model = model;
        }



        public string Manufacturer { get; private set; }
        public string Model { get; private set; }

        public double Speed
        {
            get { return _speed; }
        }



        public void Accelerate()
        {
            _speed += 10;
        }

        public void Decelerate()
        {
            if (_speed > 0)
                _speed -= 10;
        }
    }


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
        }
    }
}
