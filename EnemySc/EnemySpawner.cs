using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Camera mainCam;
    float maxLeft;
    float maxRight;
    float yPos;

    [Header("Enemy Prefabs")]
    [SerializeField] GameObject[] enemy;

    float enemyTimer;
    [Space(15)]
    [SerializeField] float enemySpawnTime;

    [Header("BOSS")]
    [SerializeField] GameObject bossPrefab;
    [SerializeField] WinCondition winCondition;

    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    void Update()
    {
        EnemySpawn();
    }

    void EnemySpawn() {
        enemyTimer += Time.deltaTime;
        if (enemyTimer >= enemySpawnTime) {
            int randomPick = Random.Range(0, enemy.Length);
            Instantiate(enemy[randomPick], new Vector3(Random.Range(maxLeft, maxRight), yPos, 0), Quaternion.identity);
            enemyTimer = 0;
        }
    }

    IEnumerator SetBoundaries() {
        yield return new WaitForSeconds(0.4f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }   

    void OnDisable() {
        Debug.Log("has been disabled");
        if (winCondition.canSpawnBoss == false) return;

        // if (bossPrefab != null) {
            Debug.Log("in this condition");
            Vector2 spawnPos = mainCam.ViewportToWorldPoint(new Vector2(0.5f, 1.2f));
            Instantiate(bossPrefab, spawnPos, Quaternion.identity);
        // }    
    }
}
