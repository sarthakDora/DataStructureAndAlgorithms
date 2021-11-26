using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo
{
    internal class Kadanes
    {
        public Kadanes()
        {
            //Console.WriteLine(getMaxSumFromArrayUsingKadanes(new int[] { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 }));
            Console.WriteLine(getMaxSumFromArrayUsingKadanes(new int[] { -10 }));
        }
        private int getMaxSumFromArrayUsingKadanes(int[] array)
        {
            var maxSumInHere =0;
            var maxSumSoFar = int.MinValue;

            for (var i = 0; i < array.Length; i++)
            {
                maxSumInHere = Math.Max(maxSumInHere + array[i], array[i]);
                maxSumSoFar = Math.Max(maxSumSoFar, maxSumInHere);
            }

            return maxSumSoFar;
        }
    }
}
