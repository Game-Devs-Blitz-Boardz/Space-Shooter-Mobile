using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LaserBullet : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] Rigidbody2D rb;
    ObjectPool <LaserBullet> referencePool;

    void OnEnable()
    {
        rb.velocity = transform.up * speed;
    }

    void OnDisable() {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void SetPool(ObjectPool<LaserBullet> pool) {
        referencePool = pool;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Enemy enemy = other.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
        // Destroy(gameObject);
        if (gameObject.activeSelf)
            referencePool.Release(this);
    }

    public void SetDirectionAndSpeed() {
        rb.velocity = transform.up * speed;
    }

    void OnBecameInvisible() {
        // Destroy(gameObject);
        if (gameObject.activeSelf)
            referencePool.Release(this);
    }
}
