using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour {

    public PlayerDataVariable PlayerData;

    public void Start()
    {
        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId)){
            PlayFabSettings.TitleId = "276f"; // Please change this value to your own titleId from PlayFab Game Manager
        }
        var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true};
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        SetUserData();
        
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }


    void SetUserData() {

        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest() {
            Data = new Dictionary<string, string>() {
                {"Score", PlayerData.playerMoney.ToString()}
            }
        }, 
        result => Debug.Log("Successfully updated user data"),
        error => {
            Debug.Log("Got error setting user data Ancestor to Arthur");
            Debug.Log(error.GenerateErrorReport());
        });
    }



    // void GetUserData() {
    //     PlayFabClientAPI.GetUserData(new GetUserDataRequest() {
    //         PlayFabId = PlayFabId,
    //         Keys = null
    //     }, result => {
    //         Debug.Log("Got user data:");
    //         if (result.Data == null || !result.Data.ContainsKey("Ancestor")) Debug.Log("No Ancestor");
    //         else Debug.Log("Ancestor: "+result.Data["Ancestor"].Value);
    //     }, (error) => {
    //         Debug.Log("Got error retrieving user data:");
    //         Debug.Log(error.GenerateErrorReport());
    //     });
    // }
}