using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    float timer;
    [SerializeField] float possibleWinTime;
    [SerializeField] GameObject[] spawners;

    void Start()
    {
        
    }

    void Update()
    {
        // if (EndGameManager.endManager.gameOver == true) return;
        timer += Time.deltaTime;
        if (timer >= possibleWinTime) {
            for (int i = 0; i < spawners.Length; i++) {
                spawners[i].SetActive(false);
            }
            EndGameManager.endManager.StartResolveSequence();
            gameObject.SetActive(false);
        }
    }
}
