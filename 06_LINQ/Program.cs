using _06_LINQ;
using System.Collections;

//Language Integrated Query
// Ermöglicht datenabfragen aus verscheidene quellen

//Datenquelle
string[] namen = ["Hudson", "Vasquez", "Drake", "Frost", "Spunkmeyer"];

//Linq
var abfrage = from name in namen
              where name.Contains('e')
              select name;

foreach (var name in abfrage)
{
    Console.WriteLine(name);
}

//Syntax
//from <range variable> in <IEnumerable<T> oder <IQueryable<T> Collection>
//<standart query operator> <Lambda ausdruck>
//select <result fromation>

Console.ReadLine();

var teenageSchueler = from ts in Schueler.SchuelerList
                      where ts.Alter > 12 && ts.Alter < 20
                      select ts;

foreach (var ts in teenageSchueler)
{
    Console.WriteLine(ts.Name);
}

Console.ReadLine();

//geht auch mit lambda
var lambdaSchueler = Schueler.SchuelerList.Where(ts => ts.Alter > 12 && ts.Alter < 20);
foreach (var ts in lambdaSchueler)
{
    Console.WriteLine(ts.Name);
}

var lambdaSchuelerAvg = Schueler.SchuelerList.Where(ts => ts.Alter > 12 && ts.Alter < 20).Average(ts => ts.Alter);
Console.WriteLine(lambdaSchuelerAvg);

Console.ReadLine();

Func<Schueler, bool> geradeId = x => { if (x.SchuelerID % 2 == 0) return true; return false; };

var geradeIds = Schueler.SchuelerList.Where(geradeId);

foreach (var gerade in geradeIds)
{
    Console.WriteLine(gerade.Name);
}

//Wie bereits erwähnt, verfügt LINQ an die 50 verschiedenen standart Abfrage-Operatoren.
//Es folgt eine Übersicht über die Aufgaben und die dazugehörigen Operatoren:
//
//Filterung         |       Where, OfType
//Sortierung        |       OrderBy, OrderByDescending, ThenBy, ThenByDescending, Reverse
//Gruppieren        |       GroupBy, ToLookup
//Join              |       GroupJoin, Join
//Projektion        |       Select, SelectMany
//Aggregation       |       Aggregate, Average, Count, LongCount, Max, Min, Sum
//Quantifizierung   |       All, Any, Contains
//Elemente          |       ElementAt, ElementAtOrDefault, First, FirstOrDefault, Last, LastOrDefault, Single, SingelOrDefault
//Mengenvorgänge    |       Distinct, Except, Intersect, Union
//Partitionierung   |       Skip, SkipWhile, Take, TakeWhile
//Konkatenation     |       Concat
//Gleichheit        |       SequenceEqual
//Generierung       |       DefaultEmpty, Empty, Range, Repeat
//Konvertierung     |       AsEnumerable, AsQueryable, Cast, ToArray, ToDictionary, ToList

//Where
//Der Where-Operator akzeptiert auch ihm übergebene Methoden, die zwingend das relevante Objekt als Parameter und einen
//Bool als Rückgabewert besitzen müssen.
//Erstellung der anonymen Methode mit Lambda:
Func<Schueler, bool> geradeID = x => { if (x.SchuelerID % 2 == 0) return true; return false; };

//Query Syntax
var geradeSchuelerID = from y in Schueler.SchuelerList
                       where geradeID(y)
                       select y;

//Method Syntax
var mgsID = Schueler.SchuelerList.Where(geradeID);

foreach (var z in mgsID)
{
    Console.WriteLine(z.Name);
}

//Mit OfType haben wir die Möglichkeit einen bestimmten Datentypen aus einer Sammlung ausgeben zu lassen.
ArrayList gemischteListe = new ArrayList();
gemischteListe.Add(0);
gemischteListe.Add("eins");
gemischteListe.Add("zwei");
gemischteListe.Add(3);

//Query Syntax
var stringErgebnis = from str in gemischteListe.OfType<string>()
                     select str;

var intErgebnis = from i in gemischteListe.OfType<int>()
                  select i;

//Method Syntax
var stringErgebnisM = gemischteListe.OfType<string>();
var intErgebnisM = gemischteListe.OfType<int>();

foreach (var str in stringErgebnis)
{
    Console.WriteLine(str);
}

foreach (var bla in intErgebnisM)
{
    Console.WriteLine(bla);
}

Console.ReadLine();

//OrderBy sortiert die Werte einer Collection in auf- oder absteigender Reihenfolge. Wobei Aufsteigend
//nicht extra angegeben werden muss, da dies der Stzandartwert ist.

//Query Syntax
var orderByErgebnis = from s in Schueler.SchuelerList
                      orderby s.Name descending
                      select s;

foreach (var s in orderByErgebnis)
{
    Console.WriteLine(s.Name);
}

//Method Syntax
var schuelerAufsteigend = Schueler.SchuelerList.OrderBy(s => s.Name);
var schuelerAbsteigend = Schueler.SchuelerList.OrderByDescending(s => s.Name);

//Multiple Sortierung
var orderByMultiErgebnis = from s in Schueler.SchuelerList
                           orderby s.Name, s.Alter
                           select s;

//In der Method Syntax braucht man dafür .ThenBy()
var schuelerNameAlterSort = Schueler.SchuelerList.OrderBy(s => s.Name).ThenBy(s => s.Alter);

//GroupBy gibt uns eine Gruppe von Elementen zurück, die auf einem bestimmten Schlüsselwert beruhen.
//Die gruppe von Elementen wird durch ein IGrouping<Tkey, TElement> Objekt dargestellt.

//Query Syntax
var gruppiertesErgebnis = from s in Schueler.SchuelerList
                          group s by s.Alter;

//Es werden alle Gruppen durchlaufen
foreach (var altersgruppe in gruppiertesErgebnis)
{
    Console.WriteLine($"Altersgruppe: {altersgruppe.Key}"); //jede Gruppe verfügt über einen Schlüssel

    foreach (Schueler s in altersgruppe) //jede Gruppe hat eine innere Sammlung
    {
        Console.WriteLine($"Name: {s.Name}");
    }
}

//Method Syntax
var gruppiertesErgebnisM = Schueler.SchuelerList.GroupBy(s => s.Alter);

//.ToLookup() funktioniert wie ein .GroupBy(), ist jedoch nur für die Method Syntax verfügbar.

//Der Join Operator kann auf zwei Collections angewendet werden, einer inneren und einer äußeren. Er gibt
//eine neue Collection zurück welche die gestellten Bedingungen erfüllt. Er entspricht dem INNER JOIN in SQL.

//Query Syntax
var innerJoin = from s in Schueler.SchuelerList //äußere Sequenz
                join h in Haus.HausListe       //innere Sequenz
                on s.HausID equals h.HausID      //auswahl des Keys
                select new                       //selector für das Ergebnis
                {
                    SchuelerName = s.Name,
                    HausName = h.HausName
                };

//Method Syntax
var innerJoinM = Schueler.SchuelerList.Join(    //äußere Sequenz
                            Haus.HausListe,    //innere Sequenz
                            s => s.HausID,       //Auswahl des äußeren Schlüssels
                            h => h.HausID,       //Auswahl des inneren Schlüssels
                            (s, h) => new        //selector für das Ergebniss
                            {
                                SchuelerName = s.Name,
                                HausName = h.HausName
                            });

foreach (var item in innerJoinM)
{
    Console.WriteLine($"Haus: {item.HausName}  Schüler: {item.SchuelerName}");
}

//Der GroupJoin Operator wird im Grundsatz angewendet wie Join. Er entspricht grob dem LEFT JOIN in SQL.

//Query Syntax

var groupJoin = from h in Haus.HausListe

                join s in Schueler.SchuelerList

                on h.HausID equals s.HausID

                into schuelerGruppe

                select new

                {
                    Schüler = schuelerGruppe,

                    Hausname = h.HausName
                };

//Method Syntax

var groupJoinM = Haus.HausListe.GroupJoin(Schueler.SchuelerList,

                            h => h.HausID,

                            s => s.HausID,

                            (h, schuelergruppe) => new

                            {
                                Schüler = schuelergruppe,

                                Hausname = h.HausName
                            });

foreach (var item in groupJoinM)

{
    Console.WriteLine($"Haus: {item.Hausname}:");

    foreach (var s in item.Schüler)

    {
        Console.WriteLine($"{s.Name}");
    }
}

//Der Select Operator gibt uns immer eine IEnumerable Collection zurück.

//Dabei können wir den Select auch beliebig begrenzen.

var selectErgebnis = from s in Schueler.SchuelerList

                     select s.Name;

//Der select Operator ermöglicht uns auch, das Ergebnis bereits an unsere Anforderungen anzupassen.

//Er kann verwendet werden um uns eine Sammlung einer selbst erstellten Klasse oder anonyme Typen zu geben.

//Query Syntax

var selectAnonym = from s in Schueler.SchuelerList

                   select new { Name = ($"Zauberlehrling {s.Name}"), Alter = s.Alter };

foreach (var item in selectAnonym)

    Console.WriteLine($"Schüler: {item.Name}, Alter: {item.Alter}");

//Method Syntax

var selectAnonymM = Schueler.SchuelerList.Select(s => new { Name = s.Name, Alter = s.Alter });

//Der Contains Operator prüft ob ein bestimmtes Element einer Collection existiert oder nicht, und gibt uns einen bool zurück.

int[] zahlen = new int[] { 1, 2, 3, 4, 5 };

bool resultat = zahlen.Contains(10);

Schueler positiv = Schueler.SchuelerList[2];

Schueler negativ = new Schueler(1, "Harry", 17, 3);

bool b1 = Schueler.SchuelerList.Contains(positiv);

bool b2 = Schueler.SchuelerList.Contains(negativ);

Console.WriteLine($"{b1} {b2}");

//Die Average Extensionmethode steht uns nur in der Method Syntax zur verfügung.

//Sie berechnet den Durchschnitt von numerischen Werten einer Collection.

//Die Rückgabe kann mit decimal, double oder auch float erfolgen.

var schnitt = zahlen.Average();

//Es ist auch möglich aus einem komplexen Datentyp heraus einen Durchschnitt zu bilden.

var altersSchnitt = Schueler.SchuelerList.Average(s => s.Alter);

Console.WriteLine($"Der Durchschnitt ist: {schnitt}.\nDas Durchschnittsalter der Schülerschaft liegt bei {altersSchnitt} Jahren.");

//Mit .Count() erhalten wir entweder die Anzahl der Elemente in einer Collection, oder die Elemente die eine bestimmte Bedingung erfüllen.
var anzahlZahlen = zahlen.Count();

var geradeZahlen = zahlen.Count(i => i % 2 == 0);

Console.WriteLine($"Gesammtzahl der Zahlen: {anzahlZahlen}.\nGesamtzahl der geraden Zahlen: {geradeZahlen}.\n");

//Die Methode ist auch bei Komplexen Datentypen anwendbar:
var anzahlSchueler = Schueler.SchuelerList.Count();
var ü18Schueler = Schueler.SchuelerList.Count(s => s.Alter >= 18);

Console.WriteLine($"Gesamtzahl der Schüler: {anzahlSchueler}.\nVolljährige Schüler: {ü18Schueler}.\n");

//Für die Query Syntax müsste man die gesamte Abfrage in Klammern setzten und nach den Klammern ein .Count() setzen.

var ü18 = (from item in Schueler.SchuelerList
           where item.Alter >= 18
           select item).Count();

//Die .Max() Methode gibt uns das größte numerische Element einer Collection zurück.
var groesteZahl = zahlen.Max();
var groesteGerade = zahlen.Max(i => { if (i % 2 == 0) return i; return 0; });

Console.WriteLine($"Größte Zahl: {groesteZahl}.\nGrößte gerade Zahl: {groesteGerade}.\n");

//Auch diese Methode ist bei komplexen Datentypen anwendbar.
var aeltesterSchueler = Schueler.SchuelerList.Max(s => s.Alter);

Console.WriteLine($"Der älteste Schüler ist {aeltesterSchueler} Jahre alt.\n");

//.Sum() berechnet die Summe von numerischen Elemente einer Collection. Auch hier können Bedingungen eingefügt werden.
var gesamt = zahlen.Sum();
var geradeSumme = zahlen.Sum(i => { if (i % 2 == 0) return i; return 0; });

Console.WriteLine($"Die Summe aller Zahlen: {gesamt}.\nDie Summe aller geraden Zahlen {geradeSumme}.\n");

//Beispiele für die Anwendung bei komplexen Datentypen.
var gesamtJahre = Schueler.SchuelerList.Sum(s => s.Alter);
var gesamt18 = Schueler.SchuelerList.Sum(s => { if (s.Alter >= 18) return 1; return 0; }); // mit return s.Alter zählt er das Alter zusammen

Console.WriteLine($"Alterssumme der Schüler: {gesamtJahre}.\nSumme aller volljährigen Schüler {gesamt18}.\n");

//Mit First und FirstOrDefault erhalten wir das Element an Index 0 einer Collection, bzw. das
//erste Element das eine bestimmte Bedingung erfüllt.
string[] strArray = { null, "zwei", "Drei", "Vier", "Fünf" };

Console.WriteLine($"Erstes Element von Zahlen: {zahlen.First()}");
Console.WriteLine($"Erstes gerade Element von Zahlen: {zahlen.First(i => i % 2 == 0)}");

Console.WriteLine($"Erstes Elemnt des String-Array: {strArray.First()}");

//Beispiel für FirstOrDefault
Console.WriteLine($"Erstes Element größer als 23 in Zahlen: {zahlen.FirstOrDefault(i => i > 23)}");

//Last und LastOrDefault verhalten sich entsprechend in Bezug auf das letzte Element einer Collection.

//Skip und SkipWhile teilt eine Collection an einem bestimmten Punkt auf, und gibt uns einen der teile als neue
//Collection wieder zurück
string[] partArray = { "Eins", "Zwei", "Drei", "Vier", "Fünf", "Sechs" };

var neuSkip = partArray.Skip(2);

foreach (var item in neuSkip)
    Console.WriteLine(item);

//SkipWhile ermöglicht es uns, solange Elemente zu überspringen, bis eine bestimmte Kondition erfüllt ist.
var neuSkipWhile = partArray.SkipWhile(s => s.Length < 5);

foreach (var item in neuSkipWhile)
    Console.WriteLine($"\n{item}\n");

//Take und TakeWhile teilt ebenfalls eine Collection. Hier jedoch beginnend beim ersten bis hin zu einem bestimmten Punkt.
var neuTake = partArray.Take(2);

foreach (var item in neuTake)
    Console.WriteLine(item);

//TakeWhile gibt uns solange Elemente aus, bis eine bestimmte Kondition erfüllt ist.
var neuTakeWhile = partArray.TakeWhile(s => s.Length < 5);

foreach (var item in neuTakeWhile)
    Console.WriteLine($"\n{item}");