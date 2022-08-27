using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int playerScore = 0;
    TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GameObject.FindWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerScore"))
        {
            playerScore = 0;
        }
        else
        {
            scoreText.text = playerScore.ToString();
            playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        }
    }

    public void Score(string tag)
    {
        switch (tag)
        {
            case ("MachineGunSoldier"):
                playerScore += 5;
                break;

            case ("RPGSoldier"):
                playerScore += 6;
                break;

            case ("SmallTank"):
                playerScore += 10;
                break;

            case ("MediumTank"):
                playerScore += 15;
                break;

            case ("LargeTank"):
                playerScore += 20;
                break;

            case ("Boss"):
                playerScore += 100;
                break;
        }

        scoreText.text = playerScore.ToString();
        SaveScore();
    }

    public static void SaveScore()
    {
        PlayerPrefs.SetInt("PlayerScore", playerScore);
    }
}

/*
Machine Gun Soldier - 5
RPG Soldier         - 6
Small Tank          - 10
Medium Tank         - 15
Large Tank          - 20
Boss                - 100
*/