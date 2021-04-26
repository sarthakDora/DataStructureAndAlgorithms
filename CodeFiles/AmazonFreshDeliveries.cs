using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructureAndAlgo
{
	public class AmazonFreshDeliveries
	{
		public AmazonFreshDeliveries()
		{
			List<int> loc1 = new List<int>();
			loc1.Add(1);
			loc1.Add(2);

			List<int> loc2 = new List<int>();
			loc2.Add(3);
			loc2.Add(4);


			List<int> loc3 = new List<int>();
			loc3.Add(1);
			loc3.Add(-1);

			List<int> loc4 = new List<int>();
			loc4.Add(5);
			loc4.Add(0);


			List<List<int>> allLocations = new List<List<int>>() { loc1, loc4, loc2 };

			deliveryPlanV2(allLocations, 2);
			deliveryPlan(allLocations, 2);
			deliveryPlanV3(allLocations, 2);

		}
		private List<List<int>> deliveryPlan(List<List<int>> allLocations, int numDeliveries)
		{
			List<List<int>> finalDeliveryPlan = new List<List<int>>();
			Dictionary<List<int>, double> distances = new Dictionary<List<int>, double>();

			foreach (var loc in allLocations)
			{
				var distance = Math.Sqrt((loc[0] * loc[0]) + (loc[1] * loc[1]));
				if(!distances.ContainsKey(loc)) distances.Add(loc, distance);
			}
			finalDeliveryPlan = distances.OrderBy(d => d.Value).ThenBy(key => key.Key[0]).Take(numDeliveries).Select(k => k.Key).ToList();

			return finalDeliveryPlan;
		}
		private List<List<int>> deliveryPlanV2(List<List<int>> allLocations, int numDeliveries)
		{
			var locationsWithDistance = new List<List<int>>(allLocations.Count);
			foreach (var loc in allLocations)
			{
				var temp = new List<int>(loc);
				temp.Add(loc[0] * loc[0] + loc[1] * loc[1]);
				locationsWithDistance.Add(temp);
			}
			locationsWithDistance.Sort((l1, l2) => l1[2] == l2[2] ? l1[0].CompareTo(l2[0]) : l1[2].CompareTo(l2[2]));
			var rslt = locationsWithDistance.GetRange(0, numDeliveries);
			foreach (var loc in rslt)
				loc.RemoveAt(2); // remove the distance that we added so we get just x&y
			return rslt;
		}
		private List<List<int>> deliveryPlanV3(List<List<int>> allLocations, int numDeliveries)
		{
			var final = allLocations.OrderBy(x => x[0] * x[0] + x[1] * x[1]).ThenBy(y => y[0]).Take(numDeliveries).ToList();
			return final;
		}
	}
}
