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
      if (collection == null)
      {
        throw new ArgumentNullException("Listan som ska sorteras kan inte vara null.");
      }
      if (collection.Count <= 1)
      {
        return;
      }

      bool notSorted = true;

      while (notSorted)
      {
        notSorted = false;

        //naive implementation
        for (int i = 0; i < collection.Count - 1; i++)
        {
          if (collection[i].CompareTo(collection[i + 1]) > 0)
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
        throw new ArgumentNullException("Listan som ska sorteras kan inte vara null."); //Kastar exception om listan är null
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
      //Jämför elementen i de två sublistorna och lägg det mindre elementet i den sorterade listan tills en av sublistorna är tom
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
      //Kollar om det finns kvarvarande element i någon av sublistorna och lägger till dem i den sorterade listan
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
      if (collection == null)
      {
        throw new ArgumentNullException("Listan som ska sorteras kan inte vara null."); //Kastar exception om listan är null
      }
      if (collection.Count <= 1)
      {
        return; // Listan är redan sorterad
      }
      //Itererar genom listan av element i den osorterade listan
      for (int i = 1; i < collection.Count; i++)
      {
        //Sparar det nuvarande värdet i en temporär variabel
        var currentValue = collection[i];
        int j = i - 1;

        //Jämför det nuvarande värdet med den sorterade listan och flyttar de större elementen till höger
        while (j >= 0 && collection[j].CompareTo(currentValue) > 0)
        {
          collection[j + 1] = collection[j];
          j--;
        }
        //Placerar det nuvarande värdet på rätt position i den sorterade listan
        collection[j + 1] = currentValue;
      }
    }

    /// <summary>
    /// Sorterar listan med Quick Sort-algoritmen.
    /// </summary>
    /// <param name="collection">Listan som ska sorteras.</param>
    public void QuickSort(IList<T> collection)
    {
      if (collection == null)
      {
        throw new ArgumentNullException("Listan som ska sorteras kan inte vara null."); //Kastar exception om listan är null
      }

      if (collection.Count <= 1)
      {
        // Finns inget att sortera
        return;
      }

      QuickSort(collection, 0, collection.Count - 1);
    }

    /// <summary>
    /// QuickSort som använder start och slut index för att sortera en del av listan.
    /// </summary>
    /// <param name="collection">Listan som ska sorteras.</param>
    /// <param name="start">Startindex för den del av listan som ska sorteras.</param>
    /// <param name="end">Slutindex för den del av listan som ska sorteras.</param>
    public void QuickSort(IList<T> collection, int start, int end)
    {
      if (start < end)
      {
        // Vi tar det första värdet som pivot och hoppas att listan inte är sorterad.
        T pivot = collection[start];

        int low = start;
        int high = end;

        // Infinite loop för att gå igenom hela listan
        while (true)
        {
          // Gå igenom listan från sista till första elementet
          while (collection[high].CompareTo(pivot) >= 0)
          {
            high--;

            if (high <= low)
            {
              break;
            }
          }

          if (high <= low)
          {
            // Höger och vänster del av listan har mötts, sätt pivot och bryt infinite loopen
            collection[low] = pivot;

            break;
          }

          // Flytta värdet som är större än pivot till vänster sida av listan
          collection[low] = collection[high];
          low++;

          // Gå igenom listan från första till sista elementet och flytta värden som är mindre än pivot till höger sida av listan
          while (collection[low].CompareTo(pivot) < 0)
          {
            low++;

            if (low >= high)
            {
              break;
            }
          }

          if (low >= high)
          {
            // Höger och vänster del av listan har mötts, sätt pivot och bryt infinite loopen
            low = high;
            collection[high] = pivot;

            break;
          }

          // Flytta värdet som är mindre än pivot till höger sida av listan
          collection[high] = collection[low];
        }

        // Anropa QuickSort rekursivt på vänster och höger del av listan
        QuickSort(collection, start, low - 1);
        QuickSort(collection, low + 1, end);
      }
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
