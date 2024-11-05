namespace LeetCodePractice.Easy;

public static class _796RotateString
{
    public static bool RotateString(string s, string goal)
    {
        string rotation = s;
        for (int i = 0; i < s.Length; i++)
        {
            rotation = rotation.Substring(1) + rotation[0];
            if (rotation == goal)
                return true;
        }
        return false;
    }
}
