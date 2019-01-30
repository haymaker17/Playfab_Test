using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SocialPlatforms;

#pragma warning disable 0219 // Disables warnings

public class GM_DataManager : MonoBehaviour {

    public PlayerDataVariable  playerData;
    public GameEvent eventShowScore;

    private string playerDataFilename = "testdata.json";

    // Use this for initialization
    void Start() {
        
        //if this is executed in "scn_Persistent" then load main menu
        Scene scene = SceneManager.GetActiveScene();
        LoadPlayerProgress();
        
    }


    public PlayerDataVariable GetPlayerData() {
        return playerData;
    }

 

    public void SavePlayerProgress() {

        string saveStatePath = Path.Combine(Application.persistentDataPath, playerDataFilename);
        File.WriteAllText(saveStatePath, JsonUtility.ToJson(playerData, true));

	}

	public void LoadPlayerProgress() {

            string filePath = Path.Combine(Application.persistentDataPath, playerDataFilename);

            if (File.Exists (filePath)) {
                string dataAsJson = File.ReadAllText(filePath);

                JsonUtility.FromJsonOverwrite(dataAsJson,playerData);

            }
            else {
                //Debug.Log("Cannot load Game Data");
                PlayerDataVariable data    = new PlayerDataVariable();
                string saveStatePath = Path.Combine(Application.persistentDataPath, playerDataFilename);
                File.WriteAllText(saveStatePath, JsonUtility.ToJson(playerData, true));
            }

            eventShowScore.Raise();
            
	}


	public void DeletePlayerProgress() {
		
        playerData.playerLevel = 0;
        playerData.playerMoney = 0;
        playerData.firstGame = true;
        
        SavePlayerProgress();
		
	}

   

}