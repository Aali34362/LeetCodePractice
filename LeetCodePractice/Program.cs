﻿using LeetCodePractice.IgnoreCodes;
using System.Diagnostics;

Console.WriteLine("Leet Code Practice Started On 23-07-2024");
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

////SortArrayByIncreasingFrequency sortArrayByIncreasingFrequency = new();
////sortArrayByIncreasingFrequency.FrequencySort([1, 1, 2, 2, 2, 3]).Dump();
////sortArrayByIncreasingFrequency.FrequencySort([2, 3, 1, 3, 2]).Dump();

////TwoSum twoSum = new TwoSum();
////twoSum.TwoSumFunction([2, 7, 11, 15], 9).Dump();
////twoSum.TwoSumFunction([3, 2, 3], 6).Dump();

////PalindromeNumber palindromeNumber = new PalindromeNumber();
////palindromeNumber.IsPalindrome(-121).Dump();

////RomanDateTime romanDateTime = new RomanDateTime();
////romanDateTime.DisplayRomanDateTime();

////RomanToInteger roman = new RomanToInteger();
////roman.RomanToInt("LVIII").Dump();

///LongestCommonPrefix.LongestCommonPrefixFunc2(["interspecies", "interstellar", "interstate"]).Dump();
///
////ValidParantheses.IsValid("(([]){})").Dump();

ListNode listNode6 = new ListNode() { val = 4 };
ListNode listNode5 = new ListNode() { val = 3, next = listNode6 };
ListNode listNode4 = new ListNode() { val = 1, next = listNode5 };

ListNode listNode3 = new ListNode() { val = 4 }; 
ListNode listNode2 = new ListNode() { val = 2, next = listNode3 }; 
ListNode listNode1 = new ListNode() { val = 1, next = listNode2 };

ListNode listNode7 = new ListNode(1, new ListNode(2, new ListNode(4)));
ListNode listNode8 = new ListNode(1, new ListNode(3, new ListNode(4)));

MergeTwoSortedLists.MergeTwoLists(listNode1, listNode4).Dump();
MergeTwoSortedLists.MergeTwoLists(listNode7, listNode8).Dump();





/////////////////////////////////
///Ignore Codes
////ChatClient.ChatClientMain();
////RedisJsonChatClient.RedisJsonChatClientMain();
////RedisMultipleJsonChatClient.RedisMultipleJsonChatClientMain();
