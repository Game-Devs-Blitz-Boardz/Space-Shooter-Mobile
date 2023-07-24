using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    void OnEnable() {
        int score = PlayerPrefs.GetInt("Score"+SceneManager.GetActiveScene().name, 0);
        scoreText.text = "Score: " + score.ToString();

        int highScore = PlayerPrefs.GetInt("HighScore"+SceneManager.GetActiveScene().name, 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
