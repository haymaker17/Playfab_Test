using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerDataVariable : ScriptableObject
{
    #if UNITY_EDITOR
        [Multiline]
        public string Description = "";
    #endif
  
    public long playerMoney;
    public int  playerLevel;
    public bool firstGame;

    //----- MONEY ------
    public void SetMoney(int value)
    {
        playerMoney = value;
    }

    public void SetMoney(IntVariable value)
    {
        playerMoney = value.Value;
    }
    public void ChangeMoney(int amount)
    {
        playerMoney += amount;
    }

    public void ChangeMoney(IntVariable amount)
    {
        playerMoney += amount.Value;
    }

    //----- LEVEL ------
    public void SetLevel(int value)
    {
        playerLevel = value;
    }

    public void SetLevel(IntVariable value)
    {
        playerLevel = value.Value;
    }

    public void ChangeLevel(int amount)
    {
        playerLevel += amount;
    }

    public void ChangeLevel(IntVariable amount)
    {
        playerLevel += amount.Value;
    }

    //----- FIRST GAME ------
    public void SetFirstGame(bool value)
    {
        firstGame = value;
    }

 
}
