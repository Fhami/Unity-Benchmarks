using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectionAddBench : BenchmarkBase
{
    private readonly HashSet<int> hashSet = new();

    private readonly List<int> list1 = new();
    private readonly List<int> list2 = new();

    private readonly Dictionary<int, int> dict1 = new();
    private readonly Dictionary<int, int> dict2 = new();
    private readonly Dictionary<int, int> dict3 = new();

    private List<int> data = new();
    
    protected override void Init()
    {
        BenchmarkName = $"Add to Collection";
        MaxRecommendedIterations = 10000;

        data = Enumerable.Range(1, MaxRecommendedIterations).ToList();
        
        Benchmarks.Add(new BenchmarkData("Hashset.Add", () =>
        {
            hashSet.Add(data[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData("List.Add", () =>
        {
            list1.Add(data[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData("List.Add check not duplicates", () =>
        {
            if (!list2.Contains(data[iterationIndex]))
                list2.Add(data[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData("Dictionary.Add", () =>
        {
            dict1.Add(iterationIndex, data[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData("Dictionary.TryAdd", () =>
        {
            dict2.TryAdd(iterationIndex, data[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData("Dictionary[n] = n", () =>
        {
            dict3[iterationIndex] = data[iterationIndex];
        }));
    }

    public override void OnBenchmarkEnd()
    {
        list1.Clear();
        list2.Clear();
        
        dict1.Clear();
        dict2.Clear();
        dict3.Clear();
        
        hashSet.Clear();
    }
}


