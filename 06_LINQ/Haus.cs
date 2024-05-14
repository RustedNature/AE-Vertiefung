using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_LINQ
{
    internal class Haus
    {
        private int hausID;
        private string hausName;

        private static List<Haus> hausListe =
            [
                new Haus(1,"Ravenclaw"),
                new Haus(2,"Slytherin"),
                new Haus(3,"Gryffindor")
            ];

        public Haus(int hausID, string hausName)
        {
            HausID = hausID;
            HausName = hausName;
        }

        public int HausID { get => hausID; set => hausID = value; }
        public string HausName { get => hausName; set => hausName = value; }
        internal static List<Haus> HausListe { get => hausListe; set => hausListe = value; }
    }
}