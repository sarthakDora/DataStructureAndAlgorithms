using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo.Graph
{
    internal class SingleCycleCheck
    {
        public SingleCycleCheck()
        {
            //Console.WriteLine(hasSingleCycle(new List<int>() { 2,3,1,-4,-4,2}));
            Console.WriteLine(hasSingleCycle(new List<int>() { 0,1,1,1,1 }));
        }
        private bool hasSingleCycle(List<int> array)
        {
            var numberOfNodesVisited = 0;
            var currentIdx = 0;
            while (numberOfNodesVisited < array.Count)
            {
                if (numberOfNodesVisited > 0 && currentIdx ==0) return false; // This means we have multiple cycles
                numberOfNodesVisited += 1;
                currentIdx = getJumpIdx(array, currentIdx);
            }
            return currentIdx == 0;
        }

        int getJumpIdx(List<int> array, int currentIdx)
        {
            var jump = array[currentIdx];
            var nextIdx = (currentIdx + jump) % array.Count; // this will make any bigger number into a cycle.
                                                             // Example [26,1,2,3,4]. Now mod of 0+26%5 would be 1.
                                                             // So new idx would be 1
            return nextIdx >= 0 ? nextIdx : nextIdx + array.Count;
        }
    }
   

}
