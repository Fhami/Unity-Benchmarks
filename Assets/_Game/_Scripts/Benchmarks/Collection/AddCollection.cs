using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AddCollection : BenchmarkBase
{
    private readonly HashSet<int> hashSet = new();

    private readonly List<int> list1 = new();
    private readonly List<int> list2 = new();

    private readonly Dictionary<int, int> dict1 = new();
    private readonly Dictionary<int, int> dict2 = new();
    private readonly Dictionary<int, int> dict3 = new();

    private List<int> valueData = new();
    private readonly List<Data> refData = new();
    
    protected override void Init()
    {
        BenchmarkName = $"Add to Collection";
        MaxRecommendedIterations = 10000;

        for (int _i = 0; _i < MaxRecommendedIterations; _i++)
        {
            refData.Add(new Data()
            {
                Value = Random.Range(0, 1000000),
                Value2 = Random.Range(0f, 1000000f)
            });
        }

        valueData = Enumerable.Range(1, MaxRecommendedIterations).ToList();
        
        Benchmarks.Add(new BenchmarkData("Hashset.Add", () =>
        {
            hashSet.Add(valueData[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData("List.Add", () =>
        {
            list1.Add(valueData[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData("List.Add check not duplicates", () =>
        {
            if (!list2.Contains(valueData[iterationIndex]))
                list2.Add(valueData[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData("Dictionary.Add", () =>
        {
            dict1.Add(iterationIndex, valueData[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData("Dictionary.TryAdd", () =>
        {
            dict2.TryAdd(iterationIndex, valueData[iterationIndex]);
        }));
        
        Benchmarks.Add(new BenchmarkData("Dictionary[n] = n", () =>
        {
            dict3[iterationIndex] = valueData[iterationIndex];
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
    
    public class Data
    {
        public int Value;
        public float Value2;
    }
}


