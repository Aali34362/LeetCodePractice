namespace LeetCodePractice.Easy;

public static class _69Sqrtx
{
    public static int MySqrt(int x)
    {
        if (x == 0 || x == 1) return x;
        return SqrtRecursive(x, 1, x);
    }
    private static int SqrtRecursive(int x, int left, int right)
    {
        if (left > right) return right;
        int middle = left + (right - left) / 2;
        long square = (long)middle * middle;
        if (square == x) return middle;
        if (square > x) return SqrtRecursive(x, left, middle - 1);
        return SqrtRecursive(x, middle + 1, right);
    }
}
