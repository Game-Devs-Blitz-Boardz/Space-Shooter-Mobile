using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : Enemy
{

    [SerializeField] BossController bossController;

    public override void HurtSequence()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg")) return;
        anim.SetTrigger("Damage");
    }

    public override void DeathSequence()
    {
        base.DeathSequence();
        bossController.ChangeState(BossState.death);
        Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0,0, Random.Range(0,360)));
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.GetComponent<PlayerStats>().PlayerTakeDamage(damage);
        }
    }

}
