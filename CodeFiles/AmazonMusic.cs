using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructureAndAlgo
{
    internal class AmazonMusic
    {
        public AmazonMusic()
        {
            var k = 1;
            var arr = new int[] { 1, 0, 1, 0, 1 };
            var output = new int[k];
            for (var i = 0; i < arr.Length -k; i++)
            {
                var l = arr[i] + k + 1;
                var r = arr[i + k];
                if(l >= arr[i] || arr[i] <= r)
                {
                    output.Append(i + 1);
                }
            }
            var f = output;

            var final = findSongs(250, new List<int> { 100, 180, 40, 120, 10 });

        }
        public  List<int> findSongs(int rideDuration, List<int> songDurations)
        {
            var pairQueue = new Queue<List<int>>();
            for (var i = 0; i < songDurations.Count; i++)
            {
                var firstSong = songDurations[i];
                for (var j = i + 1; j < songDurations.Count; j++)
                {
                    var secondSong = songDurations[j];
                    if (firstSong + secondSong == rideDuration - 30)
                    {
                        if(pairQueue.Count > 0)
                        {
                            var exisitngPair = pairQueue.Dequeue();
                            if(firstSong > exisitngPair[0] || firstSong > exisitngPair[1] || secondSong > exisitngPair[0] || secondSong > exisitngPair[0])
                            {
                                pairQueue.Enqueue(new List<int> { firstSong, secondSong, i, j });
                            }
                            else
                            {
                                pairQueue.Enqueue(exisitngPair);
                            }
                        }
                        else
                        {
                            pairQueue.Enqueue(new List<int> { firstSong, secondSong, i, j });
                        }
                    }
                }
            }
            if (pairQueue.Count <= 0) return new List<int> { -1, -1 };
            var finalSongsPair = pairQueue.Dequeue();
            return new List<int> { finalSongsPair[2], finalSongsPair[3] };


        }
        //private List<List<int>> buildMinHeap(List<int> heap, int rideDuration)
        //{
        //    var parentIdx = (heap.Count - 2) / 2;
        //    for (int i = parentIdx; i >= 0; i--)
        //    {
        //        siftDown(i, heap.Count - 1, heap);
        //    }
        //    var final = new List<List<int>>();
        //    for (int i = 0; i < numOfDeliveries; i++)
        //    {
        //        var val = Remove(heap);
        //        final.Add(new List<int> { val[0], val[1] });
        //    }
        //    return final;
        //}
        //private void siftDown(int currentIdx, int endIdx, List<int> heap)
        //{
        //    var leftChildIdx = currentIdx * 2 + 1;
        //    while (leftChildIdx <= endIdx)
        //    {
        //        var rightChild = currentIdx * 2 + 2 <= endIdx ? currentIdx * 2 + 2 : -1;
        //        int idxToSwap;
        //        if (rightChild != -1 && heap[rightChild] < heap[leftChildIdx]) //It will check which one among the two childs are smaller and swap the smallest one if parent node it greater
        //        {
        //            idxToSwap = rightChild;
        //        }
        //        else idxToSwap = leftChildIdx;
        //        if (heap[idxToSwap] < heap[currentIdx])
        //        {
        //            swap(currentIdx, idxToSwap, heap);
        //            currentIdx = idxToSwap;
        //            leftChildIdx = currentIdx * 2 + 1;
        //        }
        //        else if (heap[idxToSwap] == heap[currentIdx][2] && Math.Abs(heap[idxToSwap][0]) < Math.Abs(heap[currentIdx][0])) //check for x distance
        //        {
        //            swap(currentIdx, idxToSwap, heap);
        //            currentIdx = idxToSwap;
        //            leftChildIdx = currentIdx * 2 + 1;
        //        }
        //        else return;
        //    }

        //}
        //private List<int> swap(int i, int j, List<int> array)
        //{
        //    var tmp = array[i];
        //    array[i] = array[j];
        //    array[j] = tmp;
        //    return array;
        //}
    }
}



//public static List<int> predictDays(List<int> day, int k)
//{
//    var left = leftSide(day, day.Count);
//    var right = rightSide(day, day.Count);

//    var finalPredictedDays = new List<int>();
//    for (var i = k; i < day.Count - k; ++i)
//    {
//        if (right[i] - left[i] >= k)
//        {
//            finalPredictedDays.Add(i + 1);
//        }
//    }
//    return finalPredictedDays;

//}
//public static List<int> leftSide(List<int> days, int k)
//{
//    var stack = new Stack<int>();
//    List<int> final = new List<int>();
//    for (var i = 0; i < k; i++)
//    {
//        while (stack.Count > 0 && days[i] <= days[stack.Peek()])
//        {
//            stack.Pop();
//        }
//        if (stack.Count <= 0)
//        {
//            final.Add(-1);
//        }
//        else final.Add(stack.Peek());
//        stack.Push(i);
//    }
//    return final;
//}
//public static List<int> rightSide(List<int> days, int k)
//{
//    var stack = new Stack<int>();
//    List<int> final = new List<int>();
//    for (var i = k - 1; i >= 0; i--)
//    {
//        while (stack.Count > 0 && days[i] <= days[stack.Peek()])
//        {
//            stack.Pop();
//        }
//        if (stack.Count <= 0)
//        {
//            final.Add(k);
//        }
//        else final.Add(stack.Peek());
//        stack.Append(i);
//    }
//    return final.OrderByDescending(x => x).ToList();
//}
