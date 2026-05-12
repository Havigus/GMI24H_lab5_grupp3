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

    public class SortingManager<T> : ISortingManager<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorterar listan med Bubble Sort-algoritmen.
        /// </summary>
        /// <param name="collection">Listan som ska sorteras.</param>
        public void BubbleSort(IList<T> collection)
        {
            throw new NotImplementedException();
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
            while (collection.Count > 1)
            {
                int mid = collection.Count / 2;
                IList<T> left = collection.Take(mid).ToList();
                IList<T> right = collection.Skip(mid).ToList();
                Merge(left, right, collection);
            }

        }
        public void Merge(IList<T> left, IList<T> right, IList<T> collection)
        {
           throw new NotImplementedException();
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
            throw new NotImplementedException();
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
