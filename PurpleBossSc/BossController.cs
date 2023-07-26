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
    void Start()
    {
        
    }

    public void ChangeState(BossState state) {
        switch (state) {
            case BossState.enter:
                Debug.Log("Do something with");
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
