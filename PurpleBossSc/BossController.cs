using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState {
    enter,
    fire,
    special,
    death
}

public class BossController : MonoBehaviour
{

    [SerializeField] BossEnter bossEnter;
    [SerializeField] bool test;
    [SerializeField] BossState testState;

    void Start()
    {
        if (test) ChangeState(testState);
    }

    public void ChangeState(BossState state) {
        switch (state) {
            case BossState.enter:
                bossEnter.RunState();
                break;
            case BossState.fire:
                Debug.Log("Do something with");
                break;
            case BossState.special:
                Debug.Log("Do something with");
                break;
            case BossState.death:
                Debug.Log("Do something with");
                break;
        }
    }

}