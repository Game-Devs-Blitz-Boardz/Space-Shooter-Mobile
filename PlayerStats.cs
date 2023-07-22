using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    [SerializeField] float maxHealth;
    float health;

    void Start()
    {
        health = maxHealth;
    }

    public void PlayerTakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
