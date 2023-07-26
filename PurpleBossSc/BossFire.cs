using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : BossBaseState
{
    
    [SerializeField] float speed;
    [SerializeField] float shootRate;
    [SerializeField] GameObject bulletPrefab;
    [Header("Shooting Points")] 
    [SerializeField] Transform[] shootPoints;

    public override void RunState() {
        StartCoroutine(RunFireState());
    }

    public override void StopState() {
        base.StopState();
    }
 
    IEnumerator RunFireState() {
        float shootTimer = 0f;
        float fireStateTimer = 0f;
        float fireStateExitTime = Random.Range(5f, 10f);
        Vector2 targetPos = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));

        while(fireStateTimer <= fireStateExitTime) {
            if (Vector2.Distance(transform.position, targetPos) > 0.01f) {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            } else {
                targetPos = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));
            }
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootRate) {
                for (int i = 0; i <shootPoints.Length; i++) {
                    Instantiate(bulletPrefab, shootPoints[i].position, Quaternion.identity);
                }
                shootTimer = 0f;
            }
            yield return new WaitForEndOfFrame();
            fireStateTimer += Time.deltaTime;
        }
        // int randomPick = Random.Range(0, 2);
        // if (randomPick == 0) {
        //     bossController.ChangeState(BossState.fire);
        // } else {
        //     bossController.ChangeState(BossState.special);
        // }

        bossController.ChangeState(BossState.special);

    }

}
