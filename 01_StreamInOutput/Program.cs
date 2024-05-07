//BinaryReader          Liest primitive Datentypen als binärwerte
//BinaryWriter          Schreibt primitive Datentypen als binärwerte
//BufferdStream         Dient zur temporären Speicherung von datenströmen in einem Puffer
//Directory             Dient zum arbeiten mit verzeichnissen mittels statischen methoden
//DirectoryInfo         Dient zum arbeiten mit verzeichnissen mittels instanz methoden
//DriveInfo             Zugriff auf informationen eines Laufwerks
//File                  stellt statische methoden zur bearbeiten von dateien bereit
//FileInfo              stellt instanz methoden zur bearbeiten von dateien bereit und unterstüzt das bearbeiten das Erstellen von FileStream-Objekten
//FileStream            stellt einen datenstrom für eine Datei bereit das lese und schreib vorgänge unterstüzt
//MemoryStream          Erstellt einen datenstrom der den arbeitspeicher zur speicherung nutzt
//Path                  dient zum arbeiten mit datepfaden
//StreamReader          liest zeichen aus einem byte datenstrom
//StreamWriter          schreibt zeichen in einen byte datenstrom
//StringReader          liest aus einer zeichenfolge
//StringWriter          schreibt eine zeichenfolge

//Filestream ist eine grundlegende möglichkeit um mit streams zu interagierenm, ist relativ umständlich und komplex
//Syntax
//FileStream <name> = new FileStream(<Datei>,<FileMode>,<FileAccess>,<FileShare>);
//Siehe C# Lernen Buch seite 193

byte inhalt = 62;

try
{
    FileStream fs = new("filestream.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

    fs.WriteByte(inhalt);

    fs.Position = 0;

    Console.WriteLine(fs.ReadByte());

    fs.Close();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

//StreamReader kann textdateien sehr einfach auslesen
//StreamReader <name> = new StreamReader(<datei>);

try
{
    StreamReader sr = new("streamreader.txt");
    string ausgabe = sr.ReadToEnd();
    sr.Close();

    Console.WriteLine(ausgabe);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();

try
{
    using StreamReader sr = new("streamreader.txt");
    string firstLine = sr.ReadLine()!;
    string secondLine = sr.ReadLine()!;
    Console.WriteLine($"Erste zeile: {firstLine}");
    Console.WriteLine($"Zweite zeile: {secondLine}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();

try
{
    using StreamReader sr = new("streamreader.txt");

    Console.WriteLine($"Erste Zeichen als ASCII: {sr.Read()}");
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Console.ReadLine();

string text = "i bins, de dext";

//StreamWriter erstellt die datei falls sie noch nicht vorhanden ist
try
{
    using StreamWriter sw = new("writer.txt");

    sw.WriteLine(text);
    sw.Close();

    using StreamReader sr = new("writer.txt");

    Console.WriteLine(sr.ReadToEnd());
}
catch (Exception e)
{
    Console.WriteLine(e.Source);
}

//Using answeising siehe oben xD

//StreamWriter kann alle primitve datentypen speichen

int i = 56;
float f = 5.908f;
bool b = true;
char c = '#';

try
{
    using (StreamWriter sw = new("esel.txt"))
    {
        sw.WriteLine(i);
        sw.WriteLine(f);
        sw.WriteLine(b);
        sw.WriteLine(c);
    }

    using StreamReader sr = new("esel.txt");

    Console.WriteLine(sr.ReadToEnd());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// um zu verhindern das StreamWriter jedes mal die datei neu erstellt:

try
{
    using StreamWriter sw = new("esel.txt", true);
    sw.WriteLine(text);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    using StreamReader sr = new("esel.txt");
    Console.WriteLine(sr.ReadToEnd());
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}