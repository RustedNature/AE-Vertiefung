using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crash
{
    internal class Fahrzeug
    {
        private string marke;

        public Fahrzeug(string marke)
        {
            Marke = marke;
        }

        public string Marke { get => marke; set => marke = value; }
    }
}