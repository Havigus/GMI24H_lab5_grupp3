using AlgorithmLib;
using BenchmarkDotNet.Attributes;

namespace GMI24H_VT25_SortSearch_Labb_;

public class BenchmarkSortingUnSorted{
    
    [Params(100,1000,10000,100000,1000000)]
    public int N;

    private int _seed = 123;
    private RandomLogGenerator _logGenerator;
    private SortingManager<string> _sortingManager;
    private List<String> _logs;
    private List<string> _copyLogs;

    [GlobalSetup]
    public void Setup(){
        _logGenerator = new RandomLogGenerator();
        _sortingManager = new SortingManager<string>();
        var _logEntries = _logGenerator.GenerateLogs(N, _seed).ToList();
        _logs = _logEntries.Select(entry => entry.IpAddress).ToList();
    }

    [IterationSetup]
    public void IterationSetup(){
       _copyLogs = _logs.ToList(); 
    }

    [Benchmark]
    public void BubbleSort(){
        _sortingManager.BubbleSort(_copyLogs);
    }

    [Benchmark]
    public void QuickSort(){
        _sortingManager.QuickSort(_copyLogs);
    }

    [Benchmark]
    public void MergeSort(){
        _sortingManager.MergeSort(_copyLogs);
    }

    [Benchmark]
    public void InsertionSort(){
        _sortingManager.InsertionSort(_copyLogs);
    }
}

public class BenchmarkSortingSorted{

    [Params(100,1000,10000,100000,1000000)]
    public int N;

    private int _seed = 123;
    private RandomLogGenerator _logGenerator;
    private SortingManager<string> _sortingManager;
    private List<String> _logs;
    private List<string> _copyLogs;

    [GlobalSetup]
    public void Setup(){
        _logGenerator = new RandomLogGenerator();
        _sortingManager = new SortingManager<string>();
        var _logEntries = _logGenerator.GenerateLogs(N, _seed).ToList();
        _logs = _logEntries.Select(entry => entry.IpAddress).ToList();
        _logs.Sort();
    }

    [IterationSetup]
    public void IterationSetup(){
       _copyLogs = _logs.ToList();
    }

    [Benchmark]
    public void BubbleSort(){
        _sortingManager.BubbleSort(_copyLogs);
    }

    [Benchmark]
    public void QuickSort(){
        _sortingManager.QuickSort(_copyLogs);
    }

    [Benchmark]
    public void MergeSort(){
        _sortingManager.MergeSort(_copyLogs);
    }

    [Benchmark]
    public void InsertionSort(){
        _sortingManager.InsertionSort(_copyLogs);
    }
}