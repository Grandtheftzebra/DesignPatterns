using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ComponentSpawner : MonoBehaviour
{
    [SerializeField] private Clone _ogrePrefab;
    [SerializeField] private Clone _ashKnightPrefab;

    private Factory<Clone> _factory = new Factory<Clone>();
    
    private void Awake()
    {
        _factory["Ogre"] = _ogrePrefab;
        _factory["AshKnight"] = _ashKnightPrefab;
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            BaseEnemy clonedEnemy = null;

            float value = Random.value;

            if (value > 0.5f) // Better example for handling this in Factory Pattern Repo.
                clonedEnemy = _factory["Ogre"].Copy<Ogre>();
            else
                clonedEnemy = _factory["AshKnight"].Copy<AshKnight>();
            
            if (clonedEnemy)
                clonedEnemy.Attack();
        }
    }
}
