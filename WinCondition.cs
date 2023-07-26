using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    float timer;
    [SerializeField] float possibleWinTime;
    [SerializeField] GameObject[] spawners;
    [SerializeField] bool hasBoss;
    public bool canSpawnBoss = false;

    void Start()
    {
        
    }

    void Update()
    {
        // if (EndGameManager.endManager.gameOver == true) return;
        timer += Time.deltaTime;
        if (timer >= possibleWinTime) {
            if (!hasBoss) {
                EndGameManager.endManager.StartResolveSequence();
            } else canSpawnBoss = true;
            for (int i = 0; i < spawners.Length; i++) {
                spawners[i].SetActive(false);
            }
            EndGameManager.endManager.StartResolveSequence();
            gameObject.SetActive(false);
        }
    }
}
