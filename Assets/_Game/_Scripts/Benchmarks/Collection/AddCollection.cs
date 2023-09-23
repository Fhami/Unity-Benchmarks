using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AddCollection : BenchmarkBase
{
    //private const int COUNT = 30000;

    private const string Hash1 = "Hashset.Add";

    private const string List1 = "List.Add";
    private const string List2 = "List.Add check not duplicates";

    private const string Dict1 = "Dictionary.Add";
    private const string Dict2 = "Dictionary.TryAdd";
    private const string Dict3 = "Dictionary[n] = n";

    // private Dictionary<string, Dictionary<int, int>> dicts = new();
    // private Dictionary<string, List<int>> lists = new();
    private HashSet<int> hashSet = new();

    protected List<int> list1 = new();
    protected List<int> list2 = new();

    protected Dictionary<int, int> dict1 = new();
    protected Dictionary<int, int> dict2 = new();
    protected Dictionary<int, int> dict3 = new();
    
    private List<int> data = new List<int>();
    
    protected override void Init()
    {
        BenchmarkName = $"Add to Collection";
        MaxRecommendedIterations = 20000;

        data = Enumerable.Range(1, MaxRecommendedIterations).ToList();
        
        //lists.Add(List1, new List<int>());
        //lists.Add(List2, new List<int>());
        
        // dicts.Add(Dict1, new Dictionary<int, int>());
        // dicts.Add(Dict2, new Dictionary<int, int>());
        // dicts.Add(Dict3, new Dictionary<int, int>());
        
        Benchmarks.Add(new BenchmarkData(List1, () =>
        {
            list1.Add(data[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData(List2, () =>
        {
            if (!list2.Contains(data[iterationIndex]))
                list2.Add(data[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData(Hash1, () =>
        {
            hashSet.Add(data[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData(Dict1, () =>
        {
            dict1.Add(iterationIndex, data[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData(Dict2, () =>
        {
            dict2.TryAdd(iterationIndex, data[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData(Dict3, () =>
        {
            dict3[iterationIndex] = data[iterationIndex];
        }));
    }

    public override void OnBenchmarkEnd()
    {
        // foreach (var _dict in dicts.Values)
        //     _dict.Clear();
        //
        // foreach (var _list in lists.Values)
        //     _list.Clear();
        
        list1.Clear();
        list2.Clear();
        
        dict1.Clear();
        dict2.Clear();
        dict3.Clear();
        
        hashSet.Clear();
    }
}


