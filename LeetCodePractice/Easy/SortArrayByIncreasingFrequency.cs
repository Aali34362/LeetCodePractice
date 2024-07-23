namespace LeetCodePractice.Easy;

public class SortArrayByIncreasingFrequency
{
    //My Thinking
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
        ////var ordered = numbersCount
        ////    .OrderBy(x => x.Value)
        ////    .ThenBy(entry => entry.Key)
        ////    .ToDictionary(entry => entry.Key, entry => entry.Value);

        var ordered = numbersCount
            .OrderBy(x => x.Value)
            .ThenByDescending(entry => entry.Key)
            .ToDictionary();

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
    //Chat GPT
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

    //LeetCode Solutions 
    public int[] FrequencySort3(int[] nums) =>
        nums.GroupBy(x => x)
            .OrderBy(x => x.Count())
            .ThenByDescending(x => x.Key)
            .Aggregate(new List<int>(), (a, b) => { a.AddRange(b); return a; })
            .ToArray();

    public int[] FrequencySort4(int[] nums) =>
        nums.GroupBy(v => v)
            .OrderBy(g => g.Count()).ThenByDescending(g => g.Key)
            .SelectMany(g => g).ToArray();


    public int[] FrequencySort5(int[] nums)
    {
        if (nums.Length == 0) return nums;

        PriorityQueue<KeyValuePair<int, int>, KeyValuePair<int, int>> queue =
        new PriorityQueue<KeyValuePair<int, int>, KeyValuePair<int, int>>(new MaxHeapComparer());
        Dictionary<int, int> map = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (map.ContainsKey(num))
            {
                map[num] += 1;
            }
            else
            {
                map[num] = 1;
            }
        }

        foreach (var dict in map)
        {
            queue.Enqueue(new KeyValuePair<int, int>(dict.Key, dict.Value), new KeyValuePair<int, int>(dict.Key, dict.Value));
        }

        int i = 0;
        while (queue.Count > 0)
        {
            if (queue.TryDequeue(out KeyValuePair<int, int> element, out KeyValuePair<int, int> priority))
            {
                //Console.WriteLine("element " + element.Key + " occurs " + element.Value + " times");
                for (int j = 0; j < element.Value; j++)
                {
                    nums[i] = element.Key;
                    i++;
                }
            }
        }
        //Array.Reverse(nums);
        return nums;
    }


    public int[] FrequencySort6(int[] nums) => 
        nums.GroupBy(num => num)
        .ToDictionary(g => g.Key, g => g.Count())
        .GroupBy(p => p.Value)
        .ToDictionary(g => g.Key, g => g.Select(p => p.Key))
        .OrderBy(p => p.Key)
        .SelectMany(p => p.Value.OrderByDescending(n => n)
        .SelectMany(n => Enumerable.Range(1, p.Key)
        .Select(_ => n))).ToArray();
}


public class MaxHeapComparer : IComparer<KeyValuePair<int, int>>
{

    public int Compare(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
    {
        // Compare by the absolute difference first
        int result = x.Value.CompareTo(y.Value);
        // If the absolute difference is the same, compare by the value
        if (result == 0)
        {
            result = y.Key.CompareTo(x.Key);
        }
        return result;
    }
}