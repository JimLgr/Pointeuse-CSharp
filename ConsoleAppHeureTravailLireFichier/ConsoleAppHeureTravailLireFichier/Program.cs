
using ClassLibraryTime;


const string FILE_PATH = @"C:\Users\pc\source\repos\ConsoleAppHeuresTravail\ConsoleAppHeuresTravail\bin\Debug\net6.0\LogDictionary.txt";
Console.WriteLine("Lire fichier");

using (StreamReader ReaderObject = new StreamReader(FILE_PATH))
    {
        string line;
        while ((line = ReaderObject.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }


Console.WriteLine("----------------autre facon");
using (StreamReader ReaderObject = File.OpenText(FILE_PATH))
{
    Console.WriteLine(ReaderObject.ReadToEnd());
}

Console.WriteLine("----------------autre facon");
using (StreamReader ReaderObject = File.OpenText(FILE_PATH))
{
    while (!ReaderObject.EndOfStream)
    {

        string line = ReaderObject.ReadLine();
        string[] parts = line.Split('|');
        string jour = parts[0].Replace("jour", "").Replace(":", "").Trim();
        string[] times = parts[1].Split("=>");
        Time startTime = TimeHelper.ExtractTime(times[0]);
        Time endTime = TimeHelper.ExtractTime(times[1]);
        StartEnd startEnd = new(startTime, endTime);
        Console.WriteLine($"{jour, -10} : {startTime} => {endTime} | Vous avez travailler pendant : {startEnd.Duration} ");
       


    }
}

