using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_02_Verwaltung
{
    internal class Mitarbeiter
    {
        private readonly float mitarbeiterRabatt = 0.15f;

        private int mitarbeiterNummer;
        private string vorname;
        private string nachname;
        private string straßeHausnummer;
        private string plz;
        private string ort;
        private List<Dictionary<Artikel, int>> einkaufsListe = [];
        private static List<Mitarbeiter> mitarbeiterListe = [];

        public Mitarbeiter(string vorname, string nachname, string straßeHausnummer, string plz, string ort)
        {
            Vorname = vorname;
            Nachname = nachname;
            StraßeHausnummer = straßeHausnummer;
            Plz = plz;
            Ort = ort;
            MitarbeiterNummer = MitarbeiterNummerIncement();

            MitarbeiterListe.Add(this);
            SpeichereMitarbeiterListe();
        }

        [JsonConstructor]
        public Mitarbeiter(int mitarbeiterNummer, string vorname, string nachname, string straßeHausnummer, string plz, string ort)
        {
            Vorname = vorname;
            Nachname = nachname;
            StraßeHausnummer = straßeHausnummer;
            Plz = plz;
            Ort = ort;
            MitarbeiterNummer = mitarbeiterNummer;
        }

        public string Vorname { get => vorname; set => vorname = value; }
        public string Nachname { get => nachname; set => nachname = value; }
        public string StraßeHausnummer { get => straßeHausnummer; set => straßeHausnummer = value; }
        public string Plz { get => plz; set => plz = value; }
        public string Ort { get => ort; set => ort = value; }
        public int MitarbeiterNummer { get => mitarbeiterNummer; set => mitarbeiterNummer = value; }
        public float MitarbeiterRabatt => mitarbeiterRabatt;
        internal static List<Mitarbeiter> MitarbeiterListe { get => mitarbeiterListe; set => mitarbeiterListe = value; }
        internal List<Dictionary<Artikel, int>> EinkaufsListe { get => einkaufsListe; }

        private static int MitarbeiterNummerIncement()
        {
            if (MitarbeiterListe.Count == 0)
            {
                return 1;
            }
            int max = MitarbeiterListe.Max(m => m.MitarbeiterNummer);
            return ++max;
        }

        public override string ToString()
        {
            return $"MitarbeiterNr: {MitarbeiterNummer}, Name: {Vorname}, Nachname: {Nachname}, PLZ: {Plz}, Ort: {Ort}";
        }

        internal static void LadeMitarbeiterListe()
        {
            if (File.Exists(nameof(Mitarbeiter) + ".json"))
            {
                try
                {
                    using StreamReader sr = new($"{nameof(Mitarbeiter)}.json");
                    MitarbeiterListe = JsonConvert.DeserializeObject<List<Mitarbeiter>>(sr.ReadToEnd());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void SpeichereMitarbeiterListe()
        {
            try
            {
                using StreamWriter sw = new($"{nameof(Mitarbeiter)}.json");
                sw.WriteLine(JsonConvert.SerializeObject(MitarbeiterListe));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal void ErstelleNeueEinkaufsliste()
        {
            EinkaufsListe.Add([]);
        }

        public void ArtikelAufEinkaufsliste(Artikel artikel, int stueckzahl)
        {
            if (EinkaufsListe.Last().TryGetValue(artikel, out int value))
            {
                EinkaufsListe.Last()[artikel] = value + stueckzahl;
            }
            else
            {
                EinkaufsListe.Last().Add(artikel, stueckzahl);
            }
        }
    }
}