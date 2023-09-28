using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle.Algorithms
{
    [Serializable]
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> _items;
        private int lastIndex => _items.Count > 0 ? _items.Count - 1 : 0;
        public bool IsEmpty => _items.Count == 0;


        public PriorityQueue()
        {
            _items = new List<T>();
        }

        public void Enqueue(T item)
        {
            _items.Add(item);

            ShiftUp(lastIndex);
        }

        public T Dequeue()
        {
            T result = _items[0];

            Swap(0, lastIndex);
            _items.RemoveAt(lastIndex);
            ShiftDown(0);

            return result;
        }

        private void ShiftUp(int i)
        {
            int currentIndex = i;
            int parentIndex = parent(currentIndex);
            while(currentIndex > 0 && _items[parentIndex].CompareTo(_items[currentIndex]) < 0)
            {
                Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = parent(currentIndex);
            }
        }

        private void ShiftDown(int i)
        {
            int maxIndex = i;

            // Left Child
            int l = leftChild(i);

            if (l <= lastIndex && _items[l].CompareTo(_items[maxIndex]) > 0)
            {
                maxIndex = l;
            }

            // Right Child
            int r = rightChild(i);

            if (r <= lastIndex && _items[r].CompareTo(_items[maxIndex]) > 0)
            {
                maxIndex = r;
            }

            // If i not same as maxIndex
            if (i != maxIndex)
            {
                Swap(i, maxIndex);
                ShiftDown(maxIndex);
            }
        }

        private void Swap(int i1, int i2)
        {
            _items.Swap(i1, i2);
        }

        private int parent(int i)
        {
            return (i - 1) / 2;
        }

        private int leftChild(int i)
        {
            return (i * 2) + 1;
        }

        private int rightChild(int i)
        {
            return (i * 2) + 2;
        }
    }
}
