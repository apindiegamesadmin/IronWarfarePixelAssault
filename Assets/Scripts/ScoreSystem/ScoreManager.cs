using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int health;
    public int playerScore = 0;
    public Damagable damagable;
    public string PLAYERSCORE;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        damagable = GetComponent<Damagable>();
    }

    void Start()
    {
        scoreText.text = playerScore.ToString();
        health = damagable.Health;
        playerScore = PlayerPrefs.GetInt(PLAYERSCORE, 0);
    }

    void Update()
    {
        // if (health <= 0)
        // {
        //     Score();
        //     Debug.Log("Score plus one");
        // }
    }

    public void Score()
    {
        playerScore += 1;
        scoreText.text = playerScore.ToString();
        PlayerPrefs.SetInt(PLAYERSCORE, playerScore);
    }
}
