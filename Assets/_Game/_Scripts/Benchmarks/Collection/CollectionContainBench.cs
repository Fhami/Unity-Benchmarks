using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollectionContainBench : BenchmarkBase
{
    private int[] array;
    private List<int> list;
    private HashSet<int> hashSet;
    private Dictionary<int, int> dict = new();
    
    protected override void Init()
    {
        BenchmarkName = "Collection Contain";
        MaxRecommendedIterations = 5000;

        array = Enumerable.Range(1, MaxRecommendedIterations).ToArray();
        list = Enumerable.Range(1, MaxRecommendedIterations).ToList();
        hashSet = Enumerable.Range(1, MaxRecommendedIterations).ToHashSet();
        dict = Enumerable.Range(1, MaxRecommendedIterations).ToDictionary(_v => _v);
        
        Benchmarks.Add(new BenchmarkData("Array.Contain", () =>
        {
            var _contains = array.Contains(iterationIndex);
        }));
        
        Benchmarks.Add(new BenchmarkData("List.Contain", () =>
        {
            var _contains = list.Contains(iterationIndex);
        }));
        
        Benchmarks.Add(new BenchmarkData("HashSet.Contain", () =>
        {
            var _contains = hashSet.Contains(iterationIndex);
        }));
        
        Benchmarks.Add(new BenchmarkData("Dictionary.ContainKey", () =>
        {
            var _contains = dict.ContainsKey(iterationIndex);
        }));
        
        Benchmarks.Add(new BenchmarkData("Dictionary.ContainValue", () =>
        {
            var _contains = dict.ContainsValue(iterationIndex);
        }));
    }
}
