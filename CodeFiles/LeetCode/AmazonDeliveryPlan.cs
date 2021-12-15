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
            allLocations.Add(new List<int> { -2,1  });
            allLocations.Add(new List<int> { -1, 1 });
            var numDeliveries = 2;
            var output = deliveryPlan2(allLocations, numDeliveries);
        }
        private List<List<int>> deliveryPlan2(List<List<int>> allLocations, int numDeliveries)
        {
            if(allLocations.Count < numDeliveries) return new List<List<int>>();
            var pointsDistance = new  List<List<int>>();
            foreach (var loc in allLocations)
            {
                var distance = Convert.ToInt32(Math.Sqrt(loc[0] * loc[0] + loc[1] * loc[1]));
                pointsDistance.Add(new List<int> { loc[0], loc[1], distance });
            }
            var finalLoc = buildMinHeap(pointsDistance, numDeliveries);
            return finalLoc;
        }
        private List<List<int>> buildMinHeap(List<List<int>> heap, int numOfDeliveries)
        {
            var parentIdx = (heap.Count - 2) / 2;
            for (int i = parentIdx; i >= 0; i--)
            {
                siftDown(i, heap.Count-1, heap);
            }
            var final = new List<List<int>>();
            for (int i = 0; i < numOfDeliveries; i++)
            {
                var val = Remove(heap);
                final.Add(new List<int> { val[0], val[1] });
            }
            return final;
        }
        public List<int> Remove(List<List<int>> heap)
        {
            //Swap first with last index
            swap(0, heap.Count - 1, heap);
            var valueToRemove =  heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            siftDown(0, heap.Count - 1, heap);
            return valueToRemove;

        }
        private void siftDown(int currentIdx, int endIdx,List<List<int>> heap)
        {
            var leftChildIdx = currentIdx * 2 + 1;
            while (leftChildIdx <= endIdx)
            {
                var rightChild = currentIdx * 2 + 2 <= endIdx ? currentIdx * 2 + 2 : -1;
                int idxToSwap;
                if (rightChild != -1 && heap[rightChild][2] < heap[leftChildIdx][2]) //It will check which one among the two childs are smaller and swap the smallest one if parent node it greater
                {
                    idxToSwap = rightChild;
                }
                else idxToSwap = leftChildIdx;
                if (heap[idxToSwap][2] < heap[currentIdx][2])
                {
                    swap(currentIdx, idxToSwap, heap);
                    currentIdx = idxToSwap;
                    leftChildIdx = currentIdx * 2 + 1;
                }
                else if (heap[idxToSwap][2] == heap[currentIdx][2] && Math.Abs(heap[idxToSwap][0]) < Math.Abs(heap[currentIdx][0])) //check for x distance
                {
                    swap(currentIdx, idxToSwap, heap);
                    currentIdx = idxToSwap;
                    leftChildIdx = currentIdx * 2 + 1;
                }
                else return;
            }

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
