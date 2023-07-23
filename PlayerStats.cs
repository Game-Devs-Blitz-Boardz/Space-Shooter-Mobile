using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    [SerializeField] float maxHealth;
    float health;

    [SerializeField] Image healthFill;
    [SerializeField] protected GameObject explosionPrefab;

    void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
    }

    public void PlayerTakeDamage(float damage) {
        health -= damage;
        healthFill.fillAmount = health / maxHealth;
        if (health <= 0) {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
