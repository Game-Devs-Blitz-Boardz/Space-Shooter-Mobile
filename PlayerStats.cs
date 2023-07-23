using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    [SerializeField] float maxHealth;
    float health;

    [SerializeField] Animator anim;
    [SerializeField] Image healthFill;
    [SerializeField] protected GameObject explosionPrefab;

    bool canPlayAnim = true;

    void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
    }

    public void PlayerTakeDamage(float damage) {
        health -= damage;
        healthFill.fillAmount = health / maxHealth;
        if (canPlayAnim) {
            anim.SetTrigger("Damage");
            StartCoroutine(AntiSpamAnimation());
        }
        if (health <= 0) {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    IEnumerator AntiSpamAnimation() {
        canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        canPlayAnim = true;
    }

}
