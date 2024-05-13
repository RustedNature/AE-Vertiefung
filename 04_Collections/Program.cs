//Collections bieten uns weitere Möglichkeiten zur Strukturierung und Verwaltung von Daten.

//Eine List verhält sich sehr ähnlich zu einem normalen Array. Jedoch können wir auch zur Laufzeit des Programs ihre Größe ändern und
//Objekte hinzufügen.

//So wird eine Liste initialisiert
//Als Datentyp sind auch erstellte Klassen erlaubt.
List<int> liste = new List<int>();

//Werte werden über .Add() hinzugefügt.
liste.Add(23);
liste.Add(05);

//Die Ausgabe kann wie gewohnt über eine foreach-Schleife erfolgen.
foreach (int i in liste)
{
    Console.WriteLine(i);
}

//Es folgen einige Eigenschaften und Methoden einer Liste
//Anzahl der Elemente einer Liste
Console.WriteLine($"Anzahl Elemente: {liste.Count}");

//Prüfung ob ein bestimmtes Element in der Liste vorhanden ist. Die Rückgabe erfolgt als bool.
Console.WriteLine(liste.Contains(50));

//Einfügen eines Element an einer bestimmten Stelle. Erst Index, dann Wert.
liste.Insert(0, 50);

//Den Index eines Wertes bestimmen.
Console.WriteLine($"Index von 50: {liste.IndexOf(50)}");

//Sortieren der Liste.
liste.Sort();

foreach (int i in liste)
{
    Console.WriteLine(i);
}

//Entfernen eines bestimmten Elements. Kommt dieses mehrmals vor, wird nur das erste Element mit dem entsprechenden Wert entfernt.
liste.Remove(50);

//Entfernen eines Elements an einem bestimmten Index.
liste.RemoveAt(0);

//Alle Elemente aus der Liste entfernen.
liste.Clear();

Console.ReadLine();

//Ein Dictionary ist eine Liste von Elementen, die jedoch nicht über den index, sondern über einen Schlüssel angesprochen werden.
Dictionary<int, int> zahlenDictionary = new Dictionary<int, int>();

//Hinzufügen von Werten. Das erste Argument ist der Schlüssel, das zweite der Wert.
zahlenDictionary.Add(000, 23);
zahlenDictionary.Add(123, 05);
zahlenDictionary.Add(456, 1948);

//Zur Ausgabe werden die Schlüssel in einer ICollection gespeichert.
ICollection<int> schluesselBund = zahlenDictionary.Keys;

//Zur Ausgabe kann wieder eine forerach-Schleife genutzt werden.
foreach (int schluessel in schluesselBund)
{
    Console.WriteLine($"Schlüssel: {schluessel}");
    Console.WriteLine($"Inhalt: {zahlenDictionary[schluessel]}");
}

//Elemente werden über die Schlüssel entfernt.
zahlenDictionary.Remove(123);

//Prüfen auf einen bestimmten Schlüssel.
Console.WriteLine(zahlenDictionary.ContainsKey(123));

//Auf einen bestimmten Wert prüfen.
Console.WriteLine(zahlenDictionary.ContainsValue(23));

//Alle Elemente löschen.
zahlenDictionary.Clear();

//Anzahl der Elemente prüfen
Console.WriteLine(zahlenDictionary.Count());

Console.ReadLine();

//Ein Stack ist eine Datenstruktur, bei der immer nur auf das zuletzt dazugekommene Element zugegriffen werden kann.
//Man spricht von "Last-In, First-Out".

Stack<int> stapel = new Stack<int>();

//Element hinzufügen.
stapel.Push(1);
stapel.Push(2);
stapel.Push(3);
stapel.Push(4);
stapel.Push(5);

//Ausgabe
foreach (int i in stapel)
{
    Console.WriteLine(i);
}

//Prüfung ob ein bestimmtes Element vorhanden ist.
Console.WriteLine(stapel.Contains(5));

//Rückgabe und entfernung des obersten Elemets.
Console.WriteLine(stapel.Pop());

//Rückgabe des obersten Elements ohne Entfernung.
Console.WriteLine(stapel.Peek());

//Alle Elemente entfernen.
stapel.Clear();

//Anzahl der Elemente prüfen.
Console.WriteLine(stapel.Count);

Console.ReadLine();

//Eine Queue funktioniert genau entgegengesetzt zum Stack.
//Es gilt, "First-In, First-Out"

Queue<int> warteschlange = new Queue<int>();

//Elemente hinzufügen
warteschlange.Enqueue(1);
warteschlange.Enqueue(2);
warteschlange.Enqueue(3);
warteschlange.Enqueue(4);
warteschlange.Enqueue(5);

//Ausgabe
foreach (int i in warteschlange)
{
    Console.WriteLine(i);
}

//Prüfung auf die Existenz eines bestimmten Elements
Console.WriteLine(warteschlange.Contains(5));

//Das erste Element zurückgeben und entfernen
Console.WriteLine(warteschlange.Dequeue());

//Alle Elemente löschen
warteschlange.Clear();

//Anzahl der Elemente zählen
Console.WriteLine(warteschlange.Count);