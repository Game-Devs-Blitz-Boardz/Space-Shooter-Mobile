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
    public bool hasWatchedAd = false;

    void OnEnable()
    {
        if (EndGameManager.endManager.gameOver == false) {
            gameObject.SetActive(true);
        }
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (hasWatchedAd) Debug.Log("this workds ");

        if (EndGameManager.endManager.gameOver == true) {

            for (int i = 0; i < spawners.Length; i++) {
                spawners[i].SetActive(false);
            }

            EndGameManager.endManager.StartResolveSequence();
            gameObject.SetActive(false);
            return;
        }

        if (timer >= possibleWinTime) {
            
            
            if (!hasBoss) {
                EndGameManager.endManager.possibleWin = true;
                EndGameManager.endManager.StartResolveSequence();
                gameObject.SetActive(false); //
            } else canSpawnBoss = true;

            for (int i = 0; i < spawners.Length; i++) {
                spawners[i].SetActive(false);
            }

            // EndGameManager.endManager.StartResolveSequence();
            // gameObject.SetActive(false);
        }
    }

    public void ActivateSpawners() {
        for (int i = 0; i < spawners.Length; i++) {
            spawners[i].SetActive(true);
        }
    }

}
