using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public enum type { None,Soldier, Tank };

    public int playerScore;
    public int soldierCount;
    public int tankCount;

    [SerializeField] TextMeshProUGUI scoreText;

    public void UpdateScore(int index,int typeIndex)
    {
        playerScore += index;
        scoreText.text = playerScore.ToString();

        switch ((type)typeIndex)
        {
            case (type.None):
                break;
            case (type.Soldier):
                soldierCount++;
                break;
            case (type.Tank):
                tankCount++;
                break;
        }
    }

    /*public void ShowFinalScore()
    {
        finalScoreText.text = playerScore.ToString();
    }*/
}

/*
Machine Gun Soldier - 5
RPG Soldier         - 6
Small Tank          - 10
Medium Tank         - 15
Large Tank          - 20
Boss                - 100
*/