using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_LINQ
{
    internal class Schueler
    {
        private int schuelerID;
        private string name;
        private int alter;
        private int hausID;

        private static List<Schueler> schuelerList =
            [
                new Schueler(1,"Harry",17,3),
                new Schueler(2,"Ron",17,3),
                new Schueler(3,"Hermine",19,3),
                new Schueler(4,"Draco",23,0),
                new Schueler(5,"Luna",18,1),
            ];

        public Schueler(int schuelerID, string name, int alter, int hausID)
        {
            SchuelerID = schuelerID;
            Name = name;
            Alter = alter;
            HausID = hausID;
        }

        public int SchuelerID { get => schuelerID; set => schuelerID = value; }
        public string Name { get => name; set => name = value; }
        public int Alter { get => alter; set => alter = value; }
        public int HausID { get => hausID; set => hausID = value; }
        internal static List<Schueler> SchuelerList { get => schuelerList; set => schuelerList = value; }
    }
}