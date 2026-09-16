using System.Globalization;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace training_schedule;

internal class Program
{
    static void DisplaySessions(string[] Names, DateTime[] Dates, int[] sessionDurations)
    {
        for (int i = 0; i < Names.Length; i++)
        {
            Console.WriteLine($"Name : {Names[i]} \n Date : {Dates[i].ToString("D")} " +
                $"\n StartTime : {(Dates[i].ToString("hh:mm tt"))} \n" +
                $"Duration : {sessionDurations[i]} ");
            Console.WriteLine("\n\n");
        }
    }
    static void SearchSessions(string[] Names, DateTime[] Dates, int[] sessionDurations)
    {
        Console.WriteLine("Enter Name Session : ");
        string Nameseesion = Console.ReadLine();
        for (int i = 0; i < Names.Length; i++)
        {
            if (Nameseesion == Names[i])
            {
                Console.WriteLine($"Name : {Names[i]} \n Date : {Dates[i].ToString("D")} " +
                               $"\n StartTime : {(Dates[i].ToString("hh:mm tt"))} \n" +
                               $"Duration : {sessionDurations[i]} ");
                Console.WriteLine("\n\n");
                return;
            }

        }

        Console.WriteLine("Session not found.");
    }
    static void SortCopArray(string[] arr)
    {
        string[] copy = new string[arr.Length];
        Array.Copy(arr, copy, arr.Length);
        Array.Sort(copy);

        foreach (string s in copy) Console.Write(s + " -- ");
    }
    static void ReverseCopArray(string[] arr)
    {
        string[] copy = new string[arr.Length];
        Array.Copy(arr, copy, arr.Length);
        Array.Reverse(copy);

        foreach (string s in copy) Console.Write(s + " -- ");
    }
    static void FunExit( string[] sessionNames)
    {
        Console.WriteLine("Enter session name:");
        string name = Console.ReadLine();
        if (Array.Exists(sessionNames, n => n == name))
        {
            Console.WriteLine("Session exists.");
        }
        else
            Console.WriteLine("Session Not exists.");
    }
    static void FunFind(string name, string[] sessionNames)
    {
        Console.WriteLine(Array.Find(sessionNames, n => n == name));
    }

    static void FindIndex(string[] sessionNames)
    {
        Console.WriteLine("Enter session name:");
        string name = Console.ReadLine();
        if (Array.Exists(sessionNames, n => n == name))
        {
            Console.WriteLine(Array.FindIndex(sessionNames, n => n == name));
        }
        else
            Console.WriteLine("Not Found");
    }
    static void DisplayCopyOrginalArr(string[] Sessionames)
    {
        string[] copy = new string[Sessionames.Length];
        Array.Copy(Sessionames, copy, Sessionames.Length);
        copy[0] = "C++";
        Console.Write("Original : ");
        foreach (string s in Sessionames) Console.WriteLine(s);
        Console.Write("Copy : ");
        foreach (string s in copy) Console.WriteLine(s);
    }

    static void DurationAnalysiz(int[] sessionDurations)
    {
        int total = 0, Average = 0, shortset = sessionDurations[0], longest = sessionDurations[0];

        Console.WriteLine($"Total Duration : {sessionDurations.Sum()} \n Avrege : {sessionDurations.Average()}\n" +
            $"Longeset : {sessionDurations.Max()} \n  Shortest : {sessionDurations.Min()}\n ");

        int[] copy = new int[sessionDurations.Length];
        Array.Copy(sessionDurations, copy, sessionDurations.Length);
        Array.Sort(copy);
        Console.Write("Copy Arr : ");
        foreach (int i in copy) Console.WriteLine(i);

    }

    static string Generatereportusingstring(string[] SessionName, int[] Duration)
    {
        string Report = "SESSION REPORT (String):\n";
        for (int i = 0; i < SessionName.Length; i++)
        {
            Report += $"{SessionName[i]} {Duration[i]} mins\n";
        }
        return Report;
    }
    static string GeneratereportusingStringBuilder(string[] SessionName, int[] Duration)
    {
        StringBuilder Report = new StringBuilder();
        Report.Append("SESSION REPORT (String Bulider):\n");

        for (int i = 0; i < SessionName.Length; i++)
        {
            Report.Append($"{SessionName[i]} {Duration[i]} mins\n");
        }
        return Report.ToString();
    }

    static void Swap(ref int n1, ref int n2)
    {
        (n1, n2) = (n2, n1);
    }

    static void OutFun(string Name, string[] Names, int[] Duraions, out int Index, out int Duraion)
    {
        if (Array.Exists(Names, n => n == Name))
        {
            Index = Array.IndexOf(Names, Name);
            Duraion = Duraions[Index];
        }
        else
        {
            Index = 0; Duraion = 0;
        }

        Console.WriteLine($"Index : {Index} \n Duraion :{Duraion} min");
    }

    static void ChangeInArray(int[] Durations)
    {
        Durations[0] = 350;
    }

    static void CalculateDuraionUsingParams(params int[] Durations)
    {
        Console.WriteLine($"Total Duration :{Durations.Sum()}");
    }

    static void SearchForSessionAndDisplay(string[] names, DateTime[] Dates, int[] Duration)
    {
        Console.WriteLine("Enter session name:");
        string name = Console.ReadLine();
        if (Array.Exists(names, n => n == name))
        {
            int i = Array.FindIndex(names, n => n == name);
            Console.WriteLine($"Date : {Dates[i].ToString("D")}\n Day : {Dates[i].Day} \n " +
                $"Year :{Dates[i].Year} \n Month : {Dates[i].Month} \n Day Number : {Dates[i].DayOfWeek}" +
                $"\n Start Time : {Dates[i].ToString("hh:mm tt")} \n Duration : {Duration[i]} min" +
                $"\n End Time : {Dates[i].AddMinutes(Duration[i]).ToString("hh:mm tt")}");
        }
        else
            Console.WriteLine("Not Found");
    }
    static void Comparetwosessiondates(string[] names, DateTime[] Dates)
    {
        Console.WriteLine("Enter session name1:");
        string name1 = Console.ReadLine();
        Console.WriteLine("Enter session name2:");
        string name2 = Console.ReadLine();
        if (Array.Exists(names, n => n == name1) && Array.Exists(names, n => n == name2))
        {
            int i1 = Array.IndexOf(names, name1);
            int i2 = Array.IndexOf(names, name2);

            TimeSpan Diff = Dates[i2] - Dates[i1];

            Console.WriteLine($"First Session: {name1}");
            Console.WriteLine($"Second Session: {name2}");
            Console.WriteLine($"Diffrance :");
            Console.WriteLine($"{Diff.TotalDays} Days");
            Console.WriteLine($"{Diff.TotalHours} Hours");
        }
        else
            Console.WriteLine("Not Found");
    }

    static void Showpastandupcomingsessions(string[] Names, DateTime[] Dates)
    {
        for (int i = 0; i < Names.Length; i++)
        {
            if (Dates[i] > DateTime.Now)
            {
                Console.WriteLine($"{Names[i]} UpComing");
            }
            else
                Console.WriteLine($"{Names[i]} Past");
        }
    }
    static void Findnextsession(string[] sessionNames, DateTime[] sessionDates)
    {
        DateTime DNow = DateTime.Now;

        int IndexNextS = -1;
        DateTime? nearsetSession = null;

        for (int i = 0; i < sessionNames.Length; i++)
        {
            if (sessionDates[i] > DNow)
            {
                if (nearsetSession == null || sessionDates[i] < nearsetSession)
                {
                    nearsetSession = sessionDates[i];
                    IndexNextS = i;
                }
            }
        }

        if (IndexNextS != -1)
        {
            DateTime nextsesion = sessionDates[IndexNextS];
            TimeSpan Diff = nextsesion - DNow;

            Console.WriteLine("Next Session :");
            Console.WriteLine($"Name : {sessionNames[IndexNextS]} \n {sessionDates[IndexNextS].ToString("D")}\n" +
                $"{sessionDates[IndexNextS].ToString("hh:mm tt")}");
            Console.WriteLine("\n Tiem Remaning :");
            Console.WriteLine($"{Diff.TotalDays} Days \n {Diff.TotalHours} Hours");
        }
        else
            Console.WriteLine("No Found UpComing Sessions");
    }

    static void DisplaySessionForDiffFormat(DateTime[] Dates)
    {
        Console.WriteLine($"Name1 :{Dates[0].ToString("yyy-MM-dd")}\n {Dates[0].ToString("yyy/MM/dd")}\n" +
            $" {Dates[0].ToString("dd MMMM yyyy")}\n  {Dates[0].ToString("dddd, dd MMMM yyyy")}\n {Dates[0].ToString("hh:mm tt")} ");
    }

    static void MenuInput()
    {
      
        while (true)
        {
        Console.WriteLine("Choose An Option:");
        try
        {
            int option =int.Parse(Console.ReadLine());
                Console.WriteLine($"Choose an option: {option}");
                break;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Invalid menu option.: {ex.Message}");
        }

        }
       

    }
    static DateTime Readandvalidateacustomdate()
    {
        string Format = "yyyy-MM-dd HH:mm";
 Console.WriteLine($"Enter date Format:{Format}");
        while (true)
        {
           
            string Input = Console.ReadLine();
            if (DateTime.TryParseExact(Input, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime res))
            {
                return res;
            }
    Console.WriteLine($"Enter Again date Format:{Format}");      
        }
    }

    static void Selectsessionbyindex(string[]names)
    {
        Console.WriteLine("Enter index Session :");
        while (true)
        {
            try
            {
                int index = int.Parse(Console.ReadLine());
               if(index>0 && index < names.Length)
                {
                    Console.WriteLine($"Session: {names[index]}");
                    break;
                }            
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The selected session index is out of range.{ex.Message} \n");
            }
            Console.WriteLine("Enter Right index Session :");
        }
    }
         
    static void Validatesessionduration()
    {
        Console.WriteLine("Enter duration:");
        while (true)
        {
            try
            {
                int Duration = int.Parse(Console.ReadLine());
                if(Duration > 0)
                {
                    Console.WriteLine("Duration accepted.");
                    break;
                }else
                    throw new ArgumentException("Duration must be greater than zero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine($"Stack trace : {ex.StackTrace}");

            }
            Console.WriteLine("Enter Right duration:");
        }
    }

    static void BuildReportString(string[] Names, DateTime[] Dates, int[] Durations)
    {
        string Report = "";
        for (int i = 0; i < Names.Length; i++)
        {
            Report += $"{Names[i]} - {Dates[i].ToString("dd MM yyyy HH:mm tt")} - {Durations[i]} \n";
        }
        Console.WriteLine(Report);
    }

    static void BuildReportStringBuilder(string[] Names, DateTime[] Dates, int[] Durations)
    {
        StringBuilder Report = new StringBuilder();
        for (int i = 0; i < Names.Length; i++)
        {
            Report.Append($"{Names[i]} - {Dates[i].ToString("dd MM yyyy HH:mm tt")} - {Durations[i]} \n");
        }

        Console.WriteLine(Report);
    }

    static void Main(string[] args)
        {
            string[] sessionNames =
                {
         "C# Basics",
         "Arrays",
         "Functions",
         "Date and Time",
         "Exception Handling"
         };
            DateTime[] sessionDates =
              {
        new DateTime(2026, 9, 10, 18, 0, 0),
        new DateTime(2026, 9, 13, 18, 0, 0),
        new DateTime(2026, 9, 17, 18, 0, 0),
        new DateTime(2026, 9, 20, 18, 0, 0),
        new DateTime(2026, 9, 24, 18, 0, 0)
  };
            int[] sessionDurations =
            {
        180,
        240,
        180,
        240,
        180
        };

        Console.WriteLine("===================================");
        Console.WriteLine("Academy Schedule Analyzer");
        Console.WriteLine("===================================");

        while (true)
        {
            Console.WriteLine("1. Display all sessions \n2. Search for a session \n3. Sort session names\n" +
                "4. Reverse session names\r\n5. Find session index\r\n6. Check if session exists" +
                "7. Show duration statistics\r\n8. Show session date details\r\n9. Show past and upcoming sessions" +
                "10. Find next session\r\n11. Compare two session dates\r\n12. Read and validate a custom date" +
                "12. Read and validate a custom date\r\n13. Select session by index\r\n14. Validate session duration\r\n15. Generate report using string" +
                "16. Generate report using StringBuilder\r\n0. Exit");

            Console.Write("\nEnter your choice: ");
            string? input = Console.ReadLine();

            // استخدام Switch Pattern Matching
            // هنا بنحول المدخل لرقم وبنعمل عليه Match في نفس الوقت
            switch (int.TryParse(input, out int choice) ? choice : -1)
            {
                case 0:
                    Console.WriteLine("Exiting program... Goodbye!");
                    return; // الخروج من البرنامج

                case >= 1 and <= 16:
                    HandleOption(choice); // استدعاء الفنكشن المسؤولة عن الخيار
                    break;

                case -1 when string.IsNullOrWhiteSpace(input):
                    Console.WriteLine("Input cannot be empty. Please enter a number.");
                    break;

                default:
                    Console.WriteLine("Invalid option! Please enter a number between 0 and 16.");
                    break;
            }

            Console.WriteLine("\nPress Any Key to continue...");
            Console.ReadKey();
            Console.Clear(); // تنظيف الشاشة قبل الدورة الجاية
        }
         void HandleOption(int option)
        {
            Action action=option switch 
                     {
                         1 =>()=> DisplaySessions(sessionNames, sessionDates, sessionDurations),
                         2 => () => SearchSessions(sessionNames, sessionDates, sessionDurations),
                         3 => () => SortCopArray(sessionNames),
                         4 => () => ReverseCopArray(sessionNames),
                         5 => () => FindIndex(sessionNames),
                         6 => () => FunExit(sessionNames),
                         7 => () => DurationAnalysiz(sessionDurations),
                         8 => () =>  SearchForSessionAndDisplay(sessionNames, sessionDates, sessionDurations),
                         9 => () => Showpastandupcomingsessions(sessionNames, sessionDates),
                         10 => () =>Findnextsession(sessionNames, sessionDates),
                         11 => () => Comparetwosessiondates(sessionNames, sessionDates),
                         12 => () => Readandvalidateacustomdate(),
                         13 => () => Selectsessionbyindex(sessionNames) ,
                         14 => () => Validatesessionduration() ,
                         15 => () => Generatereportusingstring(sessionNames,sessionDurations) ,
                         16 => () => GeneratereportusingStringBuilder(sessionNames, sessionDurations),
                         _ => () => Console.WriteLine("UnKnown"),
                     };
            action();
        }
    }


    
}
