using CsvParser;
using System.Security.Claims;
using CsvData = System.Collections.Generic.List<System.Collections.Generic.List<string>>;

internal class Program
{
    private static void Main(string[] args)
    {
        CsvParser.CsvReader csv = new(@"C:\Users\Nico\source\repos\C#\CsvParser\CsvParser\TestDaten.csv");
        CsvData csvList = csv.ToList();
        GetCountPersonenNewsletter(csvList);
        PercantageOfGender(csvList);
        MostUsedProvider(csvList);
        GroupByAge(csvList);
        ListAllCostumerWithBdayEntry(csvList);

        Console.ReadLine();

        PrintAllEntrys(csvList);
    }

    private static void ListAllCostumerWithBdayEntry(CsvData csvList)
    {
        Console.WriteLine("Aufgabe 5");
        int nameColum = csvList.First().IndexOf("Nachname");
        int surNameColum = csvList.First().IndexOf("Vorname");
        int birthDate = csvList.First().IndexOf("Geburtsdatum");

        var csv = csvList.Skip(1).Where(line => line[birthDate] != string.Empty);

        Console.WriteLine("Vorname | Nachname | Alter");
        foreach (var line in csv)
        {
            _ = DateOnly.TryParse(line[birthDate], out DateOnly birtDateDate);

            Console.WriteLine($"{line[surNameColum]} | {line[nameColum]} | {CalculateAge(birtDateDate.ToDateTime(TimeOnly.MinValue))}");
        }
        Console.WriteLine();
    }

    private static void GroupByAge(CsvData csvList)
    {
        Console.WriteLine("Aufgabe 4");

        int birthdateColum = csvList.First().IndexOf("Geburtsdatum");

        var groupByAge = csvList.Skip(1).Where(line => line[birthdateColum] != string.Empty).GroupBy(line =>
        {
            _ = DateOnly.TryParse(line[birthdateColum], out DateOnly birthDate);

            return CalculateAge(birthDate.ToDateTime(TimeOnly.MinValue));
        });

        foreach (var group in groupByAge.OrderBy(kv => kv.Key))
        {
            Console.WriteLine("Alter: " + group.Key);
            foreach (var entry in group)
            {
                Console.Write("\t\t");
                foreach (var cell in entry)
                {
                    Console.Write($"{cell} | ");
                }
                Console.WriteLine();
            }
        }

        Console.WriteLine();
    }

    private static void MostUsedProvider(CsvData csvList)
    {
        Console.WriteLine("Aufgabe 3");

        Dictionary<string, int> emailProvider = [];

        int emailColumn = csvList[0].IndexOf("EMail");

        csvList.Skip(1).ToList().ForEach(line =>
        {
            if (line[emailColumn].Contains('@'))
            {
                var split = line[emailColumn].Split('@');

                if (emailProvider.TryGetValue(split[1], out int value))
                {
                    emailProvider[split[1]] = ++value;
                }
                else
                {
                    emailProvider.Add(split[1], 1);
                }
            }
        });

        var mostUsedProvider = emailProvider.OrderByDescending(kv => kv.Value).First();

        Console.WriteLine($"Am meisten genutzte Email provider ist {mostUsedProvider.Key} mit {mostUsedProvider.Value} einträgen");

        Console.WriteLine();
    }

    private static void PercantageOfGender(CsvData csvList)
    {
        Console.WriteLine("Aufgabe 2");
        int genderColumn = csvList[0].IndexOf("Anrede");

        var genderList = csvList.Skip(1).GroupBy(line => line[genderColumn]).ToList();

        int totalEntries = csvList.Skip(1).Count();

        genderList.ForEach(g => { Console.WriteLine($"{g.Key}: {g.Count() / (float)totalEntries * 100}%"); });

        Console.WriteLine();
    }

    private static void GetCountPersonenNewsletter(CsvData csvData)
    {
        Console.WriteLine("Aufgabe 1");
        int sum;

        int newsletterColumn = csvData[0].IndexOf("Newsletter");

        sum = csvData.Count(line =>
        {
            return line[newsletterColumn] == "ja";
        });

        Console.WriteLine($"Es haben {sum} Leute den newsletter abboniert");
        Console.WriteLine();
    }

    private static void PrintAllEntrys(CsvData csvList)
    {
        Console.WriteLine("Aufgabe 6");

        csvList.First().ForEach(csv =>
        {
            Console.Write(csv + " | ");
        });
        Console.WriteLine();
        csvList.Skip(1).ToList().ForEach(line =>
        {
            _ = int.TryParse(line[0], out int entryNumber);
            if (entryNumber % 50 == 0)
            {
                line.ForEach(cell => Console.Write(cell + " | "));

                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                line.ForEach(cell => Console.Write(cell + " | "));
                Console.WriteLine();
            }
        });
    }

    private static int CalculateAge(DateTime birthDate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;

        if (today < birthDate.AddYears(age))
        {
            age--;
        }

        return age;
    }
}