using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockMissions : MonoBehaviour
{
    public int nextMission;
    Player player;
    public static UnlockMissions instance { get; private set; }

    private void Start()
    {
        nextMission = player.missionIndex;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        player = FindObjectOfType<Player>();
    }

    public void UnlockMission() // Call this at the end of each level
    {
        if (SceneManager.GetActiveScene().buildIndex > nextMission && SceneManager.GetActiveScene().buildIndex < 5) // Check if the next mission is already unlocked or not
        {
            // Increase CurrentMission index, New Mission unlocked!!!
            nextMission++;
            player.missionIndex = nextMission;
            player.SavePlayerData();
        }
    }
}
