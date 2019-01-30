using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameCode : MonoBehaviour {

    public TMPro.TMP_Text displayScore;

    public IntVariable Score;
    public PlayerDataVariable PD;

    private GM_DataManager dataController;
    public GameEvent eventShowScore;

    private void Awake() {
        dataController = GetComponent<GM_DataManager>();
    }

   public void IncreaseScore() {
       Score.ApplyChange(1);
       PD.ChangeMoney(1);

       eventShowScore.Raise();
       dataController.SavePlayerProgress();
   }

   public void DecreaseScore() {
       Score.ApplyChange(-1);
       PD.ChangeMoney(-1);
       
       eventShowScore.Raise();
       dataController.SavePlayerProgress();
   }

   public void DisplayScore() {
       Debug.Log("display score " + PD.playerMoney);
       displayScore.text = PD.playerMoney.ToString();
   }

}
