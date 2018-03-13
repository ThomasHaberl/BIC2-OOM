using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    interface IVehicle
    {
        string Manufacturer { get; }
        string Model { get; }

        double Speed { get; }


        void Accelerate();

        void Decelerate();
    }
}
