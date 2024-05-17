using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Serialisierung
{
    internal class Nutzer
    {
        private string vorname;

        private string nachname;

        private string geburstag;

        private static List<Nutzer> nutzerListe = [];

        public Nutzer()
        {
        }

        public Nutzer(string vorname, string nachname, string geburstag)
        {
            Vorname = vorname;
            Nachname = nachname;
            Geburstag = geburstag;
        }

        public string Vorname { get => vorname; set => vorname = value; }

        public string Nachname { get => nachname; set => nachname = value; }

        public string Geburstag { get => geburstag; set => geburstag = value; }

        public static List<Nutzer> NutzerListe { get => nutzerListe; set => nutzerListe = value; }

        public override string ToString()
        {
            return $"Name: \"{vorname}\", Nachname: \"{nachname}\", Geburtstag: \"{geburstag}\"";
        }
    }
}