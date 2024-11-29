using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyManager : MonoBehaviour
{
    private int _healthMissed = 0;
    private int _playerHitCount = 0;
    private void OnEnable()
    {
        BasePrefab.OnHealthOrbDestroyed += HealthOrbDestroyed;
        BasePrefab.OnEnemyOrbDestroyed += EnemyDestroyed;
    }

    private void OnDisable()
    {
        BasePrefab.OnHealthOrbDestroyed -= HealthOrbDestroyed;
        BasePrefab.OnEnemyOrbDestroyed -= EnemyDestroyed;
    }

    private void HealthOrbDestroyed()
    {
        _healthMissed++;

        Debug.Log("Health destroyed!");
        
        if (_healthMissed == 3)
        {
            Debug.Log("New achievement unlocked. Destroyer of health and blessings!");
            BasePrefab.OnHealthOrbDestroyed -= HealthOrbDestroyed;
        }
    }

    private void EnemyDestroyed()
    {
        Debug.Log("Destroy your first enemy orb!");
        BasePrefab.OnEnemyOrbDestroyed -= EnemyDestroyed;

    }

    public void PlayerHitEvent(string message)
    {
        Debug.Log($"First blood. You were hit the first time. Congrats!");
        Debug.Log(message);
    }
}