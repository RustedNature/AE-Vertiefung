using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_02_Verwaltung
{
    internal class Menue
    {
        private static readonly List<string> hauptmenueAuswahlListe =
            ["Kunde erstellen", "Alle Kunden ausgeben",
            "Mitarbeiter erstellen", "Alle Mitarbeiter ausgeben",
            "Artikel erstellen", "Alle Artikel ausgeben",
            "Als Kunde einkaufen",
            "Als Mitarbeiter einkaufen",
            "Rechnungen ausgeben",
            "Programm Beenden"];

        private static readonly List<Action> hauptmenueFunktionen =
            [KundeErstellen,() => ListeAusgeben(Kunde.KundenListe),
            MitarbeiterErstellen, () => ListeAusgeben(Mitarbeiter.MitarbeiterListe),
            ArtikelErstellen, () => ListeAusgeben(Artikel.ArtikelListe),
            EinkaufenKunde,
            EinkaufenMitarbeiter,
            RechnungenAusgeben,
            () => Environment.Exit(0)];

        public static void Hauptmenue()
        {
            LadeAlleListen();
            while (true)
            {
                string benutzerEingabe = string.Empty;
                bool gueltigeAuswahl = false;
                int umgewandeltZuInt = 0;
                while (!gueltigeAuswahl)
                {
                    Console.Clear();
                    Titel("Hauptmenü");
                    GebeAuswahlListeAus();
                    benutzerEingabe = BenutzerEingabe();
                    gueltigeAuswahl = HauptmenueEingabeVerifizieren(benutzerEingabe, out umgewandeltZuInt);
                }
                HauptmenueEingabeVerarbeiten(umgewandeltZuInt);
            }
        }

        private static void RechnungenAusgeben()
        {
            throw new NotImplementedException();
        }

        private static void EinkaufenKunde()
        {
            Console.Clear();

            bool gueltigerKunde = false;
            bool nochMehrKaufen = true;
            int stueck = 0;
            Kunde? kunde = null;
            Artikel? artikel = null;
            Titel("Als Kunde einkaufen");
            Console.WriteLine("Bitte wählen Sie einen Kunden anhand der Kundennummer aus!");
            Console.WriteLine();
            Kunde.KundenListe.ForEach(Console.WriteLine);
            while (!gueltigerKunde)
            {
                string eingabe = BenutzerEingabe();
                var kundeWhere = Kunde.KundenListe.Where(k => k.KundenNummer.ToString() == eingabe);
                if (kundeWhere.Any())
                {
                    gueltigerKunde = true;
                    kunde = kundeWhere.First();
                }
            }
            kunde!.ErstelleNeueEinkaufsliste();
            while (nochMehrKaufen)
            {
                bool gueltigerArtikel = false;
                bool gueltigeStueckzahl = false;
                Console.Clear();
                Titel($"Als {kunde!.Vorname} {kunde.Nachname} einkaufen");
                Artikel.ArtikelListe.ForEach(Console.WriteLine);

                while (!gueltigerArtikel)
                {
                    Console.WriteLine("Bitte wählen Sie anhand der Artikelnummer einen Artikel aus!");
                    string eingabeProdukt = BenutzerEingabe();
                    var produkt = Artikel.ArtikelListe.Where(a => a.Artikelnummer.ToString() == eingabeProdukt);
                    if (produkt.Any())
                    {
                        gueltigerArtikel = true;
                        artikel = produkt.First();
                    }
                }

                while (!gueltigeStueckzahl)
                {
                    Console.WriteLine("Bitte wählen Sie nun die Stückzahl aus!");
                    string eingabeStueck = BenutzerEingabe();
                    if (int.TryParse(eingabeStueck, out stueck) && stueck >= 1)
                    {
                        gueltigeStueckzahl = true;
                    }
                }
                kunde.ArtikelAufEinkaufsliste(artikel!, stueck);
                Console.WriteLine($"------- Der Artikel {artikel!.Bezeichnung} für {artikel.Preis} zu {stueck} stück wurde hinzugefügt -------");
                Console.WriteLine("Noch einen Artikel kaufen?");
                Console.Write("[j]/[n]");
                nochMehrKaufen = BenutzerEingabe(false, false).ToLower() == "j";
            }
        }

        private static void EinkaufenMitarbeiter()
        {
            Console.Clear();

            bool gueltigerMitarbeiter = false;
            bool nochMehrKaufen = true;
            int stueck = 0;
            Mitarbeiter? mitarbeiter = null;
            Artikel? artikel = null;
            Titel("Als Mitarbeiter einkaufen");
            Console.WriteLine("Bitte wählen Sie einen Mitarbeiter anhand der Mitarbeiternummer aus!");
            Console.WriteLine();
            Mitarbeiter.MitarbeiterListe.ForEach(Console.WriteLine);
            while (!gueltigerMitarbeiter)
            {
                string eingabe = BenutzerEingabe();
                var mitarbeiterWhere = Mitarbeiter.MitarbeiterListe.Where(m => m.MitarbeiterNummer.ToString() == eingabe);
                if (mitarbeiterWhere.Any())
                {
                    gueltigerMitarbeiter = true;
                    mitarbeiter = mitarbeiterWhere.First();
                }
            }
            mitarbeiter!.ErstelleNeueEinkaufsliste();
            while (nochMehrKaufen)
            {
                bool gueltigerArtikel = false;
                bool gueltigeStueckzahl = false;
                Console.Clear();
                Titel($"Als {mitarbeiter!.Vorname} {mitarbeiter.Nachname} einkaufen");
                Artikel.ArtikelListe.ForEach(Console.WriteLine);

                while (!gueltigerArtikel)
                {
                    Console.WriteLine("Bitte wählen Sie anhand der Artikelnummer einen Artikel aus!");
                    string eingabeProdukt = BenutzerEingabe();
                    var produkt = Artikel.ArtikelListe.Where(a => a.Artikelnummer.ToString() == eingabeProdukt);
                    if (produkt.Any())
                    {
                        gueltigerArtikel = true;
                        artikel = produkt.First();
                    }
                }

                while (!gueltigeStueckzahl)
                {
                    Console.WriteLine("Bitte wählen Sie nun die Stückzahl aus!");
                    string eingabeStueck = BenutzerEingabe();
                    if (int.TryParse(eingabeStueck, out stueck) && stueck >= 1)
                    {
                        gueltigeStueckzahl = true;
                    }
                }
                mitarbeiter.ArtikelAufEinkaufsliste(artikel!, stueck);
                Console.WriteLine($"------- Der Artikel {artikel!.Bezeichnung} für {artikel.Preis} zu {stueck} stück wurde hinzugefügt -------");
                Console.WriteLine("Noch einen Artikel kaufen?");
                Console.Write("[j]/[n]");
                nochMehrKaufen = BenutzerEingabe(false, false).ToLower() == "j";
            }
        }

        private static void LadeAlleListen()
        {
            Artikel.LadeArtikelListe();
            Mitarbeiter.LadeMitarbeiterListe();
            Kunde.LadeKundenListe();
        }

        private static void HauptmenueEingabeVerarbeiten(int benutzerEingabe)
        {
            hauptmenueFunktionen[--benutzerEingabe]();
        }

        private static void KundeErstellen()
        {
            bool nochEinenErstellen = true;
            while (nochEinenErstellen)
            {
                Console.Clear();
                Titel("Kunde Erstellen");
                Console.Write("Bitte Geben Sie einen Vornamen ein: ");
                string vorname = BenutzerEingabe(false, false);
                Console.Write("Bitte Geben Sie einen Nachnamen ein: ");
                string nachname = BenutzerEingabe(false, false);
                Console.Write("Bitte Geben Sie eine Straße und Hausnummer ein: ");
                string straße = BenutzerEingabe(false, false);
                Console.Write("Bitte Geben Sie eine PLZ ein: ");
                string plz = BenutzerEingabe(false, false);
                Console.Write("Bitte Geben Sie einen Ort ein: ");
                string ort = BenutzerEingabe(false, false);

                Console.WriteLine($"Der Kunde {vorname} {nachname}, aus {straße} {plz} {ort} soll erstellt werden?");
                Console.Write("[j]/[n]: ");
                if (BenutzerEingabe(false, false) == "n")
                {
                    Console.WriteLine("Der obenstehende Kunde wurde nicht erstellt");
                    Console.ReadKey();
                    continue;
                }

                _ = new Kunde(vorname, nachname, straße, plz, ort);
                Console.WriteLine();
                Console.WriteLine($"---------- Kunde {nachname} wurde erstellt ----------");
                Console.WriteLine();
                Console.WriteLine("Noch einen Kunden erstellen?");
                Console.Write("[j]/[n]: ");
                nochEinenErstellen = BenutzerEingabe(false, false).Equals("j", StringComparison.CurrentCultureIgnoreCase);
            }
        }

        private static void MitarbeiterErstellen()
        {
            bool nochEinenErstellen = true;
            while (nochEinenErstellen)
            {
                Console.Clear();
                Titel("Mitarbeiter Erstellen");
                Console.Write("Bitte Geben Sie einen Vornamen ein: ");
                string vorname = BenutzerEingabe(false, false);
                Console.Write("Bitte Geben Sie einen Nachnamen ein: ");
                string nachname = BenutzerEingabe(false, false);
                Console.Write("Bitte Geben Sie eine Straße und Hausnummer ein: ");
                string straße = BenutzerEingabe(false, false);
                Console.Write("Bitte Geben Sie eine PLZ ein: ");
                string plz = BenutzerEingabe(false, false);
                Console.Write("Bitte Geben Sie einen Ort ein: ");
                string ort = BenutzerEingabe(false, false);
                Console.WriteLine($"Der Mitarbeiter {vorname} {nachname}, aus {straße} {plz} {ort} soll erstellt werden?");
                Console.Write("[j]/[n]: ");
                if (BenutzerEingabe(false, false) == "n")
                {
                    Console.WriteLine("Der obenstehende Mitarbeiter wurde nicht erstellt");
                    Console.ReadKey();
                    continue;
                }
                _ = new Mitarbeiter(vorname, nachname, straße, plz, ort);
                Console.WriteLine();
                Console.WriteLine($"---------- Mitarbeiter {nachname} wurde erstellt ----------");
                Console.WriteLine();
                Console.WriteLine("Noch einen Mitarbeiter erstellen?");
                Console.Write("[j]/[n]: ");
                nochEinenErstellen = BenutzerEingabe(false, false).Equals("j", StringComparison.CurrentCultureIgnoreCase);
            }
        }

        private static void ArtikelErstellen()
        {
            bool nochEinenErstellen = true;
            while (nochEinenErstellen)
            {
                bool korrekteZahl = false;
                bool umwandlungErfolgreich = false;
                float preisFloat = 0f;

                Console.Clear();
                Titel("Artikel Erstellen");
                Console.Write("Bitte geben Sie eine Bezeichnung für den Artikel an: ");
                string bezeichnung = BenutzerEingabe(false, false);
                while (!(umwandlungErfolgreich && korrekteZahl))
                {
                    Console.Write("Bitte geben Sie den Preis für den Artikel an: ");
                    string preis = BenutzerEingabe(false, false);
                    umwandlungErfolgreich = float.TryParse(preis, out preisFloat);
                    Console.WriteLine($"Ihr Preis wird als {preisFloat} ausgegeben ");
                    Console.Write("Ist das richtig? [j]/[n]: ");
                    korrekteZahl = BenutzerEingabe(false, false) == "j";
                }
                _ = new Artikel(bezeichnung, preisFloat);

                Console.WriteLine();
                Console.WriteLine($"---------- Artikel {bezeichnung} wurde erstellt ----------");
                Console.WriteLine();
                Console.WriteLine("Noch ein Artikel erstellen?");
                Console.Write("[j]/[n]: ");
                nochEinenErstellen = BenutzerEingabe(false, false).Equals("j", StringComparison.CurrentCultureIgnoreCase);
            }
        }

        private static void ListeAusgeben<T>(List<T> liste)
        {
            liste.ForEach(e => Console.WriteLine(e));

            Console.ReadKey();
        }

        private static bool HauptmenueEingabeVerifizieren(string benutzerEingabe, out int result)
        {
            _ = int.TryParse(benutzerEingabe, out result);

            if (result >= 1 && result <= hauptmenueAuswahlListe.Count)
            {
                return true;
            }
            return false;
        }

        private static string BenutzerEingabe(bool newLine = true, bool standardText = true)
        {
            if (newLine)
            {
                Console.WriteLine();
            }
            if (standardText)
            {
                Console.Write("Ihre Eingabe: ");
            }
            return Console.ReadLine()!;
        }

        private static void GebeAuswahlListeAus()
        {
            for (int i = 0; i < hauptmenueAuswahlListe.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {hauptmenueAuswahlListe[i]}");
            }
        }

        private static void Titel(string titel)
        {
            Console.WriteLine($"_-_ {titel.ToUpper()} _-_");
            Console.WriteLine();
        }
    }
}