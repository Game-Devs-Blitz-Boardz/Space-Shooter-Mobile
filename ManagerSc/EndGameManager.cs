using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameManager : MonoBehaviour
{

    public static EndGameManager endManager;
    public bool gameOver = false;

    PanelController panelController;
    TextMeshProUGUI scoreTextComponent;

    int score;
    [HideInInspector] public string levlUnlock = "LevelUnlock";

    void Awake() {
        if (endManager == null) {
            endManager = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);
    }

    public void UpdateScore(int addScore) {
        score += addScore;
        scoreTextComponent.text = "Score: " + score.ToString();
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

    public void RegisterScoreText(TextMeshProUGUI scoreTextComp) {
        scoreTextComponent = scoreTextComp;
    }

    public void WinGame() {
        ScoreSet();
        panelController.ActivateWin();
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevel > PlayerPrefs.GetInt(levlUnlock, 0)) {
            PlayerPrefs.SetInt(levlUnlock, nextLevel);
        }
    }

    public void LoseGame() {
        ScoreSet();
        panelController.ActivateLose();
    }

    void ScoreSet() {
        PlayerPrefs.SetInt("Score"+SceneManager.GetActiveScene().name, score);
        int highScore = PlayerPrefs.GetInt("HighScore"+SceneManager.GetActiveScene().name, 0);
        if (score > highScore) {
            PlayerPrefs.SetInt("HighScore"+SceneManager.GetActiveScene().name, score);
        }
        score = 0;
    }

}
