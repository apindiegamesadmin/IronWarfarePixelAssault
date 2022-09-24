using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockMissions : MonoBehaviour
{
    public int nextMission;
    Player player;

    private static UnlockMissions instance = null;
    public static UnlockMissions Instance
    {
        get { return instance; }
    }

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
        if (SceneManager.GetActiveScene().buildIndex > nextMission) // Check if the next mission is already unlocked or not
        {
            // Increase CurrentMission index, New Mission unlocked!!!
            nextMission++;
            player.missionIndex = nextMission;
            player.SavePlayerData();
        }
    }
}
