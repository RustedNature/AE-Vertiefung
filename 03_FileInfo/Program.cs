//FileInfo.AppendText()                 erstell einen StreamWriter der der datei einen text anfügt
//FileInfo.Create()                     erstell eine datein
//FileInfo.Delete()                     kapoot
//FileInfo.MoveTo(<string>)             Verschient eine datei und ermöglicht umbenennen

string path = @"C:\Users\Nico\source\repos\C#\AE-Vertiefung\03_FileInfo\bin\Debug\net7.0\DESCHT.TXT";

try
{
    FileInfo file = new(path);

    if (!file.Exists)
    {
        file.Create().Close();
    }

    using (StreamWriter writer = file.AppendText())
    {
        writer.WriteLine("MACH EIER");
    }

    //file.MoveTo(@"C:\Users\Nico\source\repos\C#\AE-Vertiefung\03_FileInfo\bin\Debug\net7.0\deschts.txt");
    //file.CopyTo(path);

    file.Delete();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}