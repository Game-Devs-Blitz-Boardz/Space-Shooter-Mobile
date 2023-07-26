using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldActivator : MonoBehaviour
{
    
    [SerializeField] Shield shield;

    public void ActivateShield() {
        if (shield.gameObject.activeSelf == false) {
            shield.gameObject.SetActive(true);
        } else {
            shield.RepairShield();
        }
    }

}
