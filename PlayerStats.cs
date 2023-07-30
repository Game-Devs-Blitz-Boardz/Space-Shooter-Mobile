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
    public bool canTakeDmg = true;

    void OnEnable()
    {
        EndGameManager.endManager.gameOver = false;
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
        StartCoroutine(DamageProtection());
    }

    void Start() {
        playerShooting = GetComponent<PlayerShooting>();
        EndGameManager.endManager.RegisterPlayerStats(this);
        EndGameManager.endManager.possibleWin = false;
    }

    IEnumerator DamageProtection() {
        canTakeDmg = false;
        yield return new WaitForSeconds(1.5f);
        canTakeDmg = true;
    }

    public void PlayerTakeDamage(float damage) {
        if (canTakeDmg == false) return;
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
            // Destroy(gameObject);
            gameObject.SetActive(false);
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
