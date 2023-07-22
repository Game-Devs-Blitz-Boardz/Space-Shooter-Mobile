 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] GameObject laserBullet;
    [SerializeField] Transform basicShootPoint;

    [SerializeField] float shootingInterval;
    float intervalReset;

    void Start()
    {
        intervalReset = shootingInterval;
    }

    void Update()
    {
        shootingInterval -= Time.deltaTime;

        if (shootingInterval <= 0) {
            shootingInterval = intervalReset;
            Shoot();
        }
    }

    void Shoot() {
        Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
    }
}
