namespace LeetCodePractice.Easy;

public class TwoSum
{
    //My Thinking
    public int[] TwoSumFunction(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int currentIndex = i;
            int nextIndexofI = i + 1;
            for (int j = nextIndexofI; j < nums.Length; j++)
            {
                if (nums[currentIndex] + nums[j] == target)
                    return [currentIndex, j];
            }
        }
        return [0, 0];
    }

    //Chat GPT

    //Leet Code Solutions 
}


/*
 * 1. Two Sum
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order. 

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]

Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]

 */