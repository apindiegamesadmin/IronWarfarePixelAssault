using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] int score;

    ScoreManager scoreManager;
    void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void AddScore()
    {
        scoreManager.UpdateScore(score);
    }
}
