using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLib
{
  /// <summary>
  /// Implementation av olika sökalgoritmer för generiska listor.
  /// </summary>
  /// <typeparam name="T">Typen på elementen som ska sökas i. Måste implementera IComparable<T>.</typeparam>
  public class SearchingManager<T> : ISearchingManager<T>
      where T : IComparable<T>
  {
    /// <summary>
    /// Utför binär sökning i en sorterad lista.
    /// </summary>
    /// <param name="collection">Sorterad lista att söka i.</param>
    /// <param name="target">Värdet som söks.</param>
    /// <returns>Index för träff eller -1 om inget hittas.</returns>
    public int BinarySearch(IList<T> collection, T target)
    {
      var comparer = Comparer<T>.Default;
      // Baserat på pseudokod i kursboken
      int min = 0;
      int max = collection.Count - 1;

      while (min <= max)
      {
        // Hitta mitten
        int mid = (min + max) / 2;
        int cmp = comparer.Compare(target, collection[mid]);

        // Kolla om vi måste söka i vänster eller höger del
        if (cmp < 0)
        {
          max = mid - 1;
        }
        else if (cmp > 0)
        {
          min = mid + 1;
        }
        else
        {
          return mid;
        }
      }

      // Det vi letar efter finns inte i listan
      return -1;
    }

    /// <summary>
    /// Utför exponential search i en sorterad lista.
    /// </summary>
    /// <param name="collection">Sorterad lista att söka i.</param>
    /// <param name="target">Värdet som söks.</param>
    /// <returns>Index för träff eller -1 om inget hittas.</returns>
    public int ExponentialSearch(IList<T> collection, T target)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Utför interpolationssökning. Endast för typer som är int-kompatibla.
    /// </summary>
    /// <param name="collection">Sorterad lista av heltal.</param>
    /// <param name="target">Värdet som söks.</param>
    /// <returns>Index för träff eller -1 om inget hittas.</returns>
    public int InterpolationSearch(IList<T> collection, T target)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Utför jump search i en sorterad lista.
    /// </summary>
    /// <param name="collection">Sorterad lista att söka i.</param>
    /// <param name="target">Värdet som söks.</param>
    /// <returns>Index för träff eller -1 om inget hittas.</returns>
    public int JumpSearch(IList<T> collection, T target)
    {
      var comparer = Comparer<T>.Default;

      int n = collection.Count;
      int jumpsize = (int)Math.Sqrt(n);
      int step = jumpsize;
      int prev = 0;

      while (comparer.Compare(collection[Math.Min(step, n) - 1], target) < 0)
      {
        prev = step;
        step += jumpsize;
        if (prev >= n)
        {
          return -1;
        }
      }
      while (prev < Math.Min(step, n))
      {
        if (comparer.Compare(collection[prev], target) == 0)
        {
          return prev;
        }
        prev++;
      }
      return -1;
    }

    /// <summary>
    /// Utför linjär sökning i en lista.
    /// </summary>
    /// <param name="collection">Listan att söka i.</param>
    /// <param name="target">Värdet som söks.</param>
    /// <returns>Index för träff eller -1 om inget hittas.</returns>
    public int LinearSearch(IList<T> collection, T target)
    {
      var comparer = EqualityComparer<T>.Default;

      for (int i = 0; i < collection.Count; i++)
      {
        if (comparer.Equals(collection[i], target))
        {
          return i;
        }
      }
      return -1;
    }
  }
}
