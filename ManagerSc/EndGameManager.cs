using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameManager : MonoBehaviour
{

    public static EndGameManager endManager;
    public bool gameOver = false;
    public bool possibleWin;

    PanelController panelController;
    TextMeshProUGUI scoreTextComponent;
    PlayerStats playerStats;
    RewardedAds rewardedAds;
    WinCondition winCondition;


    public int score;
    [HideInInspector] public string levlUnlock = "LevelUnlock";

    void Awake() {
        if (endManager == null) {
            endManager = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);
        winCondition = FindObjectOfType<WinCondition>();
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
        if (gameOver == false && possibleWin == true) {
            WinGame();
        } else if (gameOver == true && possibleWin == false) {
            if (winCondition.canSpawnBoss) {
                LoseGame();
                return;
            }
            AdLoseGame();
        } else if (gameOver == true && possibleWin == true) {
            LoseGame();
        }
    }

    public void RegisterPanelController(PanelController pC) {
        panelController = pC;
    }

    public void RegisterScoreText(TextMeshProUGUI scoreTextComp) {
        scoreTextComponent = scoreTextComp;
    }

    public void RegisterPlayerStats(PlayerStats stats) {
        playerStats = stats;
    }

    public void RegisterRewardedAds(RewardedAds rA) {
        rewardedAds = rA;
    }

    public void WinGame() {
        playerStats.canTakeDmg = false;
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

    public void AdLoseGame() {
        ScoreSet();
        if (rewardedAds.adNum > 0) {
            rewardedAds.adNum--;
            panelController.ActivateAdLose();
        } else {
            panelController.ActivateLose();
        }
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
