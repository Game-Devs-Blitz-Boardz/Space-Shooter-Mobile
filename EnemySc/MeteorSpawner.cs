using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] meteor;
    [SerializeField] float spawnTime;
    float timer = 0f;
    int i;

    Camera mainCam;
    float maxLeft;
    float maxRight;
    float yPos;

    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime) {
            i = Random.Range(0, meteor.Length);
            GameObject obj = Instantiate(meteor[i], new Vector3(Random.Range(maxLeft, maxRight), yPos, -5), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            float size = Random.Range(0.9f, 1.1f);
            obj.transform.localScale = new Vector3(size, size, 1);
            timer = 0;
        }
    }

    IEnumerator SetBoundaries() {
        yield return new WaitForSeconds(0.4f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;

    }
}
