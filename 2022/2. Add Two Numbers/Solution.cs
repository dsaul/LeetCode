using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


//You are given two non-empty linked lists representing two non-negative integers.
//The digits are stored in reverse order, and each of their nodes contains a single
//digit. Add the two numbers and return the sum as a linked list.

//You may assume the two numbers do not contain any leading zero, except the number 0 itself.

//Input: l1 = [2, 4, 3], l2 = [5, 6, 4]
//Output:[7,0,8]
//Explanation: 342 + 465 = 807.

//Input: l1 = [0], l2 = [0]
//Output:[0]

//Input: l1 = [9, 9, 9, 9, 9, 9, 9], l2 = [9, 9, 9, 9]
//Output:[8,9,9,9,0,0,0,1]

//[2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,9]
//[5,6,4,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,2,4,3,9,9,9,9]

namespace _2._Add_Two_Numbers
{
	public class ListNode
	{
		public int val;
		public ListNode? next;
		public static ListNode FromEnumerable(IEnumerable<int> otherList)
		{
			ListNode? ret = null;
			ListNode? last = null;

			foreach (int i in otherList)
			{
				ListNode node = new ListNode(i);
				if (ret == null)
				{
					ret = node;
					last = node;
				}
				else
				{
					last!.next = node;
					last = node;
				}
			}

			if (null == ret)
				throw new InvalidOperationException();

			return ret;
		}
		public ListNode(int val = 0, ListNode? next = null)
		{
			this.val = val;
			this.next = next;
		}
	}

	public static class Solution
	{
		public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
		{
			StringBuilder sb1 = new();
			StringBuilder sb2 = new();

			for (ListNode cur = l1; cur != null; cur = cur.next!)
			{
				sb1.Insert(0, cur.val);
			}
			for (ListNode cur = l2; cur != null; cur = cur.next!)
			{
				sb2.Insert(0, cur.val);
			}

			BigInteger i1 = BigInteger.Parse(sb1.ToString());
			BigInteger i2 = BigInteger.Parse(sb2.ToString());

			ListNode? ret = null;
			ListNode? last = null;

			BigInteger sum = i1 + i2;
			string sumStr = $"{sum}";
			for (int i = sumStr.Length-1; i >= 0; i--)
			{
				ListNode node = new ListNode((int)char.GetNumericValue(sumStr[i]));
				if (ret == null)
				{
					ret = node;
					last = node;
				}
				else
				{
					last!.next = node;
					last = node;
				}
			}

			return ret!;

		}
	}
}
