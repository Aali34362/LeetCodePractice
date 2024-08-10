namespace LeetCodePractice.Easy;

public static class _35SearchInsertPosition
{
    public static int SearchInsert(int[] nums, int target)
    {
        int startIndex = 0;
        int lastIndex = nums.Length;

        if (nums[startIndex] >= target) return startIndex; //for array position zero
        if (nums[lastIndex-1 ] < target) return lastIndex;  //for array position last

        for (int i = 0; i < nums.Length; i++)
        {
            if(nums[i] >= target) return i;
        }
        return 0;       
    }
    public static int SearchInsert2(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
                return mid;
            else if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }
}
