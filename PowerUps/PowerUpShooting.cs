using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShooting : MonoBehaviour
{

    int increaseAmount = 1;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();
            playerShooting.IncreaseUpgrade(increaseAmount);
            Destroy(gameObject);
        }
    }

}
