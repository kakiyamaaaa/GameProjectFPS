using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistentManager : MonoBehaviour
{
    private GameData gameData;


    public static DataPersistentManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }

    }

    public void SaveGame()
    {
        // TODO - pass the data to other scripts so they can update it

        // TODO - sae that data to a file using the data handler
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
