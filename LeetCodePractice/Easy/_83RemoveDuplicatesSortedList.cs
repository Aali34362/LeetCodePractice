namespace LeetCodePractice.Easy;

public static class _83RemoveDuplicatesSortedList
{
    public static ListNode DeleteDuplicates(ListNode head)
    {
        Console.WriteLine($"Head : {head}");        
        ListNode list1 = new();
        Console.WriteLine($"ListNode 1  : {list1}");
        ListNode tail = list1;
        Console.WriteLine($"Tail : {tail}");

        while (head is not null)
        {
            Console.WriteLine($"list1 value : {head.val}");
            if (head.val == head.next.val)
            {
                tail.next = list1;
                list1 = list1.next;
            }
            Console.WriteLine($"list1 : {list1}");
            Console.WriteLine($"Tail Next : {tail}");
            tail = tail.next;
        }
        Console.WriteLine($"Tail End : {tail}");
        Console.WriteLine($"List 1 End : {list1}");
        return list1!.next;
    }
}
