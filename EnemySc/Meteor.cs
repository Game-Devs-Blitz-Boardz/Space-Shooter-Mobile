using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float speed;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Vector2.down * speed;
    }

    void Update()
    {
        
    }

    public override void HurtSequence()
    {

    }

    public override void DeathSequence()
    {

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Destroy(other.gameObject);
        }
    }
}
