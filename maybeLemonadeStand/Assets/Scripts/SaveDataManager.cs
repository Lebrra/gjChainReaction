using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager instance;

    public SaveData gameData;

    //[Header("Cursors")]
    //public Texture2D cursorDefault;
    //public Texture2D cursorClicked;

    private void Awake()
    {
        if (instance) Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            gameData = JSONEditor.JSONToSaveData();
        }
    }

    public LevelStats GetLevelData(int sceneIndex)
    {
        if (gameData.allLevelData.Count > sceneIndex) return gameData.allLevelData[sceneIndex];
        else
        {
            // level data not saved yet
            while (gameData.allLevelData.Count <= sceneIndex)
            {
                gameData.allLevelData.Add(new LevelStats());
            }
            return gameData.allLevelData[sceneIndex];
        }
    }

    public void SaveLevelData(int sceneIndex, LevelStats data)
    {
        JSONEditor.SaveDataToJSON(gameData);
    }
}