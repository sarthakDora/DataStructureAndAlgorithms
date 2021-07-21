using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	class BalancedParanthesisOrString
	{
		public BalancedParanthesisOrString()
		{
			var input = "([])(){}(())()()";
			var input2 = "(({{[[([)])]]}}))";
			var input3 = "((AB)(BC)(()";
			Console.WriteLine(BalancedBrackets(input2));
			Console.WriteLine(BalancedParanthesis(input3));
		}
		public bool BalancedBrackets(string str)
		{
			var openingBrackets = "([{";
			var closingBrackets = ")]}";
			Dictionary<string, string> bracketsMap = new Dictionary<string, string>();
			Stack<string> bracketStack = new Stack<string>();


			bracketsMap.Add(")", "(");
			bracketsMap.Add("]", "[");
			bracketsMap.Add("}", "{");
			foreach (var character in str)
			{
				var itm = character.ToString();
				if (openingBrackets.Contains(itm))
				{
					bracketStack.Push(itm);
				}
				else if(closingBrackets.Contains(itm))
				{
					if (bracketStack.Count <= 0) return false;
					if (bracketStack.Peek() == bracketsMap[itm])
						bracketStack.Pop();
					else return false;
				}
			}
			if (bracketStack.Count > 0) return false;
			return true;
		}

		public string BalancedParanthesis(string str) //"((AB)(BC)(()";
		{
			StringBuilder finalStr = new StringBuilder();
			finalStr.Append(str);
			var openingBrackets = "([{";
			var closingBrackets = ")]}";
			Dictionary<string, string> bracketsMap = new Dictionary<string, string>();
			Stack<Dictionary<int, string>> bStack = new Stack<Dictionary<int, string>>();

			bracketsMap.Add(")", "(");
			bracketsMap.Add("]", "[");
			bracketsMap.Add("}", "{");

			for (int i = 0; i < str.Length; i++)
			{
				var currVal = str[i].ToString();
				var idxValPair = new Dictionary<int, string>();
				if (openingBrackets.Contains(currVal))
				{
					idxValPair.Add(i, currVal);
					bStack.Push(idxValPair);
				}
				else if(closingBrackets.Contains(currVal))
				{
					if(bStack.Count <= 0 )
					{
						idxValPair.Add(i, currVal);
						bStack.Push(idxValPair);
					}
					else if(bStack.Peek().ContainsValue(bracketsMap[currVal]))
					{
						bStack.Pop();
					}
					else
					{
						idxValPair.Add(i, currVal);
						bStack.Push(idxValPair);
					}
				}
			}
			if (bStack.Count > 0)
			{
				foreach (var item in bStack)
				{
					foreach (var key in item.Keys)
					{
						finalStr.Remove(key, 1);
					}
				}
			}
			return finalStr.ToString();
		}
	}
}
