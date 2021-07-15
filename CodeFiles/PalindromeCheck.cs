using System;
using System.Collections.Generic;
using System.Text;



namespace DataStructureAndAlgo
{
	public class PalindromeCheck
	{
		public PalindromeCheck()
		{
			Console.WriteLine(isPalindrome("abcdcba"));
			Console.WriteLine(isPalindrome("test"));
			Console.WriteLine(isPalindromeV2("abcdcba"));
			Console.WriteLine(isPalindromeV2("test"));
			Console.WriteLine(isPalindromeV3("abcdcba"));
			Console.WriteLine(isPalindromeV4("abcdcba"));
			Console.WriteLine(isPalindromeV4("test"));

			Console.WriteLine(isPalindromeV5("abcdcba"));
			Console.WriteLine(isPalindromeV5("test"));
		}
		private bool isPalindrome(string str)
		{
			if (string.IsNullOrEmpty(str)) return false;

			string newStr = "";
			for (int i = str.Length - 1; i >= 0; i--)
			{
				newStr += str[i];
			}
			return str.Equals(newStr);
		}
		private bool isPalindromeV2(string str)
		{
			if (string.IsNullOrEmpty(str)) return false;

			List<char> newstr = new List<char>();
			for (int i = str.Length - 1; i >= 0; i--)
			{
				newstr.Add(str[i]);
			}
			return str == string.Join("", newstr);
		}
		//With Recurssion
		private bool isPalindromeV3(string str, int i = 0)
		{
			var j = str.Length - 1 - i;
			if (i >= j) return true;

			else if(str[i] == str[j] && isPalindromeV3(str, i + 1))
			{
				return true;
			}
			return false;
		}
		//With Tail Recurssion
		private bool isPalindromeV4(string str, int i = 0)
		{
			var j = str.Length - 1 - i;
			if (i >= j) return true;			
			if(str[i] != str[j] )
			{
				return false;
			}
			return isPalindromeV4(str, i + 1);
		}
		//With best time and space complexity using pointers 
		//Time O(n) and Space O(1)
		private bool isPalindromeV5(string str)
		{
			int leftPtr = 0;
			int rightPtr = str.Length - 1;
			while(leftPtr < rightPtr)
			{
				if (str[leftPtr] != str[rightPtr]) return false;
				leftPtr += 1;
				rightPtr -= 1;
			}
			return true;
		}
	}
}
