using System.Text;

namespace LeetCodePractice.Easy;

public static class _67AddBinary
{
    public static string AddBinary(string a, string b)
    {
        int firstStringIndex = a.Length - 1;
        int secondStringIndex = b.Length - 1;

        int carry = 0;
        int sum = 0;

        string result = string.Empty;

        while (firstStringIndex >= 0 || secondStringIndex >= 0)
        {
            sum = carry;
            if (firstStringIndex >= 0) sum += a[firstStringIndex--] - '0';
            if (secondStringIndex >= 0) sum += b[secondStringIndex--] - '0';

            carry = sum > 1 ? 1 : 0;

            result += (sum % 2).ToString();
        }
        if (carry > 0) result += carry.ToString();

        char[] charArray = result.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    /*
    Time Complexity
    Iteration Through Strings:
    The while loop iterates through both strings a and b from end to start. 
    In the worst case, this will take O(max(m, n)) time where m and n are the lengths of a and b, respectively.

    String Concatenation:
    In each iteration, a single character is appended to the result string. 
    String concatenation using += has O(k) complexity in each iteration where k is the length of the result string. 
    Given that we append at most max(m, n) + 1 characters, this results in an overall complexity of O((m + n)²) 
    due to the repeated string allocations and copying.

    Reversing the String:
    The Array.Reverse method takes O(k) time where k is the length of the result string, which in the worst case is O(m + n).

    Space Complexity
    Result String:
        The result string uses O(m + n) space for storing the binary result.
    Temporary Storage:
        The charArray and other integer variables (carry, sum) use O(m + n) space in total.
     */

    //Optimized Solution
    public static string AddBinary2(string a, string b)
    {
        int firstStringIndex = a.Length - 1;
        int secondStringIndex = b.Length - 1;

        int carry = 0;
        StringBuilder result = new StringBuilder();

        while (firstStringIndex >= 0 || secondStringIndex >= 0 || carry > 0)
        {
            int sum = carry;
            if (firstStringIndex >= 0) sum += a[firstStringIndex--] - '0';
            if (secondStringIndex >= 0) sum += b[secondStringIndex--] - '0';

            result.Append(sum % 2);
            carry = sum / 2;
        }

        char[] charArray = result.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    /*
    Optimized Time and Space Complexity
    Time Complexity: O(m + n) for the loop and reversing the string. 
    The use of StringBuilder for appending characters makes concatenation O(1) per operation.
    Space Complexity: O(m + n) for the result string and temporary variables.
     */
}
