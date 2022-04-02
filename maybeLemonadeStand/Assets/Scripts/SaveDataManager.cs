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

            gameData = JSONEditor.JSONToData<SaveData>("gameData");
        }
    }

    //public PlayerSaveData GetSaveData()
    //{
    //    return null;
    //}
    //
    //public void SaveLevelData(int sceneIndex, PlayerSaveData data)
    //{
    //    JSONEditor.SaveDataToJSON(gameData, "gameData");
    //}
}