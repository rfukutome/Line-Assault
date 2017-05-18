using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class will be used to keep all of the persistent player parameters.
public class PlayerNvm : MonoBehaviour {

    private string player_name;
    private Color player_name_color;
    private int high_score;
    
    public string GetPlayerName()
    {
        return player_name;
    }

    public Color GetPlayerNameColor()
    {
        return player_name_color;
    }
}
