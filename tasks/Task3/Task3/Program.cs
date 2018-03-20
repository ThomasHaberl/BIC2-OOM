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
        private double _groundSpeed;



        public Car(string manufacturer, string model)
        {
            if (string.IsNullOrEmpty(manufacturer))
                throw new ArgumentException("String cannot be null or empty", nameof(manufacturer));

            if (string.IsNullOrEmpty(model))
                throw new ArgumentException("String cannot be null or empty", nameof(model));


            Manufacturer = manufacturer;
            Model = model;
        }


        
        public double GroundSpeed
        {
            get { return _groundSpeed; }
        }



        public void Accelerate()
        {
            _groundSpeed += 1;
        }

        public void Decelerate()
        {
            if (_groundSpeed > 0)
                _groundSpeed -= 1;
        }


        #region IVehicle support

        public string Manufacturer { get; private set; }
        public string Model { get; private set; }


        public double Speed
        {
            get { return _groundSpeed; }
        }

        #endregion
    }

    class Plane
        : IVehicle
    {
        private double _airSpeed;



        public Plane(string manufacturer, string model)
        {
            if (string.IsNullOrEmpty(manufacturer))
                throw new ArgumentException("String cannot be null or empty", nameof(manufacturer));

            if (string.IsNullOrEmpty(model))
                throw new ArgumentException("String cannot be null or empty", nameof(model));


            Manufacturer = manufacturer;
            Model = model;
        }


        
        public double AirSpeed
        {
            get { return _airSpeed; }
        }



        public void Accelerate()
        {
            _airSpeed += 10;
        }

        public void Decelerate()
        {
            if (_airSpeed > 0)
                _airSpeed -= 10;
        }


        #region IVehicle support

        public string Manufacturer { get; private set; }
        public string Model { get; private set; }


        public double Speed
        {
            get { return _airSpeed; }
        }

        #endregion
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
