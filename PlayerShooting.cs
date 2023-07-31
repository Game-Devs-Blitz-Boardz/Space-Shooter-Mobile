 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] LaserBullet laserBullet;
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

    ObjectPool<LaserBullet> pool;

    float intervalReset;

    void Awake() {
        pool = new ObjectPool<LaserBullet>(CreatePoolObj, OnTakeBulletFromPool, OnReturnBulletFromPool, OnDestroyPoolObj, true, 10, 30);
    }

    void Start()
    {
        intervalReset = shootingInterval;
    }

    void OnDestroyPoolObj(LaserBullet bullet) {
        Destroy(bullet.gameObject);
    }

    LaserBullet CreatePoolObj() {
        LaserBullet bullet = Instantiate(laserBullet, transform.position, transform.rotation);
        laserBullet.SetPool(pool);
        return bullet;
    }

    void OnTakeBulletFromPool(LaserBullet bullet) {
        bullet.gameObject.SetActive(true);
    }

    void OnReturnBulletFromPool(LaserBullet bullet) {
        bullet.gameObject.SetActive(false);
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
                // Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
                pool.Get().transform.position = basicShootPoint.position;
                break;
            case 1:
                pool.Get().transform.position = leftCanon.position;
                pool.Get().transform.position = rightCanon.position;
                // Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
                // Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
                break;
            case 2:
                pool.Get().transform.position = basicShootPoint.position;
                pool.Get().transform.position = leftCanon.position;
                pool.Get().transform.position = rightCanon.position;
                // Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
                // Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
                // Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
                break;
            case 3:
                pool.Get().transform.position = basicShootPoint.position;
                pool.Get().transform.position = leftCanon.position;
                pool.Get().transform.position = rightCanon.position;
                pool.Get().transform.position = secondLeftCanon.position;
                pool.Get().transform.position = secondRightCanon.position;
                // Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
                // Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
                // Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
                // Instantiate(laserBullet, secondLeftCanon.position, Quaternion.identity);
                // Instantiate(laserBullet, secondRightCanon.position, Quaternion.identity);
                break;
            case 4:
                pool.Get().transform.position = basicShootPoint.position;
                pool.Get().transform.position = leftCanon.position;
                pool.Get().transform.position = rightCanon.position;
                pool.Get().transform.position = secondLeftCanon.position;
                pool.Get().transform.position = secondRightCanon.position;

                LaserBullet bulletOne = pool.Get();
                bulletOne.transform.position = leftRotationCanon.position;
                bulletOne.transform.rotation = leftRotationCanon.rotation;
                bulletOne.SetDirectionAndSpeed();

                LaserBullet bulletTwo = pool.Get();
                bulletTwo.transform.position = rightRotationCanon.position;
                bulletTwo.transform.rotation = rightRotationCanon.rotation;
                bulletTwo.SetDirectionAndSpeed();
                // bulletOne.transfrom.position = rightRotationCanon.position;
                // Instantiate(laserBullet, basicShootPoint.position, Quaternion.identity);
                // Instantiate(laserBullet, leftCanon.position, Quaternion.identity);
                // Instantiate(laserBullet, rightCanon.position, Quaternion.identity);
                // Instantiate(laserBullet, secondLeftCanon.position, Quaternion.identity);
                // Instantiate(laserBullet, secondRightCanon.position, Quaternion.identity);
                Instantiate(laserBullet, leftRotationCanon.position, leftRotationCanon.rotation);
                Instantiate(laserBullet, rightRotationCanon.position, rightRotationCanon.rotation);
                break;
            default:
                break;
        }
    }
}
