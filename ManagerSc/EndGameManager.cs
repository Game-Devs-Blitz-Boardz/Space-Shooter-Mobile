using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{

    public static EndGameManager endManager;
    public bool gameOver = false;

    PanelController panelController;

    void Awake() {
        if (endManager == null) {
            endManager = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);
    }

    public void StartResolveSequence()
    {
        StartCoroutine(ResolveSequence());
    }

    IEnumerator ResolveSequence() {
        yield return new WaitForSeconds(2f);
        ResloveGame();
    }

    public void ResloveGame() {
        if (gameOver == false) {
            WinGame();
        } else if (gameOver == true){
            LoseGame();
        }
    }

    public void RegisterPanelController(PanelController pC) {
        panelController = pC;
    }

    public void WinGame() {
        panelController.ActivateWin();
    }

    public void LoseGame() {
        panelController.ActivateLose();
    }

}
