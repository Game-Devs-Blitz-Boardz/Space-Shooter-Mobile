using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    [SerializeField] float maxHealth;
    float health;

    [SerializeField] Image healthFill;

    void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
    }

    public void PlayerTakeDamage(float damage) {
        health -= damage;
        healthFill.fillAmount = health / maxHealth;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
