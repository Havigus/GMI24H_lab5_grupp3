using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLib
{
    /// <summary>
    /// <summary>
    /// Implementation av olika sorteringsalgoritmer för generiska listor.
    /// </summary>
    /// <typeparam name="T">Typen på elementen som ska sorteras. Måste implementera IComparable<T>.</typeparam>
    public class SortingManager<T> : ISortingManager<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Sorterar listan med Bubble Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void BubbleSort(IList<T> collection)
        {
            bool notSorted = true;

            while (notSorted)
            {
                notSorted = false;

                for (int i = 0; i < collection.Count - 1; i++)
                {
                    if (collection.ElementAt(i).CompareTo(collection.ElementAt(i + 1)) > 0)
                    {
                        (collection[i], collection[i + 1]) = (collection[i + 1], collection[i]);
                        notSorted = true;
                    }
                }
            }
        }

        /// <summary>
        /// Sorterar listan med Merge Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void MergeSort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Listan som ska sorteras kan inte vara null.");
            }
            if (collection.Count <= 1)
            {
                return; // Listan är redan sorterad
            }

            // Dela listan i två delar (Divide)
            int mid = collection.Count / 2;
            IList<T> left = collection.Take(mid).ToList();
            IList<T> right = collection.Skip(mid).ToList();

            //Sorterar båda sidorna rekursivt tills alla sublistor är 1 element (Conquer)
            MergeSort(left);
            MergeSort(right);

            //Slå samman de sorterade delarna
            Merge(left, right, collection);

        }
        /// <summary>
        /// Slår samman två sublistor till en sorterad lista (Merge).
        /// </summary>
        /// <param name="left">Den vänstra sublistan.</param>
        /// <param name="right">Den högra sublistan.</param>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void Merge(IList<T> left, IList<T> right, IList<T> collection)
        {
            int i = 0, j = 0;
            while (i < left.Count && j < right.Count)
            {
                if (left[i].CompareTo(right[j]) <= 0)
                {
                    collection[i + j] = left[i];
                    i++;
                }
                else
                {
                    collection[i + j] = right[j];
                    j++;
                }
            }
            while (i < left.Count)
            {
                collection[i + j] = left[i];
                i++;
            }
            while (j < right.Count)
            {
                collection[i + j] = right[j];
                j++;
            }
        }

        /// <summary>
        /// Sorterar listan med Heap Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void HeapSort(IList<T> collection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sorterar listan med Insertion Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void InsertionSort(IList<T> collection)
        {
            var sortedList = collection[0];

            for (int i = 1; i < collection.Count; i++)
            {
                var currentValue = collection[i];
                int j = i - 1;

                while (j >= 0 && collection[j].CompareTo(currentValue) > 0)
                {
                    collection[j + 1] = collection[j];
                    j--;
                }
                collection[j + 1] = currentValue;
            }
        }

        /// <summary>
        /// Sorterar listan med Quick Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void QuickSort(IList<T> collection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sorterar listan med Selection Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void SelectionSort(IList<T> collection)
        {
            throw new NotImplementedException();
        }
    }
}
