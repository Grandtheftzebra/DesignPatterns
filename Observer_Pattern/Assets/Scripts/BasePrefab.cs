using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePrefab : MonoBehaviour
{
    public float moveSpeed;

    public static event Action OnHealthOrbDestroyed;
    public static event Action OnEnemyOrbDestroyed;

    private void Awake()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.left * moveSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            if (gameObject.tag == "Health") OnHealthOrbDestroyed?.Invoke();
            else
            {
                OnEnemyOrbDestroyed?.Invoke();
            }

            Debug.Log($"{gameObject.tag} destroyed out of bounds...");
            Destroy(this.gameObject);
        }
    }
}