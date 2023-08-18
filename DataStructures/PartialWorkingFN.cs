using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCoding
{
    public class PartialWorkingFN
    {
        public static List<int> MergeTwoLists(List<int> list1, List<int> list2)
        {
            List<int> linkedList = new List<int>();
            int i = 0, j = 0, tempVar = list1[0];

            while (i < list1.Count && j < list2.Count)
            {
                if (j < list2.Count && tempVar < list2[j])
                {
                    linkedList.Add(tempVar);
                    tempVar = list2[j];
                    i++;
                }
                if (i < list1.Count && tempVar < list1[i])
                {
                    linkedList.Add(tempVar);
                    tempVar = list1[i];
                    j++;
                }
            }
            if (j < list2.Count && i == list1.Count)
            {
                linkedList.AddRange(list2.GetRange(j, list2.Count - j));
            }
            if (i < list1.Count && j == list2.Count)
            {
                linkedList.AddRange(list1.GetRange(i, list1.Count - i));
            }

            return linkedList;
        }

        public static int Divide(int dividend, int divisor)
        {
            if (dividend == 1 << 31 && divisor == -1)
            {
                return int.MaxValue;
            }

            bool sign = (dividend >= 0) == (divisor >= 0) ? true : false;
            dividend = Math.Abs(dividend);
            divisor = Math.Abs(divisor);
            int result = 0;
            while (dividend - divisor >= 0)
            {
                int count = 0;
                while (dividend - (divisor << 1 << count) >= 0)
                {
                    count++;
                }
                result += 1 << count;
                dividend -= divisor << count;
            }
            return sign ? result : -result;
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            ListNode dummyNode = new ListNode();

            while (l1 != null || l2 != null || carry != null)
            {
                int l1_digit = l1 != null ? l1.val : 0;
                int l2_digit = l2 != null ? l2.val : 0;

                int sum = l1_digit + l2_digit + carry;
                carry = sum / 10;
                sum %= 10;

                dummyNode.next = new ListNode(sum);
                dummyNode = dummyNode.next;

                l1 = l1 != null ? l1.next : null;
                l2 = l2 != null ? l2.next : null;
            }
            return dummyNode.next;
        }

    }
}
