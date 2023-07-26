using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            PlayerShieldActivator shieldActivator = other.GetComponent<PlayerShieldActivator>();
            shieldActivator.ActivateShield();
            Destroy(gameObject);
        }
    }
}
