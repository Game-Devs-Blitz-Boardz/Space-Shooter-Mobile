using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;
    [SerializeField] float rotateSpeed;

    [SerializeField] ExampleSO pUSpawnerSO;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Vector2.down * speed;
    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    public override void HurtSequence()
    {

    }

    public override void DeathSequence()
    {
        base.DeathSequence();
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        if (pUSpawnerSO != null) {
            pUSpawnerSO.SpawnPowerUps(transform.position);
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            // Destroy(other.gameObject);
            PlayerStats player = other.GetComponent<PlayerStats>();
            player.PlayerTakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
