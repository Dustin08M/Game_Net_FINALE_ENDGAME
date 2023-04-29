using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour //Storing the player stats locally then send it to playfab
{
    public static PlayerTracker instance;
    private float Distance_Traveled = 0f;
    PlayerStatsManager GetStatToPlayFab;

    private void Awake()
    {
        instance = this;
    }


    [SerializeField] private int CoinsGrabbed;
    public void CountCoinsCollected()
    {
        CoinsGrabbed++;
        Debug.Log($"Coins Collected: {CoinsGrabbed}");
    }

    void Update()
    {
        //GetStatToPlayFab.GetPlayerDistance(Distance_Traveled);
    }
}
