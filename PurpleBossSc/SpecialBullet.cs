using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] GameObject miniBullet;
    [SerializeField] Transform[] spawnPoints;

    void Start() {
        rb.velocity = Vector2.down * speed;
        StartCoroutine(Explode());
    }

    void Update() {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    IEnumerator Explode() {
        float randomExplodeTime = Random.Range(1.5f, 2.5f);;
        yield return new WaitForSeconds(randomExplodeTime);
        for (int i = 0; i <spawnPoints.Length; i++) {
            Instantiate(miniBullet, spawnPoints[i].position, spawnPoints[i].rotation);
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) {
       if (other.tag == "Player") {
            other.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Destroy(gameObject);
       }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

}
