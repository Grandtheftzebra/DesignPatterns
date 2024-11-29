using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Projectile _pooledObject;
    [SerializeField] private int _poolSize;
    
    public static ObjectPool SharedPool;
    
    private Queue<Projectile> _remainingPool = new();

    private void Awake()
    {
        SharedPool = this;

        FillObjectPool();
    }

    private void FillObjectPool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            CreatePooledObject();
        }
    }

    private void CreatePooledObject()
    {
        Projectile bullet = Instantiate(_pooledObject);
        
        _remainingPool.Enqueue(bullet);
        
        bullet.gameObject.transform.SetParent(this.transform);
        bullet.gameObject.SetActive(false);
    }

    public Projectile GetObject()
    {
        if (_remainingPool.Count == 0) return null;

        // Provides thread safety
        lock (_remainingPool)
        {
            Projectile bullet = _remainingPool.Dequeue();
            
            bullet.gameObject.SetActive(true);

            return bullet;
        }

    }

    public void ReturnObject(Projectile bullet)
    {
        // Provides thread safety
        lock (_remainingPool)
        {
            bullet.Reset();
            
            _remainingPool.Enqueue(bullet);
            
            bullet.gameObject.SetActive(false);
        }
    }
}
