using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    int hitsToDestroy = 3;
    int hitsTaken = 0;
    public bool protection = false;

    void OnEnable() {
        hitsTaken = 0;
        protection = true;
    }


    void DamageShield() {
        hitsTaken++;
        if (hitsTaken == hitsToDestroy) {
            protection = false;
            gameObject.SetActive(false);
        }
    }

    public void RepairShield() {
        hitsTaken = 0;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent(out Enemy enemy)) {
            enemy.TakeDamage(1000);
            DamageShield();
        } else {
            Destroy(other.gameObject);
            DamageShield();
        }
    }
}
