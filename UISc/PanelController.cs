using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{

    [SerializeField] CanvasGroup cGroup;
    [SerializeField] GameObject winSreen;
    [SerializeField] GameObject loseSreen;
    [SerializeField] GameObject adLoseSreen;

    void Start()
    {
        EndGameManager.endManager.RegisterPanelController(this);
    }

    public void ActivateWin() {
        cGroup.alpha = 1;
        winSreen.SetActive(true);
    }

    public void ActivateLose() {
        cGroup.alpha = 1;
        loseSreen.SetActive(true);
    }

    public void ActivateAdLose() {
        cGroup.alpha = 1;
        adLoseSreen.SetActive(true);
    }

    public void DeactivateAdLose() {
        cGroup.alpha = 0;
        adLoseSreen.SetActive(false);
    }
}
