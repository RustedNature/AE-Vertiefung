using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace A_02_Verwaltung
{
    internal class Artikel
    {
        private static readonly string dateiname = "Artikel.json";
        private int artikelnummer;
        private string bezeichnung;
        private float preis;

        private static List<Artikel> artikelListe = [];

        public Artikel(string bezeichnung, float preis)
        {
            Bezeichnung = bezeichnung;
            Preis = preis;
            Artikelnummer = ArtikelNummerIncrement();

            artikelListe.Add(this);
            SpeichereArtikel();
        }

        [JsonConstructor]
        public Artikel(int artikelnummer, string bezeichnung, float preis)
        {
            Bezeichnung = bezeichnung;
            Preis = preis;
            Artikelnummer = artikelnummer;
        }

        public int Artikelnummer { get => artikelnummer; set => artikelnummer = value; }
        public string Bezeichnung { get => bezeichnung; set => bezeichnung = value; }
        public float Preis { get => preis; set => preis = value; }
        internal static List<Artikel> ArtikelListe { get => artikelListe; set => artikelListe = value; }
        public static string Dateiname => dateiname;

        internal static void SpeichereArtikel()
        {
            try
            {
                using StreamWriter sw = new StreamWriter(Dateiname);
                sw.Write(JsonConvert.SerializeObject(ArtikelListe));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void LadeArtikelListe()
        {
            if (File.Exists(nameof(Artikel) + ".json"))
            {
                try
                {
                    using StreamReader sr = new(Dateiname);
                    ArtikelListe = JsonConvert.DeserializeObject<List<Artikel>>(sr.ReadToEnd());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static int ArtikelNummerIncrement()
        {
            if (ArtikelListe.Count == 0)
            {
                return 1;
            }
            int max = ArtikelListe.Max(a => a.Artikelnummer);
            return ++max;
        }

        public override string ToString()
        {
            return $"ArtNr: {Artikelnummer}, Bezeichnung: {Bezeichnung}, Preis: {Preis}€";
        }
    }
}