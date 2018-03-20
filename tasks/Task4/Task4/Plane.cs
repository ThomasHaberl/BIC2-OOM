using System;

namespace Task4
{
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
}
