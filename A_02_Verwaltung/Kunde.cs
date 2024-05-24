using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_02_Verwaltung
{
    internal class Kunde
    {
        private int kundenNummer;
        private string vorname;
        private string nachname;
        private string straßeHausnummer;
        private string plz;
        private string ort;
        private List<Dictionary<Artikel, int>> einkaufsListe = [];
        private static List<Kunde> kundenListe = [];

        public Kunde(string vorname, string nachname, string straßeHausnummer, string plz, string ort)
        {
            Vorname = vorname;
            Nachname = nachname;
            StraßeHausnummer = straßeHausnummer;
            Plz = plz;
            Ort = ort;
            KundenNummer = KundenNummerIncement();
            KundenListe.Add(this);
            SpeichereKundeListe();
        }

        [JsonConstructor]
        public Kunde(int kundenNummer, string vorname, string nachname, string straßeHausnummer, string plz, string ort)
        {
            Vorname = vorname;
            Nachname = nachname;
            StraßeHausnummer = straßeHausnummer;
            Plz = plz;
            Ort = ort;
            KundenNummer = kundenNummer;
        }

        public int KundenNummer { get => kundenNummer; set => kundenNummer = value; }
        public string Vorname { get => vorname; set => vorname = value; }
        public string Nachname { get => nachname; set => nachname = value; }
        public string StraßeHausnummer { get => straßeHausnummer; set => straßeHausnummer = value; }
        public string Plz { get => plz; set => plz = value; }
        public string Ort { get => ort; set => ort = value; }
        internal static List<Kunde> KundenListe { get => kundenListe; set => kundenListe = value; }

        internal List<Dictionary<Artikel, int>> EinkaufsListe { get => einkaufsListe; set => einkaufsListe = value; }

        private static int KundenNummerIncement()
        {
            if (KundenListe.Count == 0)
            {
                return 1;
            }
            int max = KundenListe.Max(k => k.KundenNummer);
            return ++max;
        }

        public override string ToString()
        {
            return $"KundenNr: {KundenNummer}, Name: {Vorname}, Nachname: {Nachname}, PLZ: {Plz}, Ort: {Ort}";
        }

        internal static void LadeKundenListe()
        {
            if (File.Exists(nameof(Kunde) + ".json"))
            {
                try
                {
                    using StreamReader sr = new($"{nameof(Kunde)}.json");
                    KundenListe = JsonConvert.DeserializeObject<List<Kunde>>(sr.ReadToEnd());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void SpeichereKundeListe()
        {
            try
            {
                using StreamWriter sw = new($"{nameof(Kunde)}.json");
                sw.WriteLine(JsonConvert.SerializeObject(KundenListe));
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