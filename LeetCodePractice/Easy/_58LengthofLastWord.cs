namespace LeetCodePractice.Easy;

public static class _58LengthofLastWord
{
    public static int LengthOfLastWord(string s)
    {
        string[] strings = s.Trim().Split(' ');
        return strings[strings.Length-1].Length;
    }
    /*
    Current Approach Analysis :
    Time Complexity:

    Trimming: O(n), where n is the length of the string s.
    Splitting: O(n) in the worst case, where n is the length of the string s 
    (each character might need to be processed).
    Accessing the last element and getting its length: O(1).

    Overall time complexity is O(n), where n is the length of the string s.

    Memory Consumption:

    The Trim() operation does not change the string's memory usage but creates a new string.
    Split(' ') creates an array of strings, which consumes additional memory proportional 
    to the number of words in the string.
    Therefore, memory usage can be high for large strings with many words.
     */
    public static int LengthOfLastWord2(string s)
    {
        int length = 0;
        int i = s.Length - 1;

        // Skip trailing spaces
        while (i >= 0 && s[i] == ' ')
        {
            i--;
        }

        // Count length of the last word
        while (i >= 0 && s[i] != ' ')
        {
            length++;
            i--;
        }

        return length;
    }
    /*
    Optimized Approach
    Time Complexity:

    O(n), where n is the length of the string s. This is due to the single traversal of the string from the end.

    Memory Consumption:

    O(1), as it does not use additional memory for arrays or strings.

    Summary

    Your Approach:
        Time Complexity: O(n)
        Memory Consumption: O(n) due to the split operation creating an array of substrings.

    Optimized Approach:
        Time Complexity: O(n)
        Memory Consumption: O(1), more efficient in terms of space as it does not require extra storage for words.
     */
}
