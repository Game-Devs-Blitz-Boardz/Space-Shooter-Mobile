using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    int hitsToDestroy = 3;
    int hitsTaken = 0;
    public bool protection = false;

    [SerializeField] GameObject[] shieldBases;
    int activeShields;

    void OnEnable() {
        hitsTaken = 0;
        for (int i = 0; i < shieldBases.Length; i++) {
            shieldBases[i].SetActive(true);
            activeShields++;
        }
        protection = true;
    }

    void UpdateUI() {
        shieldBases[activeShields - 1].SetActive(false);
        activeShields--;
    }

    void DamageShield() {
        hitsTaken++;
        UpdateUI();
        if (hitsTaken == hitsToDestroy) {
            protection = false;
            gameObject.SetActive(false);
        }
    }

    public void RepairShield() {
        hitsTaken = 0;
        activeShields = shieldBases.Length;
        for (int i = 0; i < shieldBases.Length; i++) {
            shieldBases[i].SetActive(true);
            activeShields++;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent(out Enemy enemy)) {
            if (other.tag == "Boss")  {
                hitsTaken = 2;
                DamageShield();
                return;
            }
            enemy.TakeDamage(1000);
            DamageShield();
        } else {
            Destroy(other.gameObject);
            DamageShield();
        }
    }
}
