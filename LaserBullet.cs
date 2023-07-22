using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] Rigidbody2D rb;


    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Enemy enemy = other.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
