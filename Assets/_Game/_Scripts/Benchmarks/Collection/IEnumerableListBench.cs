using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IEnumerableListBench : BenchmarkBase
{
    private const int Count = 500;

    private List<int> list1 = new();
    private List<int> list2 = new();
    private List<int> list3 = new();

    protected override void Init()
    {
        BenchmarkName = "IEnumerable vs List";
        MaxRecommendedIterations = 10000;

        list1 = Enumerable.Range(1, Count).ToList();
        list2 = Enumerable.Range(1, Count).ToList();
        list3 = Enumerable.Range(1, Count).ToList();

        Benchmarks.Add(new BenchmarkData("Iterate IEnumerable", () =>
        {
            foreach (var _int in GetIEnum())
            {
            }
        }));

        Benchmarks.Add(new BenchmarkData("Iterate List", () =>
        {
            foreach (var _int in GetList())
            {
            }
        }));

        Benchmarks.Add(new BenchmarkData("Multi-call IEnumerable", () =>
        {
            var _ints = GetIEnum();
            var _count = _ints.Count();

            foreach (var _int in _ints)
            {
            }

            foreach (var _int in _ints)
            {
            }
        }));

        Benchmarks.Add(new BenchmarkData("Multi-call IEnumerable.ToList", () =>
        {
            var _ints = GetIEnum().ToList();
            var _count = _ints.Count();
            
            foreach (var _int in _ints)
            {
            }
            
            foreach (var _int in _ints)
            {
            }
        }));

        Benchmarks.Add(new BenchmarkData("Multi-call List", () =>
        {
            var _ints = GetList();
            var _count = _ints.Count;
            
            foreach (var _int in _ints)
            {
            }
            
            foreach (var _int in _ints)
            {
            }
        }));
    }

    private IEnumerable<int> GetIEnum()
    {
        foreach (var _int in list1)
            yield return _int;

        foreach (var _int in list2)
            yield return _int;

        foreach (var _int in list3)
            yield return _int;
    }

    private List<int> GetList()
    {
        var _list = new List<int>();

        foreach (var _int in list1)
            _list.Add(_int);

        foreach (var _int in list2)
            _list.Add(_int);

        foreach (var _int in list3)
            _list.Add(_int);

        return _list;
    }
}