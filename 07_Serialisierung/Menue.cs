using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Serialisierung
{
    internal static class Menue
    {
        public static void Start()
        {
            while (true)
            {
                bool gueltigeEingabe = false;
                string auswahl = string.Empty;
                while (!gueltigeEingabe)
                {
                    Console.Clear();
                    Titel("Hauptmenü");
                    Console.WriteLine("[1] Nutzer ausgeben");
                    Console.WriteLine("[2] Nutzer hinzufügen");
                    Console.WriteLine("[3] Nutzer entfernen");
                    Console.WriteLine("[4] Nutzer speichern");
                    Console.WriteLine("[5] Nutzer laden");
                    Console.WriteLine("[Q] Program beenden");
                    Console.WriteLine();
                    Console.Write("Ihre Eingabe: ");
                    auswahl = Console.ReadLine()!;
                    Console.WriteLine();
                    gueltigeEingabe = AuswertungStartEingabe(auswahl);
                }
                VerarbeiteStartEingabe(auswahl);
            }
        }

        private static bool AuswertungStartEingabe(string auswahl)
        {
            return auswahl.ToLower() switch
            {
                "1" or "2" or "3" or "4" or "5" or "q" => true,
                _ => false,
            };
        }

        private static void VerarbeiteStartEingabe(string auswahl)
        {
            switch (auswahl.ToLower())
            {
                case "1":
                    NutzerAusgeben();
                    break;

                case "2":
                    NutzerHinzufügen();
                    break;

                case "3":
                    NutzerEntfernen();
                    break;

                case "4":
                    NutzerSpeichern();
                    break;

                case "5":
                    NutzerLaden();
                    break;

                case "q":
                    Environment.Exit(0);
                    break;
            }
        }

        private static void NutzerAusgeben()
        {
            Titel("Nutzer ausgeben");
            if (Nutzer.NutzerListe.Count == 0)
            {
                Console.WriteLine("Es existieren keine nutzer!");
            }
            else
            {
                foreach (var nutzer in Nutzer.NutzerListe)
                {
                    Console.WriteLine(nutzer);
                }
            }
            AnykeyWeiter();
        }

        private static void NutzerHinzufügen()
        {
            Titel("Nutzer hinzufügen");
            NutzerDatenEingeben(out string vorname, out string nachname, out string geburtsdatum);

            Console.WriteLine($"Der Nutzer {vorname} {nachname} geboren am {geburtsdatum} soll erstellt werden, richtig?");
            Console.WriteLine("[j]/[n] (ja/nein)");
            bool korrekt = NutzerEingabe() == "j";
            if (korrekt)
            {
                Nutzer n = new(vorname, nachname, geburtsdatum);
                Nutzer.NutzerListe.Add(n);
                Console.WriteLine("Der obenstehende Nutzer wurde erstellt!");
            }
            else
            {
                Console.WriteLine("Sie werden nun zum hauptmenü weitergeleitet");
            }
            AnykeyWeiter();
        }

        private static void NutzerEntfernen()
        {
            Titel("Nutzer entfernen");
            if (Nutzer.NutzerListe.Count == 0)
            {
                Console.WriteLine("Es existieren keine nutzer");
            }
            else
            {
                NutzerDatenEingeben(out string vorname, out string nachname, out string geburtsdatum);
                Console.WriteLine();
                Console.WriteLine($"Der Nutzer {vorname} {nachname} geboren am {geburtsdatum} soll entfernt werden, richtig?");
                Console.WriteLine("[j]/[n] (ja/nein)");
                bool korrekt = NutzerEingabe() == "j";
                if (korrekt)
                {
                    var zuEntfenendenNutzer = Nutzer.NutzerListe.Where(n => n.Vorname == vorname && n.Nachname == nachname && n.Geburstag == geburtsdatum);
                    if (zuEntfenendenNutzer.Count() == 0)
                    {
                        Console.WriteLine("Den Nutzer den Sie angegeben haben existiert nicht, abbruch!");
                    }
                    else
                    {
                        Nutzer.NutzerListe.Remove(zuEntfenendenNutzer.First());
                        Console.WriteLine("Der obenstehende nutzer wurde entfernt!");
                    }
                }
                else
                {
                    Console.WriteLine("Entfernen abgebrochen!");
                }
            }
            AnykeyWeiter();
        }

        private static void NutzerLaden()
        {
            Titel("Nutzer laden");
            string json = string.Empty;
            try
            {
                using (StreamReader sr = new("nutzerliste.json"))
                {
                    json = sr.ReadToEnd();
                };
                Nutzer.NutzerListe = JsonConvert.DeserializeObject<List<Nutzer>>(json);
                Console.WriteLine("Nutzerliste geladen!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            AnykeyWeiter();
        }

        private static void NutzerSpeichern()
        {
            Titel("Nutzer speichern");
            try
            {
                string json = JsonConvert.SerializeObject(Nutzer.NutzerListe, Formatting.Indented);

                using (var sw = new StreamWriter("nutzerliste.json"))
                {
                    sw.Write(json);
                }

                Console.WriteLine("Liste wurde gespeichert");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            AnykeyWeiter();
        }

        private static void NutzerDatenEingeben(out string vorname, out string nachname, out string geburtsdatum)
        {
            Console.WriteLine("Bitte geben Sie den Vornamen ein!");
            vorname = NutzerEingabe();
            Console.WriteLine("Bitte geben Sie den Nachnamen ein!");
            nachname = NutzerEingabe();
            Console.WriteLine("Bitte geben Sie das Geburtsdatum ein! (tt-mm-jjjj)");
            geburtsdatum = NutzerEingabe();
        }

        private static void Titel(string titel)
        {
            Console.WriteLine($"-- {titel.ToUpper()} --");
            Console.WriteLine();
        }

        private static string NutzerEingabe()
        {
            Console.Write("Ihre Eingabe: ");
            string eingabe = Console.ReadLine();
            Console.WriteLine();

            return eingabe;
        }

        private static void AnykeyWeiter()
        {
            Console.WriteLine("Anykey zum fortfahren");
            Console.ReadKey();
        }
    }
}