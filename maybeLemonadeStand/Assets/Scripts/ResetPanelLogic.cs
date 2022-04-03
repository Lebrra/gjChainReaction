using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPanelLogic : MonoBehaviour
{
    public void ResetDay()
    {
        // reload the scene
        ScreenFader.instance.ScreenFade(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }

    public void ResetSaveData()
    {
        // delete saves and go to main menu
        JSONEditor.DeleteData("gameData"); 
        ScreenFader.instance.ScreenFade(() => SceneManager.LoadScene(0));
    }
}
