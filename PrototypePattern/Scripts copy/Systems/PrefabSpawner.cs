using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private BaseEnemy _ogrePrefab;
    [SerializeField] private BaseEnemy _ashKnightPrefab;
    
    private Factory<ICopy> _factory = new Factory<ICopy>();

    private void Awake()
    {
        _factory["Ogre"] = _ogrePrefab;
        _factory["AshKnight"] = _ashKnightPrefab;
    }

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            BaseEnemy clone = null;
            float randomValue = Random.value;

            if (randomValue > 0.5f) // Should be changed with Reflection, number of keys in the dictionary or other stuff that scales well with many enemies.
                clone = (BaseEnemy)_factory["Ogre"].Copy(this.transform);
            else
                clone = (BaseEnemy)_factory["AshKnight"].Copy(this.transform);
            
            if(clone)
                clone.Attack();
        }
    }
}
