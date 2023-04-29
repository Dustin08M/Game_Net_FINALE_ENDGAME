using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGreetMenu : MonoBehaviour
{
    public Text greetingText;
    private PlayerStatsManager _statManager;
    void Start()
    {
        greetingText.text = "Hello, " + AuthenticationManager2.PlayerName.ToString();
        _statManager = FindObjectOfType<PlayerStatsManager>();
        _statManager.RetrievePlayerStatsOnNewRun();

        Debug.Log("Distance Traveled: " + _statManager._DistanceTraveleved);
        Debug.Log("Obstacles Dodged: " + _statManager._ObstaclesDodged);
        Debug.Log("Coins Collected: " + _statManager._coinsCollected);
    }
}
