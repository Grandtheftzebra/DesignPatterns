using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 100f;

    private float _horizontalInput;
    private Rigidbody _rb;
    private bool _isShooting;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;
        _isShooting |= Input.GetKey(KeyCode.Space);
    }

    void FixedUpdate()
    {
        if(_isShooting)
        {
            CreateBullet();
        }

        Move();

        _isShooting = false;
    }

    void CreateBullet()
    {
        Projectile newBullet = GenericPool.SharedPool.Pool.Get();

        newBullet.transform.position = this.transform.position;
        Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
        bulletRB.linearVelocity = transform.forward * bulletSpeed;
    }

    void Move()
    {
        _rb.MovePosition(transform.position + transform.right * (_horizontalInput * Time.fixedDeltaTime));
    }
}