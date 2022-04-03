using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScreen : MonoBehaviour
{
    public string truckName = "";

    public GameObject titlePanel;
    public GameObject helpPanel;

    public void ShowHowTo()
    {
        if (truckName != "") PlayerPrefs.SetString("truckName", truckName);
        ScreenFader.instance.ScreenFade(HowTo);
    }

    public void PlayGame()
    {
        ScreenFader.instance.ScreenFade(SceneChange);
    }

    void HowTo()
    {
        titlePanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    void SceneChange()
    {
        SceneManager.LoadScene(1);
    }

    public void UpdateTruckName(string text)
    {
        if (text != "") truckName = text;
    }
}
