using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crash
{
    internal class Auto : Fahrzeug
    {
        private int anzahlTueren;

        public Auto(string marke, int countDoors) : base(marke)
        {
            AnzahlTueren = countDoors;
        }

        public int AnzahlTueren { get => anzahlTueren; set => anzahlTueren = value; }
    }
}