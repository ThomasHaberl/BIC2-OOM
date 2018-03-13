using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
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
}
