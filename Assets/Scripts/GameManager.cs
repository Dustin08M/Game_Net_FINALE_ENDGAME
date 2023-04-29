using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int coins;
    public static GameManager inst;
    public Text coinsText;

    public Text pointsText;

    private void Awake()
    {
        inst = this;
    }

    public void IncrementCoins()
    {
        coins++;
        coinsText.text = "Coins: " + coins;
    }

    public void SetUp(int score)//for gameover panel
    {
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
    }
}
