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
    [SerializeField] Shield shield;

    PlayerShooting playerShooting;

    bool canPlayAnim = true;

    void Start()
    {
        EndGameManager.endManager.gameOver = false;
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
        playerShooting = GetComponent<PlayerShooting>();
    }

    public void PlayerTakeDamage(float damage) {
        if (shield.protection) return;
        health -= damage;
        healthFill.fillAmount = health / maxHealth;
        if (canPlayAnim) {
            anim.SetTrigger("Damage");
            StartCoroutine(AntiSpamAnimation());
        }
        playerShooting.DecreaseUpgrade(1);
        if (health <= 0) {
            EndGameManager.endManager.gameOver = true;
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void AddHealth(int healAmount) {
        health += healAmount;
        if (health > maxHealth) {
            health = maxHealth;
        }
        healthFill.fillAmount = health / maxHealth;
    }

    IEnumerator AntiSpamAnimation() {
        canPlayAnim = false;
        yield return new WaitForSeconds(0.15f);
        canPlayAnim = true;
    }

}
