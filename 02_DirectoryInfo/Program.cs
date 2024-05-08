//DirectoryInfo.Create()                        erstellt ein verzeichnis
//DirectoryInfo.CreateSubdirectory(<string>)    erstell ein oder mehrere Unterverzeichnisse
//DirectoryInfo.Delete()                        Löscht ein verzeichnis
//DirectoryInfo.GetDirectoris()                 gibt unterverzeichnisse als array zurück
//DirectoryInfo.GetFiles()                      gibt eine lister der datein des aktuellen verzeichnis als array

string path = @"C:\Users\Nico\source\repos\C#\AE-Vertiefung\02_DirectoryInfo\bin\Debug\net7.0\Descht";
try
{
    DirectoryInfo directory = new(path);
    if (!directory.Exists)
    {
        directory.Create();
        Console.WriteLine("Das verzeichnis Descht wurde erstellt");
    }
    else
    {
        foreach (var d in directory.GetDirectories())
        {
            Console.WriteLine(d);
        }
        foreach (var f in directory.GetFiles())
        {
            Console.WriteLine(f);
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

//try
//{
//    DirectoryInfo directory = new(path);

//    if (directory.Exists)
//    {
//        directory.Delete();
//        Console.WriteLine($"{path} gelöscht");
//    }

//    directory.Create();
//}
//catch (Exception e)
//{
//    Console.WriteLine(e.Message);
//}

try
{
    DirectoryInfo directory = new(path);
    directory.CreateSubdirectory("unterverzeichnis");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    DirectoryInfo directory = new(path);

    FileInfo[] files = directory.GetFiles();

    foreach (var f in files)
    {
        Console.WriteLine(f);
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}