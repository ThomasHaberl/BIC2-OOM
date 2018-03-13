using NUnit.Framework;
using System;

namespace Task4.Tests
{
    [TestFixture]
    class CarTests
    {
        [Test]
        public void Constructor_WithManufacturerNull_ThrowsArgument()
        {
            string manufacturer = null;
            string model = "Model Test";

            Assert.Throws<ArgumentException>(() =>
                new Car(manufacturer, model));
        }

        [Test]
        public void Constructor_WithManufacturerEmpty_ThrowsArgument()
        {
            string manufacturer = string.Empty;
            string model = "Model Test";

            Assert.Throws<ArgumentException>(() =>
                new Car(manufacturer, model));
        }

        [Test]
        public void Constructor_WithModelNull_ThrowsArgument()
        {
            string manufacturer = "Manufacturer Test";
            string model = null;

            Assert.Throws<ArgumentException>(() =>
                new Car(manufacturer, model));
        }

        [Test]
        public void Constructor_WithModelEmpty_ThrowsArgument()
        {
            string manufacturer = string.Empty;
            string model = "Model Test";

            Assert.Throws<ArgumentException>(() =>
                new Car(manufacturer, model));
        }


        [Test]
        public void Constructor_UsesProvidedArguments()
        {
            string manufacturer = "Manufacturer Test";
            string model = "Model Test";

            Car car = new Car(manufacturer, model);

            Assert.AreEqual(manufacturer, car.Manufacturer);
            Assert.AreEqual(model, car.Model);
        }


        [Test]
        public void Accelerate_IncreasesSpeed()
        {
            string manufacturer = "Manufacturer Test";
            string model = "Model Test";

            Car car = new Car(manufacturer, model);


            double initialSpeed = car.Speed;

            car.Accelerate();

            double finalSpeed = car.Speed;


            Assert.Greater(finalSpeed, initialSpeed);
        }


        [Test]
        public void Decelerate_DecreasesSpeed()
        {
            string manufacturer = "Manufacturer Test";
            string model = "Model Test";

            Car car = new Car(manufacturer, model);


            car.Accelerate();
            car.Accelerate();


            double initialSpeed = car.Speed;

            car.Decelerate();

            double finalSpeed = car.Speed;


            Assert.Less(finalSpeed, initialSpeed);
        }

        [Test]
        public void Decelerate_DoesNotCauseNegativeSpeed()
        {
            string manufacturer = "Manufacturer Test";
            string model = "Model Test";

            Car car = new Car(manufacturer, model);


            car.Accelerate();
            car.Accelerate();

            car.Decelerate();
            car.Decelerate();
            car.Decelerate();

            double finalSpeed = car.Speed;


            Assert.GreaterOrEqual(finalSpeed, 0);
        }
    }
}
