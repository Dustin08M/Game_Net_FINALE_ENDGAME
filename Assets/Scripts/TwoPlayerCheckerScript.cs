using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using PlayFab;
using PlayFab.ClientModels;

public class TwoPlayerCheckerScript : MonoBehaviourPunCallbacks
{
    private bool isRestarting = false;
    [SerializeField] private GameObject Player;

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(Player.name, Vector3.zero, Quaternion.identity);
            // Create a PlayFab session ticket for the host
            PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest
            {
                CreateAccount = true,
                CustomId = PhotonNetwork.LocalPlayer.UserId
            }, OnLoginSuccess, OnLoginFailure);
        }
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Logged in to PlayFab with ID: " + result.PlayFabId);
        // Once the host has logged in to PlayFab, they can start the game
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.PlayerList.Length == 2 && !isRestarting)
        {
            isRestarting = true;
            PhotonNetwork.DestroyAll();
            PhotonNetwork.LoadLevel("GameScene");
        }
    }

    void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("Login to PlayFab failed: " + error.ErrorMessage);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        // Once the host has logged in to PlayFab, they can start the game
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.PlayerList.Length == 2 && !isRestarting)
        {
            isRestarting = true;
            PhotonNetwork.DestroyAll();
            PhotonNetwork.LoadLevel("GameScene");
        }
    }
}
