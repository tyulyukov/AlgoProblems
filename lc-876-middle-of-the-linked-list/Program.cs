// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public class Solution {
    public ListNode MiddleNode(ListNode head)
    {
        var slow = head;
        var fast  = head;

        while (fast.next?.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return fast.next is not null ? slow.next : slow;
    }
}

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}