using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{

    [SerializeField] CanvasGroup cGroup;
    [SerializeField] GameObject winSreen;
    [SerializeField] GameObject loseSreen;

    void Start()
    {
        
    }

    void ActivateWin() {
        cGroup.alpha = 1;
        winSreen.SetActive(true);
    }

    void ActivateLose() {
        cGroup.alpha = 1;
        loseSreen.SetActive(true);
    }
}
