using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class PlayerStatsManager : MonoBehaviour
{
    public int _DistanceTraveleved;
    public int _ObstaclesDodged;
    public int _coinsCollected;
    //Function to store the stats player has made in the runner. Call it Whenever the player dies to update player statistics

    private void Start()
    {

    }
    public void UpdatePlayerStatistics()
    {
        //Set up the request to update player's statistics
        UpdatePlayerStatisticsRequest request = new UpdatePlayerStatisticsRequest()
        {
            Statistics = new List<StatisticUpdate>()
            {
                new StatisticUpdate()
                {
                    StatisticName = "Distance Traveled",
                    Value = _DistanceTraveleved
                },
                new StatisticUpdate()
                {
                    StatisticName = "Obstacles Dodged",
                    Value = _ObstaclesDodged
                },

                new StatisticUpdate()
                {
                    StatisticName = "Coins Collected",
                    Value = _coinsCollected
                }
            }
        };
        //Call PlayFab API to update player's statistics
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnPlayerUpdateStatisticsSuccess, OnPlayerUpdateStatisticsFailed);
    }

    public void OnPlayerUpdateStatisticsSuccess(UpdatePlayerStatisticsResult result) //Call on Successful API Call
    {
        Debug.Log("Player Stats Updated Successfully");
    }

    public void OnPlayerUpdateStatisticsFailed(PlayFabError error) //Call on Failed API Call and show error
    {
        Debug.Log("Failed to Update Player Statistics: " + error.ErrorMessage);
    }

    public void RetrievePlayerStatsOnNewRun()
    {
        GetPlayerStatisticsRequest request = new GetPlayerStatisticsRequest();
        PlayFabClientAPI.GetPlayerStatistics(request, OnPlayerGetStatsSuccess, OnPlayerGetStatsFailed);
    }

    public void OnPlayerGetStatsSuccess(GetPlayerStatisticsResult result)
    {
        foreach (StatisticValue statValue in result.Statistics)
        {
            switch (statValue.StatisticName)
            {
                case "Distance Traveled":
                    _DistanceTraveleved += statValue.Value;
                    break;
                case "Obstacles Dodged":
                    _ObstaclesDodged += statValue.Value;
                    break;
                case "Coins Collected":
                    _coinsCollected += statValue.Value;
                    break;
            }
        }
    }

    public void OnPlayerGetStatsFailed(PlayFabError error)
    {
        Debug.LogError("Failed to retrieve player statistics: " + error.ErrorMessage);
    }

    public void GetPlayerDistance(float Distance)
    {
        _DistanceTraveleved++;
    }
    public void GetPlayerCoinsCollected(float Coins)
    {

    }
    public void GetPlayerObstaclesDodged(float Dodge)
    {

    }
}
