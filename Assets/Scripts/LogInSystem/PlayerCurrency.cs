using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayerCurrency : MonoBehaviour
{
    void Awake()
    {
        CurrencyManager.instance.GetVirtualCurrency();
    }


    #region BuyPowerUpsWithCoins
    public void BuyInvicibilityPowerUp() //Buy Invincibility Powerup with BattleCoin for 25
    {
        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = "BT",
            Amount = 25
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, SubtractCurrencySuccess, OnErrorNotif);
        AddPlayerInvincibility();
    }

    public void BuyFreezePowerUp() //Buy Freeze Powerup with BattleCoin for 50
    {
        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = "BT",
            Amount = 50
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, SubtractCurrencySuccess, OnErrorNotif);
        AddPlayerFreeze();
    }

    public void BuyMagnetPowerUp() //Buy Magnet Powerup with BattleCoin for 85
    {
        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = "BT",
            Amount = 85
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, SubtractCurrencySuccess, OnErrorNotif);
        AddPlayerMagnet();
    }

    #endregion
    #region AddPlayerPowerUps

    public void AddPlayerInvincibility() //Add Invincibility Powerup to the Player, and pass the value to another datatype
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = "IN",
            Amount = 1
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, AddCurrencySuccess, OnErrorNotif);
        CurrencyManager.instance.GetPlayerInvincibility();
    }

    public void AddPlayerFreeze() //Add Freeze Powerup to the Player, and pass the value to another datatype
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = "FR",
            Amount = 1
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, AddCurrencySuccess, OnErrorNotif);
        CurrencyManager.instance.GetPlayerFreeze();
    }

    public void AddPlayerMagnet() //Add Freeze Powerup to the Player, and pass the value to another datatype
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = "MG",
            Amount = 1
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, AddCurrencySuccess, OnErrorNotif);
        CurrencyManager.instance.GetPlayerMagnet();
    }

    #endregion

    #region CurrencyTransactionNotifs
    public void SubtractCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Currency Subtracted");
        CurrencyManager.instance.GetVirtualCurrency();
    }

    public void AddCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Currency Added");
        CurrencyManager.instance.GetVirtualCurrency();
    }


    public void OnErrorNotif(PlayFabError error)
    {
        Debug.LogError("Error: " + error.ErrorMessage);
    }
    #endregion
}