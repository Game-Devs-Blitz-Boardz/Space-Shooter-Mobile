using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonIcons : MonoBehaviour
{
    [SerializeField] Button[] lvlButtons;
    [SerializeField] Sprite unlockedIcon;
    [SerializeField] Sprite lockedIcon;
    [SerializeField] int firstLevelBuildIndex;

    void Awake() {
        int unlockedLvl = PlayerPrefs.GetInt(EndGameManager.endManager.levlUnlock, firstLevelBuildIndex);
        for (int i = 0; i<lvlButtons.Length; i++) {
            if (i + firstLevelBuildIndex <= unlockedLvl) {
                lvlButtons[i].interactable = true;
                lvlButtons[i].image.sprite = unlockedIcon;
                TextMeshProUGUI textButton = lvlButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                textButton.text = (i+1).ToString();
                textButton.enabled = true;
            } else {
                lvlButtons[i].interactable = false;
                lvlButtons[i].image.sprite = lockedIcon;
                lvlButtons[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
    }

}
