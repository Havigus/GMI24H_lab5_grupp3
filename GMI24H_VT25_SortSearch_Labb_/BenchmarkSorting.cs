using AlgorithmLib;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Filters;

namespace GMI24H_VT25_SortSearch_Labb_;

public enum InputShape { Random, Sorted }

[Config(typeof(Config))]
[MemoryDiagnoser]
public class BenchmarkSorting
{
  private class Config : ManualConfig
  {
    private const int SlowSortMaxN = 10000;
    private static readonly string[] SlowSort = ["BubbleSort", "InsertionSort"];

    public Config()
    {
      AddFilter(new SimpleFilter(benchmark =>
      {
        var method = benchmark.Descriptor.WorkloadMethod.Name;
        var n = (int)benchmark.Parameters["N"];
        var input = (InputShape)benchmark.Parameters["Shape"];

        if (method == "InsertionSort" && input == InputShape.Sorted)
        {
          return true;
        }

        if (method == "QuickSort" && input == InputShape.Sorted && n > SlowSortMaxN)
        {
          return false;
        }

        if (SlowSort.Contains(method) && n > SlowSortMaxN)
        {
          return false;
        }
        return true;
      }));
    }
  }

  [Params(100, 1000, 10000, 100000, 1000000)]
  public int N;

  [Params(InputShape.Random, InputShape.Sorted)]
  public InputShape Shape;

  private int _seed = 123;
  private RandomLogGenerator _logGenerator;
  private SortingManager<string> _sortingManager;
  private List<string> _logs;
  private List<string> _copyLogs;

  [GlobalSetup]
  public void Setup()
  {
    _logGenerator = new RandomLogGenerator();
    _sortingManager = new SortingManager<string>();
    var logEntries = _logGenerator.GenerateLogs(N, _seed).ToList();
    _logs = logEntries.Select(entry => entry.IpAddress).ToList();

    if (Shape == InputShape.Sorted)
    {
      _logs.Sort();
    }
  }

  [IterationSetup]
  public void IterationSetup()
  {
    _copyLogs = _logs.ToList();
  }

  [Benchmark]
  public void BubbleSort()
  {
    _sortingManager.BubbleSort(_copyLogs);
  }

  [Benchmark]
  public void QuickSort()
  {
    _sortingManager.QuickSort(_copyLogs);
  }

  [Benchmark]
  public void MergeSort()
  {
    _sortingManager.MergeSort(_copyLogs);
  }

  [Benchmark]
  public void InsertionSort()
  {
    _sortingManager.InsertionSort(_copyLogs);
  }
}
