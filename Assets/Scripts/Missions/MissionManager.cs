using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public int currentMission;
    [SerializeField] GameObject mission2Locked;
    [SerializeField] GameObject mission2UnLocked;
    [SerializeField] GameObject mission3Locked;
    [SerializeField] GameObject mission3UnLocked;
    [SerializeField] GameObject mission4Locked;
    [SerializeField] GameObject mission4UnLocked;
    [SerializeField] GameObject mission5Locked;
    [SerializeField] GameObject mission5UnLocked;

    void Start()
    {
        currentMission = FindObjectOfType<UnlockMissions>().nextMission;
        missionCheck();
    }

    void missionCheck()
    {
        switch (currentMission)
        {
            case 0: // Lock all Missions except Mission 1

                // Mission 2
                mission2Locked.SetActive(true); // Show Locked UI
                mission2UnLocked.SetActive(false); // Hide Unlocked UI

                // Mission 3
                mission3Locked.SetActive(true); // Show Locked UI
                mission3UnLocked.SetActive(false); // Hide Unlocked UI

                // Mission 4
                mission4Locked.SetActive(true); // Show Locked UI
                mission5UnLocked.SetActive(false); // Hide Unlocked UI

                // Mission 5
                mission5Locked.SetActive(true); // Show Locked UI
                mission5UnLocked.SetActive(false); // Hide Unlocked UI

                break;

            case 1: //If the player completed Mission 1, unlock Mission 2
                mission2Locked.SetActive(false); // Hide Locked UI
                mission2UnLocked.SetActive(true); // Show Unlocked UI
                break;

            case 2://If the player completed Mission 2, unlock Mission 3
                mission3Locked.SetActive(false); // Hide Locked UI
                mission3UnLocked.SetActive(true); // Show Unlocked UI
                break;

            case 3://If the player completed Mission 3, unlock Mission 4
                mission4Locked.SetActive(false); // Hide Locked UI
                mission4UnLocked.SetActive(true); // Show Unlocked UI
                break;

            case 4://If the player completed Mission 4, unlock Mission 5
                mission5Locked.SetActive(false); // Hide Locked UI
                mission5UnLocked.SetActive(true); // Show Unlocked UI
                break;
        }
    }
}
