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

    public int[] FrequencySort1(int[] nums)
    {
        // Group the numbers by their values and calculate their frequencies
        var grouped = nums.GroupBy(x => x)
                          .Select(g => new { Value = g.Key, Frequency = g.Count() })
                          .ToList();

        // Sort first by frequency in ascending order, then by value in descending order
        var sorted = grouped.OrderBy(g => g.Frequency)
                            .ThenByDescending(g => g.Value)
                            .ToList();

        // Flatten the sorted result into a single array
        List<int> result = new List<int>();
        foreach (var group in sorted)
        {
            result.AddRange(Enumerable.Repeat(group.Value, group.Frequency));
        }

        return result.ToArray();
    }
}
