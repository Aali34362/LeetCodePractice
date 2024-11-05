namespace LeetCodePractice.Easy;

public static class _83RemoveDuplicatesSortedList
{
    public static ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null) { return null!; }
        ListNode ptr = head;
        while (ptr.next is not null)
        {
            if (ptr.next.val == ptr.val)
                ptr.next = ptr.next.next;
            else
                ptr = ptr.next;
        }
        return head;
    }
}
