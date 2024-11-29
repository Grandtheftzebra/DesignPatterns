using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[Serializable]
public class CustomStringEvent : UnityEvent<string>
{
}

public class Player : Publisher
{
    // References
    public UIManager uiManager;
    private Rigidbody _rb;

    [SerializeField] private SOEvent OnPlayerHit;
    [SerializeField] private CustomStringEvent OnPlayerDamaged;
    [SerializeField] private float moveSpeed = 10f;
    public float HorInput => Input.GetAxis("Horizontal") * moveSpeed;

    private int _health = 10;

    public int Health
    {
        get => _health;
        set
        {
            if (value == 0) NotifyAll("PlayerDead");
            else if (value <= 10)
            {
                _health = value;
                NotifyAll("HealthUpdated");
            }
            else
            {
                Debug.Log("Player already has full health.");
            }
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        AddObserver(uiManager);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + Vector3.back * (HorInput * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Health--;
            OnPlayerHit?.NotifyAll();
            
            Debug.Log("Player damaged!");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Health")
        {
            Health++;
            
            Debug.Log("Health collected!");
            Destroy(collision.gameObject);
        }
    }
}