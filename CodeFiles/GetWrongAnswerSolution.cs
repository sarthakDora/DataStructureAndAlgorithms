using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
	class GetWrongAnswerSolution
	{
        public GetWrongAnswerSolution()
		{
			Console.WriteLine(getWrongAnswers(3, "ABA"));

        }
        private  string getWrongAnswers(int N, string C)
        {
            // Write your code here
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                var character = C[i];
                switch (character)
                {
                    case 'A':
                        sb.Append("B");
                        break;
                    case 'B':
                        sb.Append("A");
                        break;
                }
            }
            return sb.ToString();
        }

    }
}
