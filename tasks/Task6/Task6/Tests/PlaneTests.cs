using NUnit.Framework;
using System;

namespace Task6.Tests
{
    [TestFixture]
    class PlaneTests
    {
        [Test]
        public void Constructor_WithManufacturerNull_ThrowsArgument()
        {
            string manufacturer = null;
            string model = "Model Test";
            
            Assert.Throws<ArgumentException>(() =>
                new Plane(manufacturer, model));
        }

        [Test]
        public void Constructor_WithManufacturerEmpty_ThrowsArgument()
        {
            string manufacturer = string.Empty;
            string model = "Model Test";

            Assert.Throws<ArgumentException>(() =>
                new Plane(manufacturer, model));
        }

        [Test]
        public void Constructor_WithModelNull_ThrowsArgument()
        {
            string manufacturer = "Manufacturer Test";
            string model = null;

            Assert.Throws<ArgumentException>(() =>
                new Plane(manufacturer, model));
        }

        [Test]
        public void Constructor_WithModelEmpty_ThrowsArgument()
        {
            string manufacturer = string.Empty;
            string model = "Model Test";

            Assert.Throws<ArgumentException>(() =>
                new Plane(manufacturer, model));
        }


        [Test]
        public void Constructor_UsesProvidedArguments()
        {
            string manufacturer = "Manufacturer Test";
            string model = "Model Test";

            Plane plane = new Plane(manufacturer, model);

            Assert.AreEqual(manufacturer, plane.Manufacturer);
            Assert.AreEqual(model, plane.Model);
        }


        [Test]
        public void Accelerate_IncreasesSpeed()
        {
            string manufacturer = "Manufacturer Test";
            string model = "Model Test";

            Plane plane = new Plane(manufacturer, model);


            double initialSpeed = plane.Speed;

            plane.Accelerate();

            double finalSpeed = plane.Speed;


            Assert.Greater(finalSpeed, initialSpeed);
        }


        [Test]
        public void Decelerate_DecreasesSpeed()
        {
            string manufacturer = "Manufacturer Test";
            string model = "Model Test";

            Plane plane = new Plane(manufacturer, model);


            plane.Accelerate();
            plane.Accelerate();


            double initialSpeed = plane.Speed;

            plane.Decelerate();

            double finalSpeed = plane.Speed;


            Assert.Less(finalSpeed, initialSpeed);
        }
        
        [Test]
        public void Decelerate_DoesNotCauseNegativeSpeed()
        {
            string manufacturer = "Manufacturer Test";
            string model = "Model Test";

            Plane plane = new Plane(manufacturer, model);


            plane.Accelerate();
            plane.Accelerate();
            
            plane.Decelerate();
            plane.Decelerate();
            plane.Decelerate();

            double finalSpeed = plane.Speed;


            Assert.GreaterOrEqual(finalSpeed, 0);
        }
    }
}
