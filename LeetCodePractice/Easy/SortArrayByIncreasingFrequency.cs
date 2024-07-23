namespace LeetCodePractice.Easy;

public class SortArrayByIncreasingFrequency
{
    public int[] FrequencySort(int[] nums)
    {
        Dictionary<int, int> numbersCount = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int count = 0;
            if (!numbersCount.ContainsKey(nums[i]))
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] == nums[i])
                        count++;
                }
                numbersCount.Add(nums[i], count);
            }            
        }
        var ordered = numbersCount
            .OrderBy(x => x.Value)
            .ThenBy(entry => entry.Key)
            .ToDictionary(entry => entry.Key, entry => entry.Value);
        int counts = 0;
        foreach (KeyValuePair<int, int> entry in ordered)
        {
            int key = entry.Key;
            int value = entry.Value;
            for (int i = 0; i < value; i++)
            {
                nums[counts] = key;
                counts++;
            }
        }
        return nums;
    }
}
