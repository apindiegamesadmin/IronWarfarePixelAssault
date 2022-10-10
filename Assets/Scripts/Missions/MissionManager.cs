using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public int currentMission;
    [SerializeField] GameObject[] LockedUIs;
    [SerializeField] GameObject[] UnLockedUIs;

    void Start()
    {
        currentMission = UnlockMissions.instance.nextMission;
        missionCheck();
    }

    void missionCheck()
    {
        foreach(GameObject ui in LockedUIs)
        {
            ui.SetActive(true);
        }
        foreach (GameObject ui in UnLockedUIs)
        {
            ui.SetActive(true);
        }
        for (int i = 0; i < currentMission + 1; i++)
        {
            LockedUIs[i].SetActive(false);
            UnLockedUIs[i].SetActive(true);
        }
    }
}
