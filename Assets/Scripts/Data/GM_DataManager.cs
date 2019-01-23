using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
//using UnityEngine.Analytics;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SocialPlatforms;

#pragma warning disable 0219 // Disables warnings

public class GM_DataManager : MonoBehaviour {

   
    public PlayerData        playerData;

    public bool              showBonusGame;
    //public string bonusGameChosen; //this bonus game is read from the main game to launch the correct bonus game.
    public int starsUnlockedThisRound;

    public List<int> cardsUnlockedThisRound;

    //Card Numbers the player owns
    public List<int> playerCardDatabase = new List<int>();
    //public List<PlayerDataCategories> playerDataCat = new List<PlayerDataCategories>();

    //public LoadTargetScene loadTargetScene;

    private string gameDataFilename   = "questionData_2_23_18.json";
    private string playerDataFilename = "testdata.json";

    //Need this global between scenes to know what category. E.g different background
    public string categoryTapped;
    public string parentCategoryTapped;


    private bool testingOnly; // create testing only to test in other scenes

	void Awake() {

}

    // Use this for initialization
    void Start() {
        
        //if this is executed in "scn_Persistent" then load main menu
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "scn_Persistent")
        {
            DontDestroyOnLoad(gameObject);
            LoadGameData();
            LoadPlayerProgress();
			//loadTargetScene.LoadSceneNum(2);
            //SceneManager.LoadScene("scn_MainMenu");
        }
        
        //gameCenter.SocialAuthenticate();
    }



    public PlayerData GetPlayerData() {
        return playerData;
    }

    private void LoadGameData() {

		string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFilename);

		if (File.Exists (filePath)) {
			string dataAsJson   = File.ReadAllText(filePath);
			//GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

			//allRoundData = loadedData.allRoundData;
		}
		else {
			//Debug.LogError("Cannot load Game Data");
		}

	}

    public void SavePlayerProgress() {

        string saveStatePath = Path.Combine(Application.persistentDataPath, playerDataFilename);
        File.WriteAllText(saveStatePath, JsonUtility.ToJson(playerData, true));


        //write to gamecenter
        // if (Social.localUser.authenticated) {
        //     gameCenter.ReportScore(playerData.highScore);
        //     gameCenter.ReportMostQuestionsAnswered(playerData.questionsAnsweredTotal);
        //     gameCenter.ReportThreeStarGames(playerData.threeStarGames);
        // }
        // else {
        //     gameCenter.SocialAuthenticate();
        // }



	}

	public void LoadPlayerProgress() {

            string filePath = Path.Combine(Application.persistentDataPath, playerDataFilename);

            if (File.Exists (filePath)) {
                string dataAsJson     = File.ReadAllText(filePath);
                PlayerData loadedData = JsonUtility.FromJson<PlayerData>(dataAsJson);

                playerData = loadedData;
                //playerDataCategories = loadedData.playerDataCategories;

            }
            else {
                //Debug.Log("Cannot load Game Data");
                PlayerData data    = new PlayerData();
                string saveStatePath = Path.Combine(Application.persistentDataPath, playerDataFilename);
                File.WriteAllText(saveStatePath, JsonUtility.ToJson(playerData, true));
            }
            
	}


    

	public void DeletePlayerProgress() {
		

        playerData.playerLevel = 0;

        playerData.playerMoney = 0;

        playerData.firstGame = true;
        
        SavePlayerProgress();
		
	}

   

}