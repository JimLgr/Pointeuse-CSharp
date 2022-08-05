
using ClassLibraryTime;
using System.Text;
using System.Text.RegularExpressions;

bool isJour;
string jours;
Dictionary<string, StartEnd> workTimes = new Dictionary<string, StartEnd>();
do
{
    do
    {
        Console.WriteLine("Quel jour sommes nous ou q pour quitter ?");
        jours = Console.ReadLine();
        if (jours == "q")
        {
            DisplayDictionary(workTimes);
            int writeRecords = WriteDictionaryToFile(workTimes);
            Environment.Exit(0);
        }
        isJour = Enum.IsDefined(typeof(Jour), jours.ToLower());

    } while (!isJour);

    Time start = ExtractHourMinute("Heure de debut ex 08:30 ");
    Time end = ExtractHourMinute("Heure de fin ex 17:00");
    StartEnd myStartEnd = new(start, end);
    try
    {
        Time workTime = myStartEnd.Duration;
        Console.WriteLine($"Ce {jours} vous avez travaillez pendant :{workTime.Hours}h{workTime.Minutes}.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    
    

    
    workTimes[jours] = new StartEnd(start, end);
    
} while (true);



static int WriteDictionaryToFile(Dictionary<string, StartEnd> pDictionary)
{
    
    using (StreamWriter fs = File.AppendText("LogDictionary.txt"))
    {
        foreach (var item in pDictionary)
        {
            string strKey = item.Key;
            string strDebut = $"{item.Value.Start.Hours:00}:{item.Value.Start.Minutes:00}";
            string strEnd = $"{item.Value.End.Hours:00}:{item.Value.End.Minutes:00}";
            //string strDuration = $"{item.Value.Duration.Hours:00}:{item.Value.Duration.Minutes:00}";
            string ligne = $"jour : {strKey, -10} | {strDebut} => {strEnd}";
            fs.WriteLine(ligne);

        }
    }
    
    //fs.Close();
    return pDictionary.Count;
    
}

static Time ExtractHourMinute(string question)
{
    string hourMinute;
    Match matched;
    do
    {
        Console.WriteLine(question);
        hourMinute = Console.ReadLine();
        Regex pattern = new Regex(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$");
        matched = pattern.Match(hourMinute); 
    } while (!matched.Success);

    
    Time mytime = TimeHelper.ExtractTime(hourMinute);
    return mytime;
}

static void DisplayDictionary(Dictionary<string, StartEnd> workTimes)
{
    foreach (var item in workTimes)
    {
        Console.WriteLine($"**Ce {item.Key} vous avez démarré le travail à {item.Value.Start.Hours:00}h{item.Value.Start.Minutes:00}");
        Console.WriteLine($"**Ce {item.Key} vous avez fini le travail à {item.Value.End.Hours:00}h{item.Value.End.Minutes:00}");
    }
}