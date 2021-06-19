using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	class RockPaperScissor
	{
		public RockPaperScissor()
		{
			int i = 1;
			while (i < 5)
			{
				Console.WriteLine("Please enter your choice : Rock - 0, Paper - 1, Scissor - 2");
				int userChoice = int.Parse(Console.ReadLine());
				Console.WriteLine(WhoWon(userChoice, new Random().Next(0, 2)));
				i++;
			}
		}
		public string WhoWon(int ID1, int ID2)
		{
			if (ID1 == ID2) return "No win";
			Dictionary<int, int> criteria = new Dictionary<int, int>
			{
				{ 0, 2 },
				{ 1, 0 },//Paper(1) will win against Rock(0)
				{ 2, 1 }
			};

			if (criteria[ID1] == ID2) return "You win";
			else return "Bot win";
		}
	}
}
