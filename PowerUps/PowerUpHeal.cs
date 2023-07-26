using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{
    [SerializeField] int healAmount;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            playerStats.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
