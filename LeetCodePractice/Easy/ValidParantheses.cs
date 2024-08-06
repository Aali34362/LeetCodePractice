namespace LeetCodePractice.Easy;

public static class ValidParantheses
{
    //(([]){})
    //()[{}()]
    //[)(]
    //[(])
    public static bool IsValid(string s)
    {
        if(s.Length == 1 || s.Length == 0)
            return false;

        Dictionary<char,char> parentheses = new Dictionary<char, char>
        { { '(',')' },{ '[',']' },{ '{','}' } };
        HashSet<int> skipValues = new HashSet<int>();
        char[] chars = s.ToCharArray();
        for(int i = 0; i < s.Length; i++)
        {
            int count = i;
            if(skipValues.Contains(i))
                { continue; }

            if (!parentheses.Any(x => x.Key == chars[i]))
                return false;
            else 
            {
                var value = parentheses.FirstOrDefault(x => x.Key == chars[i]).Value;
                if (chars[count + 1] == value)
                    skipValues.Add(count + 1);
                else if (chars[s.Length - 1 - i] == value)
                    skipValues.Add(s.Length - 1 - i);
                else
                    return false;
            }
        }
        return true;
    }

    public static bool IsValid2(string s)
    {
        int length = s.Length;
        if (length == 1 || length == 0)
            return false;

        char[] chars = s.ToCharArray();

        var roundBracketOpen = chars.Count( x => x == '(');
        var roundBracketClose = chars.Count(x => x == ')');
        var squareBracketOpen = chars.Count(x => x == '[');
        var squareBracketClose = chars.Count(x => x == ']');
        var curlyBracketOpen = chars.Count(x => x == '{');
        var curlyBracketClose = chars.Count(x => x == '}');
        if (roundBracketOpen != roundBracketClose || squareBracketOpen != squareBracketClose || curlyBracketOpen != curlyBracketClose)
            return false;

        return true;
    }

    public static bool IsValid3(string s)
    {
        if (s == null || s.Length == 1)
        {
            return false;
        }

        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> map = new Dictionary<char, char>();

        map.Add(')', '(');
        map.Add(']', '[');
        map.Add('}', '{');

        foreach (char alpha in s)
        {
            if (!map.ContainsKey(alpha))
            {
                stack.Push(alpha);
            }

            else
            {
                if (stack.Count == 0)
                {
                    return false;
                }
                char open = stack.Pop();
                char value = map[alpha];
                if (value != open)
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
}
