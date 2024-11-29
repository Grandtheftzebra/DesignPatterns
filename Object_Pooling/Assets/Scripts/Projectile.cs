using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private void Update()
    {
        _lifeTime += 1;
    }

    public void Reset()
    {
        Debug.Log($"Lifetime was {_lifeTime} frames");
        _lifeTime = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Boundary")
        {
            GenericPool.SharedPool.Pool.Release(this);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);
            GenericPool.SharedPool.Pool.Release(this);
        }
    }
}