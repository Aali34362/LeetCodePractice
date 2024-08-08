namespace LeetCodePractice.Easy;

public static class _21MergeTwoSortedLists
{
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        Console.WriteLine($"ListNode 1  : {list1}");
        Console.WriteLine($"ListNode 2  : {list2}");
        ListNode head = new();
        Console.WriteLine($"Head : {head}");
        ListNode tail = head;
        Console.WriteLine($"Tail : {tail}");

        while (list1 is not null && list2 is not null)
        {
            Console.WriteLine($"list1 value : {list1.val} and list2 value : {list2.val}");
            if(list1.val < list2.val)
            {
                tail.next = list1;
                list1 = list1.next;
            }
            else
            {
                tail.next = list2;
                list2 = list2.next;
            }
            Console.WriteLine($"list1 : {list1}");
            Console.WriteLine($"list2 : {list2}");
            Console.WriteLine($"Tail Next : {tail}");
            tail = tail.next;
        }

        if(list1 is not null)
        {
            tail.next = list1;
        }
        if (list2 is not null)
        {
            tail.next = list2;
        }
        Console.WriteLine($"Tail End : {tail}");
        Console.WriteLine($"Head End : {head}");
        return head.next;
    }
}


//Definition for singly-linked list.
public record ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
