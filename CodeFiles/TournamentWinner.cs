using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructureAndAlgo
{
	public class TournamentWinner
	{
		public TournamentWinner()
		{
			var match1 = new List<string>() { "HTML", "C#" };
			var match2 = new List<string>() { "C#", "Python" };
			var match3 = new List<string>() { "Python", "HTML" };
			List<List<string>> competitions = new List<List<string>>() { match1, match2, match3 };
			List<int> results = new List<int>() { 0, 0, 1 };
			var winner = TournamentWinnerV1(competitions, results);
			var winner2 = TournamentWinnerV2(competitions, results);
			Console.WriteLine($"And the Winner is {winner} .............. Yoooooooooooo");
			Console.WriteLine($"And the Winner for version 2  is {winner2} .............. Yoooooooooooo");
		}
		public string TournamentWinnerV1(List<List<string>> competitions, List<int> results)
		{
			Dictionary<string, int> teamsFinalResult = new Dictionary<string, int>();
			int rsltIndex = 0;

			foreach (var match in competitions)
			{
				//teamsFinalResult = results[rsltIndex] == 1 ? updateScore(teamsFinalResult, match[0]) : updateScore(teamsFinalResult, match[1]);
				if (results[rsltIndex] == 1) { updateScore(teamsFinalResult, match[0]); } 
				else { updateScore(teamsFinalResult, match[1]); }

				rsltIndex++;
			}
			return teamsFinalResult.OrderByDescending(v => v.Value).FirstOrDefault().Key;
		}
		private void updateScore(Dictionary<string, int> teamsFinalResult, string match)
		{
			if (teamsFinalResult.ContainsKey(match))
			{
				teamsFinalResult[match] = teamsFinalResult[match] + 3;
			}
			else
			{
				teamsFinalResult.Add(match, 3);
			}
			//return teamsFinalResult;
		}
		public string TournamentWinnerV2(List<List<string>> competitions, List<int> results)
		{
			int home_team_won = 1;
			string currentBestTeam = "";
			Dictionary<string, int> scores = new Dictionary<string, int>();
			scores[currentBestTeam] = 0;

			for (int i = 0; i < competitions.Count; i++)
			{
				List<string> competition = competitions[i];
				int result = results[i];

				string homeTeam = competition[0];
				string awayTeam = competition[1];

				string winnerTeam = result == home_team_won ? homeTeam : awayTeam;
				updateScores(winnerTeam, 3, scores);

				if(scores[winnerTeam] > scores[currentBestTeam])
				{
					currentBestTeam = winnerTeam;
				}
			}

			return currentBestTeam;
		}
		private void updateScores(string team, int points, Dictionary<string, int> scores )
		{
			if (!scores.ContainsKey(team)) scores[team] = 0;
			scores[team] = scores[team] + points;
		}
	}
}
