using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCode : MonoBehaviour
{

    public TMPro.TMP_Text displayScore;

    public IntVariable Score;

    private void Awake() {
        DisplayScore();
    }

   public void IncreaseScore() {
       Score.ApplyChange(1);

       DisplayScore();
   }

   public void DecreaseScore() {
       Score.ApplyChange(-1);
       
       DisplayScore();
   }

   void DisplayScore() {
       Debug.Log(Score.Value);
       displayScore.text = Score.Value.ToString();
   }



}
