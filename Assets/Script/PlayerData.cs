using Ingenius.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    [Header("PlayerDetails")]
    public int level;
   // public string teamName;
   // public string password;

    public PlayerData(UI_System player)
    {
        level = player.level;
     //   teamName = player.teamName;
     //   password = player.password;
    }

}
