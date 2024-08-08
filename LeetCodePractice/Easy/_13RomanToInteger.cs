using System.Text;
using System;
using System.Diagnostics;

namespace LeetCodePractice.Easy;

public class _13RomanToInteger
{
    public int RomanToInt(string s)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        ////////////////////////////////////////////////
        var result = new StringBuilder();
        int total = 0;

        ////var romanNumerals = new List<(string symbol, int value)>
        ////{
        ////    ("M", 1000 ), ("CM",900), ("D",500), ("CD",400),
        ////    ("C",100), ("XC",90), ("L",50), ("XL",40),
        ////    ("X",10), ("IX",9), ("V",5), ("IV",4), ("I",1)
        ////};
        ///////romanNumerals.Exists(x => x.symbol == s.Substring(1, 2));
        ////foreach (var romanChar in s.ToCharArray())
        ////{
        ////    total += romanNumerals.FirstOrDefault(x => x.symbol == romanChar.ToString()).value;
        ////}

        var romanNumerals = new Dictionary<string, int>
        {
            { "M", 1000 }, { "CM", 900 }, { "D", 500 }, { "CD", 400 },
            { "C", 100 }, { "XC", 90 }, { "L", 50 }, { "XL", 40 },
            { "X", 10 }, { "IX", 9 }, { "V", 5 }, { "IV", 4 }, { "I", 1 }
        };
        for (int i = 0; i < s.Length; i++)
        {
            // Check if the next two characters form a special numeral
            if (i < s.Length - 1 && romanNumerals.ContainsKey(s.Substring(i, 2)))
            {
                total += romanNumerals[s.Substring(i, 2)];
                i++; // Move past this pair of characters
            }
            else
            {
                total += romanNumerals[s.Substring(i, 1)];
            }
        }

        ///////////////////////////////////////////////////
        stopwatch.Stop();
        Console.WriteLine($"Time taken: {stopwatch.Elapsed.TotalSeconds} seconds");

        Process currentProcess = Process.GetCurrentProcess();
        long memoryUsed = currentProcess.PrivateMemorySize64;
        Console.WriteLine($"Current Process Details : Id - {currentProcess.Id}");
        Console.WriteLine($"Current Process Details : Process Name - {currentProcess.ProcessName}");
        Console.WriteLine($"Current Process Details : Session Id - {currentProcess.SessionId}");
        Console.WriteLine($"Current Process Details : Base Priority - {currentProcess.BasePriority}");
        Console.WriteLine($"Current Process Details : Container - {currentProcess.Container}");
        Console.WriteLine($"Current Process Details : Main Module - {currentProcess.MainModule!.FileName}");
        Console.WriteLine($"Current Process Details : Priority Class - {currentProcess.PriorityClass}");
        ////Console.WriteLine($"Current Process Details : BeginErrorReadLine - {currentProcess.BeginErrorReadLine}");
        ////Console.WriteLine($"Current Process Details : BeginOutputReadLine - {currentProcess.BeginOutputReadLine}");
        ////Console.WriteLine($"Current Process Details : CancelErrorRead - {currentProcess.CancelErrorRead}");
        ////Console.WriteLine($"Current Process Details : CancelOutputRead - {currentProcess.CancelOutputRead}");
        //////Console.WriteLine($"Current Process Details : ExitCode - {currentProcess.ExitCode}");
        Console.WriteLine($"Current Process Details : Handle - {currentProcess.Handle}");
        Console.WriteLine($"Current Process Details : HandleCount - {currentProcess.HandleCount}");
        Console.WriteLine("\nThreads:");
        foreach (ProcessThread thread in currentProcess.Threads)
        {
            Console.WriteLine("\nThread:");
            Console.WriteLine($"Thread ID: {thread.Id}");
            Console.WriteLine($"State: {thread.ThreadState}");
            Console.WriteLine($"Start Time: {thread.StartTime}");
            Console.WriteLine($"Total Processor Time: {thread.TotalProcessorTime}");
            Console.WriteLine("\n");
        }

        Console.WriteLine("\nModules:");
        foreach (ProcessModule module in currentProcess.Modules)
        {
            Console.WriteLine($"Module Name: {module.ModuleName}, File Path: {module.FileName}");
        }
        Console.WriteLine($"Memory used: {memoryUsed / (1024 * 1024)} MB");
        ///////////////////////////////////////////////////
        return total;
    }
}
