using System.Text;
using System;

namespace LeetCodePractice.Easy;

public class RomanToInteger
{
    public int RomanToInt(string s)
    {
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
        return total;
    }
}
