using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI soldierCountText;
    [SerializeField] TextMeshProUGUI tankCountText;

    ScoreManager scoreManager;
    void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Start()
    {
        scoreText.text = scoreManager.playerScore.ToString();
        soldierCountText.text = "Soldiers - " + scoreManager.soldierCount.ToString();
        tankCountText.text = "Tanks - " + scoreManager.tankCount.ToString();
    }
}
