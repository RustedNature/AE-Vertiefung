using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crash
{
    internal class Auto : Fahrzeug
    {
        private int countDoors;

        public Auto(string marke, int countDoors) : base(marke)
        {
            CountDoors = countDoors;
        }

        public int CountDoors { get => countDoors; set => countDoors = value; }
    }
}