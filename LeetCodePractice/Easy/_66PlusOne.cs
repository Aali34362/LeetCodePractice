using System.Text;

namespace LeetCodePractice.Easy;

public static class _66PlusOne
{
    //my wrong code
    public static int[] PlusOne(int[] digits)
    {
        string value = string.Empty;
        foreach (int digit in digits)
        {
            value  += digit.ToString();
        }
        string values = (Convert.ToInt64(value) + 1).ToString(); //'Value was either too large or too small for an Int64.'

        char[] chars = values.ToCharArray();
        int [] result = new int[values.Length];
        for(int i = 0; i<values.Length;i++)
        {
            result[i] = Convert.ToInt32(chars[i].ToString());
        }
        return result;
    }
    /*
     Time Complexity
    String Building (Concatenation in Loop):
    The foreach loop iterates through the digits array. 
    For each digit, it appends its string representation to value.
    Time Complexity: O(n) for concatenating the string where n is the length of digits. 
    However, string concatenation in a loop is not efficient due to repeated allocations and copying of strings. 
    This results in a cumulative time complexity that can be higher in practice, especially with large arrays.

    Conversion to Long:
    The Convert.ToInt64(value) operation converts the concatenated string to a long. 
    This operation itself is O(n), but handling very large numbers can be inefficient.

    Conversion to String and Array:
    Converting the incremented value back to a string and then to a char[] is O(n) where n is the length of the resulting string.
    The subsequent loop to convert each char back to an int is also O(n).

    Overall, the PlusOne method would have a time complexity of approximately O(n)
    where n is the number of digits in the input array, but due to inefficiencies in string manipulation and large number handling,
    it can be higher in practice.

    Space Complexity
    String Building:
    The value string stores the entire number represented by the digits array. 
    This uses O(n) space where n is the length of the digits array.

    Intermediate String Conversions:
    The values string and chars array also use O(n) space for storing the incremented number and its characters.

    Result Array:
    The result array is of size values.Length, which can be up to n+1 in the worst case (when all digits are 9). 
    Thus, it uses O(n) space.

    Overall, the space complexity is O(n) due to the storage requirements for the intermediate strings and the result array.

    Summary
    Time Complexity: Approximately O(n), but can be higher due to inefficiencies with string manipulation and large number handling.
    Space Complexity: O(n) for storing the intermediate strings and result array.

    Comparison to Optimized Solution
    The optimized solution has:

    Time Complexity: O(n)
    Space Complexity: O(n) in the worst case.
     */

    //chat gpt code : Optimized Solution
    public static int[] PlusOne2(int[] digits)
    {
        int n = digits.Length;

        // Start from the last digit
        for (int i = n - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i]++;
                return digits; // No carry needed, return the result
            }
            digits[i] = 0; // Set current digit to 0 and continue to the next digit
        }

        // If all digits were 9, we need a new array
        int[] newNumber = new int[n + 1];
        newNumber[0] = 1; // The carry results in a new most significant digit
        return newNumber;
    }
    /*
    Time Complexity and Memory Consumption
    Time Complexity: O(n), where n is the length of the digits array, as we potentially traverse the array once.
    Memory Consumption: O(n) in the worst case when we need to create a new array to accommodate an additional digit.
     */
}
