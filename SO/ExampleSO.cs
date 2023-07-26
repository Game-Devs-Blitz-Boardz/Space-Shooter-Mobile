using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpSpawner", menuName = "SO/PowerUpSpawner")]
public class ExampleSO : ScriptableObject {
    
    public int spawnThreshold;
    public GameObject[] powerUps;

    public void SpawnPowerUps(Vector3 spawnPos) {
        int randomChance = Random.Range(0, 100);
        if (randomChance > spawnThreshold) {
            int randomPowerUp = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomPowerUp], spawnPos, Quaternion.identity);
        }
    }

}
