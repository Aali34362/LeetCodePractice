namespace LeetCodePractice.Easy;

public static class RemoveElement
{
    public static int RemoveElementFunction(int[] nums, int val)
    {
        int total = 0;
        foreach (int i in nums)
        {
            if (val != i)
            {
                nums[total] = i;
                total++;
            }
        }
        return total;
    }
}
