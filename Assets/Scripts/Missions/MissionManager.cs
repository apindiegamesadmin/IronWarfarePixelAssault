using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public int currentMission;
    [SerializeField] GameObject mission2Locked;
    [SerializeField] GameObject mission2UnLocked;

    void Start()
    {
        missionCheck();
        currentMission = FindObjectOfType<UnlockMissions>().nextMission;
    }

    void missionCheck()
    {
        switch (currentMission)
        {
            case 0: // Lock all Missions except Mission 1

                // Mission 2
                mission2Locked.SetActive(true); // Show Locked UI
                mission2UnLocked.SetActive(false); // Hide Unlocked UI

                break;

            case 1: //If the player completed Mission 1, unlock Mission 2
                mission2Locked.SetActive(false); // Hide Locked UI
                mission2UnLocked.SetActive(true); // Show Unlocked UI
                break;

            case 2://If the player completed Mission 2, unlock Mission 3
                break;

            case 3://If the player completed Mission 3, unlock Mission 4
                break;

            case 4://If the player completed Mission 4, unlock Mission 5
                break;
        }
    }
}
