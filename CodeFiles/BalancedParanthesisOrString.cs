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
			Console.WriteLine(BalancedBrackets(input2));	
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
	}
}
