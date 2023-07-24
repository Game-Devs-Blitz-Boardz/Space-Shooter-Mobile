using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeCanvas : MonoBehaviour {

    public static FadeCanvas fader;

    [SerializeField] CanvasGroup cG;
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
        SceneManager.LoadScene(levelName);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeOutIndex(int levelIndex) {
        if (fadeStarted) yield break;
        fadeStarted = true;
        while (cG.alpha < 1) {
            cG.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(FadeIn());
    }
}
