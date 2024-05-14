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