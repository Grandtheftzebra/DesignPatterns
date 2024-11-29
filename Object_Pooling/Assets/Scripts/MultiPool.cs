using System;
using System.Collections.Generic;
using UnityEngine;

public class MultiPool : MonoBehaviour
{
    [SerializeField] private List<PoolData> _pools = new();
    private Dictionary<string, Queue<GameObject>> _poolCollection;

    private void Awake()
    {
        _poolCollection = new();

        foreach (var poolData in _pools)
        {
            CreateObject(poolData);
        }
    }

    private void CreateObject(PoolData poolData)
    {
        GameObject parent = new GameObject($"{poolData.Tag}");
        parent.transform.SetParent(this.transform);
        Queue<GameObject> newPool = new();

        for (int i = 0; i < poolData.Size; i++)
        {
            GameObject newObject = Instantiate(poolData.GO);
            newObject.SetActive(false);
            newObject.transform.SetParent(parent.transform);
            
            newPool.Enqueue(newObject);
        }
        
        _poolCollection.Add(poolData.Tag, newPool);
    }
}
