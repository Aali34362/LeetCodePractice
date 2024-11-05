using System.Text;

namespace LeetCodePractice.Easy;

/*
Input: s = "leeetcode"
Output: "leetcode"
Explanation:
Remove an 'e' from the first group of 'e's to create "leetcode".
No three consecutive characters are equal, so return "leetcode".
 */

public static class _1957DeleteCharactersMakeFancyString
{
    public static string MakeFancyString(string s)
    {
        if (s.Length < 3) return s;

        var output = new StringBuilder();
        int count = 1;
        output.Append(s[0]);
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
                count++;
            else
                count = 1; 

            if (count < 3)
                output.Append(s[i]);
        }
        return output.ToString();
    }

    /*
    public class Solution {
    public string MakeFancyString(string s)
        => new string(s.Where((c, i) => i < 2 || !(s[i] == s[i - 1] && s[i] == s[i - 2])).ToArray());
    }
     */
}
