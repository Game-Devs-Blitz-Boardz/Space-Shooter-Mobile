using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : Enemy
{

    [SerializeField] float speed;

    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))  return;
        anim.SetTrigger("Damage");
    }

    public override void DeathSequence()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
