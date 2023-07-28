 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] GameObject laserBullet;
    [SerializeField] float shootingInterval;

    [Header("Basic Attack")]
    [SerializeField] Transform basicShootPoint;

    [Header("Upgrade Points")]
    [SerializeField] Transform leftCanon;
    [SerializeField] Transform rightCanon;
    [SerializeField] Transform secondLeftCanon;
    [SerializeField] Transform secondRightCanon;

    [Header("Upgrade Rotation Points")]
    [SerializeField] Transform leftRotationCanon;
    [SerializeField] Transform rightRotationCanon;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;

    int upgradeLevel = 0;

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

    public void IncreaseUpgrade(int increaseAmount) {
        upgradeLevel += increaseAmount;
        if (upgradeLevel > 4) {
            upgradeLevel = 4;
        }
    }

    public void DecreaseUpgrade(int decreaseAmount) {
        upgradeLevel -= decreaseAmount;
        if (upgradeLevel < 0) {
            upgradeLevel = 0;
        }
    }

    void Shoot() {
        audioSource.Play();
        switch(upgradeLevel) {
            case 0:
                Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
                Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
                Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
                Instantiate(laserBullet, secondLeftCanon.position, Quaternion.identity);
                Instantiate(laserBullet, secondRightCanon.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
                Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
                Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
                Instantiate(laserBullet, secondLeftCanon.position, Quaternion.identity);
                Instantiate(laserBullet, secondRightCanon.position, Quaternion.identity);
                Instantiate(laserBullet, leftRotationCanon.position, leftRotationCanon.rotation);
                Instantiate(laserBullet, rightRotationCanon.position, rightRotationCanon.rotation);
                break;
            default:
                break;
        }
    }
}
