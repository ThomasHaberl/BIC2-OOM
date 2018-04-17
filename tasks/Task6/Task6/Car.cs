using System;

namespace Task6
{
    class Car
        : IVehicle
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


        public override string ToString()
        {
            return $"{Manufacturer} {Model}";
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
}
