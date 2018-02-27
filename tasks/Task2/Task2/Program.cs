using System;

namespace Task2
{
    class Car
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


    class Program
    {
        static void Main(string[] args)
        {
            Car carA = new Car("Alpine", "A110");
            Car carB = new Car("Dacia", "Duster");

            Console.WriteLine($"{carA.Manufacturer} {carA.Model} - Current speed: {carA.Speed}");
            Console.WriteLine($"{carB.Manufacturer} {carB.Model} - Current speed: {carB.Speed}");

            Console.WriteLine($"----- Ready, set, go! -----");

            carA.Accelerate();
            carA.Accelerate();
            carA.Accelerate();
            carA.Accelerate();

            carB.Accelerate();

            Console.WriteLine($"{carA.Manufacturer} {carA.Model} - Current speed: {carA.Speed}");
            Console.WriteLine($"{carB.Manufacturer} {carB.Model} - Current speed: {carB.Speed}");
        }
    }
}
