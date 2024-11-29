using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

[RequireComponent(typeof(Projectile))]
public class GenericPool : MonoBehaviour
{
    public static GenericPool SharedPool;
    
    [SerializeField] private Projectile _pooledObject;
    [SerializeField] private int _defaultSize = 5;
    [SerializeField] private int _maxSize = 10;
    [SerializeField] private bool _collectionChecks = true;

    private object _poolLock = new();
    
    private IObjectPool<Projectile> _pool;
    public IObjectPool<Projectile> Pool
    {
        get
        {
            if (_pool == null)
            {
                lock (_poolLock)
                {
                    _pool = new ObjectPool<Projectile>(
                        CreatePooledObject,
                        GetFromPool,
                        ReleaseIntoPool,
                        DestroyPooledObject,
                        _collectionChecks,
                        _defaultSize,
                        _maxSize
                    );
                }
            }

            return _pool;
        }
    }

    private void Awake() => SharedPool = this;
    
    private Projectile CreatePooledObject()
    {
        Projectile bullet = Instantiate(_pooledObject);
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(this.transform);

        return bullet;
    }

    private void GetFromPool(Projectile bullet) => bullet.gameObject.SetActive(true);

    private void ReleaseIntoPool(Projectile bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.Reset();
    }

    private void DestroyPooledObject(Projectile bullet) => Destroy(bullet.gameObject);
}