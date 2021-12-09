using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAndAlgo.LeetCode
{
    public  class AmazonDeliveryPlan
    {
        public AmazonDeliveryPlan()
        {
            var allLocations = new List<List<int>>();
            allLocations.Add(new List<int> { 1, 2 });
            allLocations.Add(new List<int> { 1, -1 });
            allLocations.Add(new List<int> { 3, 4 });
            var numDeliveries = 2;
            var output = deliveryPlan(allLocations, numDeliveries);
        }
        private List<List<int>> deliveryPlan(List<List<int>> allLocations, int numDeliveries)
        {
            var coordinatesAndDistances = new Dictionary<List<int>, double>();
            foreach (var loc in allLocations)
            {
                var distance = Math.Sqrt(loc[0] * loc[0] + loc[1] * loc[1]);
                coordinatesAndDistances.Add(loc, distance);
            }
            var sortedDeliveryPlans = sortIt(coordinatesAndDistances, allLocations);
            var finalj = sortedDeliveryPlans.Take(numDeliveries).ToList();
            return finalj;
        }
        
        private List<List<int>> sortIt(Dictionary<List<int>, double> allLocationsWithDist, List<List<int>> allLocations)
        {
            int currIndex = 0;
            while (currIndex < allLocations.Count - 1)
            {
                var smallestIndx = currIndex;
                for (int i = currIndex + 1; i < allLocations.Count; i++)
                {
                    double currDistance;
                    allLocationsWithDist.TryGetValue(allLocations[smallestIndx], out currDistance);
                    double nextDistance;
                    allLocationsWithDist.TryGetValue(allLocations[i], out nextDistance);

                    if (currDistance > nextDistance)
                    {
                        smallestIndx = i;
                    }
                }

                swap(currIndex, smallestIndx, allLocations);
                currIndex += 1;


            }
            return allLocations;

        }
        private List<List<int>> swap(int i, int j, List<List<int>> array)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
            return array;
        }
    }
}
