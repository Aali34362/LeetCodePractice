namespace LeetCodePractice.Easy;

public static class RemoveDuplicatesfromSortedArray
{
    public static int RemoveDuplicates(int[] nums)
    {
        int count = 0;
        Console.WriteLine($"plus plus Count : {++count}");
        Console.WriteLine($"Count : {count}");
        Console.WriteLine($"Count plus plus : {count++}");
        Console.WriteLine($"Count : {count}");
        Console.WriteLine($"Count + 1 : {count + 1}");
        Console.WriteLine($"Count : {count}");
        Console.WriteLine($"Count += count : {count += count}");
        Console.WriteLine($"Count : {count}");


        int total = 0;
        int currentNumber = int.MinValue;
        Console.WriteLine($"currentNumber start : {currentNumber}");
        foreach (int i in nums)
        {
            if(currentNumber != i)
            {
                total++;
                nums[total - 1] = i;
                Console.WriteLine($"Array changing by index value (-1) = {i} : {nums.Dump()}");
            }
            currentNumber = i;
            Console.WriteLine($"currentNumber {i} : {currentNumber}");
        }
        return total;
    }
}
