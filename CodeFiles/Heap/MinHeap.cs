using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgo.Heap
{
    public class MinHeap    
    {
        public List<int> heap = new List<int> ();
        public MinHeap(List<int> array)
        {
            this.heap = buildHeap (array);
        }
        //Time O(n) | Space O(1)
        public List<int> buildHeap(List<int> array)
        {
            var parentIdx = (array.Count - 2) / 2;
            for (int i = parentIdx; i >= 0; i--)
            {
                siftDown(i, array.Count-1, array);
            }
            return array;
        }
        //Time O(log(n)) | Space O(1)
        public void siftDown(int currentIdx, int endIdx, List<int> heap)
        {
            var leftChild = currentIdx * 2 + 1;
            while(leftChild <= endIdx)
            {
                var rightChild = currentIdx * 2 + 2 <= endIdx ? currentIdx * 2 + 2 : -1;
                int idxToSwap;
                if (rightChild != -1 && heap[rightChild] < heap[leftChild]) //It will check which one among the two childs are smaller and swap the smallest one if parent node it greater
                {
                    idxToSwap = rightChild;
                }
                else idxToSwap = leftChild;
                if (heap[idxToSwap] < heap[currentIdx])
                {
                    swap(currentIdx, idxToSwap, heap);
                    currentIdx = idxToSwap;
                    leftChild = currentIdx * 2 + 1;
                }
                else return;
            }
        }
        //Time O(log(n)) | Space O(1)
        public void siftUp(int currentIdx, List<int> heap)
        {
            var parentIdx = Convert.ToInt32(Math.Floor(Convert.ToDecimal(currentIdx - 1 / 2)));
            while(currentIdx > 0 && heap[currentIdx] < heap[parentIdx])
            {
                swap(currentIdx, parentIdx, heap);
                currentIdx = parentIdx;
                parentIdx = Convert.ToInt32(Math.Floor(Convert.ToDecimal(currentIdx - 1 / 2)));
            }
        }
        public int Peek()
        {
            return this.heap[0];
        }
        public int Remove()
        {
            //Swap first with last index
            swap(0, this.heap.Count - 1, this.heap);
            var valueToRemove = this.heap[this.heap.Count-1];
            this.heap.RemoveAt(heap.Count-1);
            siftDown(0, this.heap.Count - 1, this.heap);
            return valueToRemove;

        }
        public void Insert(int value)
        {
            this.heap.Add(value);
            siftUp(this.heap.Count - 1, this.heap);
        }
        private void swap(int firstIdx, int secondIdx, List<int> heap)
        {
            var temp = heap[firstIdx];
            heap[firstIdx] = heap[secondIdx];
            heap[secondIdx] = temp;
        }
    }
}
