using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour {

    public static FadeCanvas fader;

    [SerializeField] CanvasGroup cG;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Image loadingBar;
    [SerializeField] float changeValue;
    [SerializeField] float waitTime;
    [SerializeField] bool fadeStarted = false;

    void Awake() {
        if (fader == null) {
            fader = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FaderLoadString(string levelName) {
        StartCoroutine(FadeOutString(levelName));
    }

    public void FaderLoadIndex(int levelIndex) {
        StartCoroutine(FadeOutIndex(levelIndex));
    }

    IEnumerator FadeIn() {
        loadingScreen.SetActive(false);
        fadeStarted = false;
        while (cG.alpha > 0) {
            cG.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator FadeOutString(string levelName) {
        if (fadeStarted) yield break;
        fadeStarted = true;
        while (cG.alpha < 1) {
            cG.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        // SceneManager.LoadScene(levelName);
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);
        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;
        while(ao.isDone == false) {
            loadingBar.fillAmount = ao.progress / 0.9f;
            if (ao.progress == 0.9f) {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeOutIndex(int levelIndex) {
        if (fadeStarted) yield break;
        fadeStarted = true;
        while (cG.alpha < 1) {
            cG.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelIndex);
        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;
        while(ao.isDone == false) {
            loadingBar.fillAmount = ao.progress / 0.9f;
            if (ao.progress == 0.9f) {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
        StartCoroutine(FadeIn());
    }
}
