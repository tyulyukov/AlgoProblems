// See https://aka.ms/new-console-template for more information

var s = new Solution();
Console.WriteLine(
    s.AddTwoNumbers(
        new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))),
        new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))))
);
Console.WriteLine(
    s.AddTwoNumbers(
        new ListNode(2, new ListNode(4, new ListNode(3))),
        new ListNode(5, new ListNode(6, new ListNode(4))))
);
Console.WriteLine(
    s.AddTwoNumbers(
        new ListNode(9),
        new ListNode(1, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))))))))
);
Console.WriteLine(
    s.AddTwoNumbers(
        new ListNode(1, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(9)))))))))),
        new ListNode(5, new ListNode(6, new ListNode(4))))
);

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var sum = new ListNode();
        var sumHead = sum;
        var carry = 0;
        
        while (true)
        {
            sum.val = carry;
            
            if (l1 is null && l2 is null)
                break;

            if (l1 is not null)
                sum.val += l1.val;

            if (l2 is not null)
                sum.val += l2.val;
            
            carry = 0;

            while (sum.val > 9)
            {
                sum.val -= 10;
                carry++;
            }

            if (l1?.next is not null || l2?.next is not null || carry != 0)
            {
                var next = new ListNode();
                sum.next = next;
                sum = next;
            }
            else break;
            
            l1 = l1?.next;
            l2 = l2?.next;
        }

        return sumHead;
    }
    
    /*public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        BigInteger num1 = 0;

        BigInteger i = 1;
        while (l1 is not null)
        {
            num1 += l1.val * i;

            i *= 10;
            l1 = l1.next;
        }
        
        BigInteger num2 = 0;

        BigInteger j = 1;
        while (l2 is not null)
        {
            num2 += l2.val * j;

            j *= 10;
            l2 = l2.next;
        }

        var sum = num1 + num2;
        // var digitsCount = Convert.ToInt32(Math.Log10(sum)) + 1;

        var head = new ListNode();
        var sumListNode = head;
        
        sumListNode.val = (int)(sum % 10);
        sum = sum / 10;
        
        while (sum > 0)
        {
            var next = new ListNode();
            sumListNode.next = next;
            sumListNode = next;
            
            sumListNode.val = (int)(sum % 10);
            sum = sum / 10;
        }

        return head;
    }*/
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