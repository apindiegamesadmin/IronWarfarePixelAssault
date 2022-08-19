using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenSwitcher : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsMenuPanel;
    public GameObject loadingScreen;
    public MissionLock missionLock;

    public void LoadScene(int index)
    {
        MissionCheck(index);
        missionLock.IsLock(index);
    }

    IEnumerator FakeLoadingScreen(int sceneIndex)
    {
        loadingScreen.SetActive(true);//Enable Fake Loading Screen
        yield return new WaitForSeconds(2f);//Delay Before LoadScene
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnClick_Settings()
    {
        mainMenuPanel.SetActive(false);
        settingsMenuPanel.SetActive(true);
    }

    public void OnClick_Back()
    {
        mainMenuPanel.SetActive(true);
        settingsMenuPanel.SetActive(false);
    }

    public void LoadSceneIndex(int index)
    {
        StartCoroutine(FakeLoadingScreen(index));
    }

    public void MissionCheck(int index)
    {
        if (index == 3)
        {
            missionLock = GameObject.Find("Mission 3 Details").GetComponent<MissionLock>();
        }
        else if (index == 4)
        {
            missionLock = GameObject.Find("Mission 4 Details").GetComponent<MissionLock>();
        }
        else if (index == 5)
        {
            missionLock = GameObject.Find("Mission 5 Details").GetComponent<MissionLock>();
        }
    }

}
