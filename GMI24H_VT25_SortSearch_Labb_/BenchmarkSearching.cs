using AlgorithmLib;
using BenchmarkDotNet.Attributes;

namespace GMI24H_VT25_SortSearch_Labb_;

public enum TargetPosition
{
  Beginning,
  End,
  NotFound,
}

[MemoryDiagnoser]
public class BenchmarkSearching
{
  [Params(100, 1000, 10_000, 100_000, 1_000_000)]
  public int N;

  [Params(TargetPosition.Beginning, TargetPosition.End, TargetPosition.NotFound)]
  public TargetPosition Target;

  private const string SentinelBeginning = "000.000.000.001";
  private const string SentinelEnd = "999.999.999.998";
  private const string SentinelNotFound = "999.999.999.999";

  private int _seed = 123;
  private RandomLogGenerator _logGenerator;
  private SearchingManager<string> _searchingManager;
  private List<string> _sortedData;
  private string _target;

  [GlobalSetup]
  public void Setup()
  {
    _logGenerator = new RandomLogGenerator();
    _searchingManager = new SearchingManager<string>();

    var logEntries = _logGenerator.GenerateLogs(N - 2, _seed).ToList();
    _sortedData = logEntries.Select(entry => entry.IpAddress).ToList();

    // Plant unique sentinels
    _sortedData.Add(SentinelBeginning);
    _sortedData.Add(SentinelEnd);
    _sortedData.Sort();

    _target = Target switch
    {
      TargetPosition.Beginning => SentinelBeginning,
      TargetPosition.End => SentinelEnd,
      TargetPosition.NotFound => SentinelNotFound,
      _ => throw new ArgumentOutOfRangeException(),
    };
  }

  [Benchmark]
  public int LinearSearch()
  {
    return _searchingManager.LinearSearch(_sortedData, _target);
  }

  [Benchmark]
  public int BinarySearch()
  {
    return _searchingManager.BinarySearch(_sortedData, _target);
  }

  [Benchmark]
  public int JumpSearch()
  {
    return _searchingManager.JumpSearch(_sortedData, _target);
  }
}
