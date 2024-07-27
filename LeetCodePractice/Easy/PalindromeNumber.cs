namespace LeetCodePractice.Easy;

public class PalindromeNumber
{
    public bool IsPalindrome(int x)
    {
        if (x < 0)
        {
            return false;
        }
        string current_Value = x.ToString();
        char[] chars = current_Value.ToCharArray();
        string reverse_Value = string.Empty;
        for (int i = chars.Length-1; i >= 0; i--)
        {
            reverse_Value += chars[i];
        }
        return current_Value.Equals(reverse_Value) ? true : false;
    }

    public bool IsPalindrome1(int x)
    {
        // Negative numbers are not palindromes
        if (x < 0)
        {
            return false;
        }

        int original = x;
        int reversed = 0;

        // Reverse the integer
        while (x > 0)
        {
            int digit = x % 10;
            reversed = reversed * 10 + digit;
            x /= 10;
        }

        // Compare the original integer with the reversed integer
        return original == reversed;
    }
}
/*
 * 9. Palindrome Number
 Given an integer x, return true if x is a
palindrome
, and false otherwise.

 

Example 1:

Input: x = 121
Output: true
Explanation: 121 reads as 121 from left to right and from right to left.

Example 2:

Input: x = -121
Output: false
Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.

Example 3:

Input: x = 10
Output: false
Explanation: Reads 01 from right to left. Therefore it is not a palindrome.

 */