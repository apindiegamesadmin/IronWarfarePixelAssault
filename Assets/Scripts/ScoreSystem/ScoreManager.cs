using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int playerScore = 0;
    [SerializeField]TextMeshProUGUI scoreText;

    public void UpdateScore(int index)
    {
        playerScore += index;
        scoreText.text = playerScore.ToString();
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