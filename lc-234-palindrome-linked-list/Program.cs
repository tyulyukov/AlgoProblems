var s = new Solution();

Console.WriteLine(s.IsPalindrome(
        new ListNode(1, 
            new ListNode(2)
        )
    )
);

Console.WriteLine(s.IsPalindrome(
new ListNode(1, 
    new ListNode(2, 
        new ListNode(2, 
            new ListNode(1)
                )
            )
        )
    )
);

public class Solution {
    public bool IsPalindrome(ListNode head)
    {
        List<int> values = new();

        var node = head;
        while (node is not null)
        {
            values.Add(node.val);
            node = node.next;
        }

        for (var i = 0; i < values.Count / 2; i++)
        {
            if (values[i] != values[values.Count - i - 1])
                return false;
        }

        return true;
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