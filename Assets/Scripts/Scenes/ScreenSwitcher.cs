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
}
