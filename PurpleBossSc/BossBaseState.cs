using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBaseState : MonoBehaviour
{
    protected Camera mainCam;

    protected float maxLeft;
    protected float maxRight;
    protected float maxUp;
    protected float maxDown;

    protected BossController bossController;

    void Awake() {
        bossController = GetComponent<BossController>();
        mainCam = Camera.main;
    }

    protected virtual void Start()
    {
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.3f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.7f, 0)).x;
        maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;;
        maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, 0.9f)).y;
    }

    public virtual void RunState() {
        
    }

    public virtual void StopState() {
        StopAllCoroutines();
    }

    // IEnumerator SetBoundaries() {
    //     yield return new WaitForSeconds(0.4f);

    //     maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
    //     maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
    //     maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, 0.05f)).y;;
    //     maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;
    // }

}
