using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//This class will be used to keep all of the persistent player parameters.
public class PlayerNvm : MonoBehaviour {

    public Text player_banner;
    private string player_name = "Foxist";
    private Color player_name_color = new Color(255f, 255f, 255f, 255f);
    private int high_score;

    private void Start()
    {
        player_banner.text = player_name;
        player_banner.color = player_name_color;
    }
    public string GetPlayerName()
    {
        return player_name;
    }

    public Color GetPlayerNameColor()
    {
        return player_name_color;
    }
}
