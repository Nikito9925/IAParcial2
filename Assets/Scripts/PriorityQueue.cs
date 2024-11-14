using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue<T>
{
    Dictionary<T, float> _allNodes = new Dictionary<T, float>();

    public int Count { get { return _allNodes.Count; } }

    public void Put(T node, float cost)
    {
        if (_allNodes.ContainsKey(node)) _allNodes[node] = cost;
        else _allNodes.Add(node, cost);
    }

    public T Get()
    {
        T node = default;
        float lowestValue = Mathf.Infinity;

        foreach (var item in _allNodes)
        {
            if (item.Value < lowestValue)
            {
                lowestValue = item.Value;
                node = item.Key;
            }
        }
        _allNodes.Remove(node);
        return node;
    }
}
