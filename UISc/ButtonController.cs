using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadLevelString(string levelName) {
        FadeCanvas.fader.FaderLoadString(levelName); 
    }

    public void LoadLevelIndex(int levelIndex) {
        FadeCanvas.fader.FaderLoadIndex(levelIndex);
    }

    public void RestartLevel() {
        FadeCanvas.fader.FaderLoadIndex(SceneManager.GetActiveScene().buildIndex);
    }

}
