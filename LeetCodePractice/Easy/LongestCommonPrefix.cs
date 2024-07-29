using System.Diagnostics;
using System.Text;

namespace LeetCodePractice.Easy;

public static class LongestCommonPrefix
{
    ////string[] test1 = { "flower", "flow", "flight" };
    ////string[] test2 = { "dog", "racecar", "car" };
    ////string[] test3 = { "" };
    ////string[] test4 = { "", "" };
    ////string[] test5 = { "a" };
    ////string[] test6 = { "a", "a", "a" };
    ////string[] test7 = { "apple", "banana", "cherry" };
    ////string[] test8 = { "interspecies", "interstellar", "interstate" };
    ////string[] test9 = { "throne", "throne" };
    ////string[] test10 = { "throne", "throne", "throne" };
    ////string[] test11 = { "abcdefgh", "a", "abcde" };
    public static string LongestCommonPrefixFunction(string[] strs)
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        if (strs == null || strs.Length == 0)
            return "";
        ////var areAllItemsNull = strs.All(x => string.IsNullOrEmpty(x));
        ////if (areAllItemsNull) return "";
        var areAnyItemsNull = !strs.Any(x => !string.IsNullOrEmpty(x));
        if (areAnyItemsNull) return "";

        int count = strs.Length;
        strs = strs.OrderBy(aux => aux.Length).ToArray();
        int min = strs[0].Length;
        int max = strs[strs.Length - 1].Length;
        StringBuilder stringBuilder = new();
        for (int i = 0; i < min; i++)
        {
            var characterExist = strs.All(x => x[i] == strs[0][i]);
            if (!characterExist)
                break;
            else
                stringBuilder.Append(strs[0][i]);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        stopwatch.Stop();
        Console.WriteLine($"Time taken: {stopwatch.Elapsed.TotalSeconds} seconds");

        Process currentProcess = Process.GetCurrentProcess();
        long memoryUsed = currentProcess.PrivateMemorySize64;
        Console.WriteLine($"Memory used: {memoryUsed / (1024 * 1024)} MB");
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        return stringBuilder.ToString();
    }

    public static string LongestCommonPrefixFunc2(string[] strs)
    {
        if (strs == null || strs.Length == 0) return "";

        // Initialize the prefix with the first string
        string prefix = strs[0];

        // Compare prefix with each string in the array
        for (int i = 1; i < strs.Length; i++)
        {
            Console.WriteLine(strs[i]);
            // Reduce the prefix while it doesn't match the start of strs[i]
            while (strs[i].IndexOf(prefix) != 0)
            {
                Console.WriteLine(strs[i].IndexOf(prefix));
                prefix = prefix.Substring(0, prefix.Length - 1);
                Console.WriteLine(prefix);
                if (prefix == "") return "";
            }
        }

        return prefix;
    }
}
