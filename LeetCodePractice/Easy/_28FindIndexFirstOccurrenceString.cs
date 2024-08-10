namespace LeetCodePractice.Easy;

public static class _28FindIndexFirstOccurrenceString
{
    public static int StrStr(string haystack, string needle)
    {
        for(int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            if (haystack.Substring(i, needle.Length) == needle)
                return i;
        }
        return -1;
    }
    //We can solve this problem with KMP algo
}
