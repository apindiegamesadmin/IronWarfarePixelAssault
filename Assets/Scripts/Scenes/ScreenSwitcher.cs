using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenSwitcher : MonoBehaviour
{
    public GameObject loadingScreen;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                audioManager.PlayMainMenuBGSound();
                break;
            case 1:
                audioManager.PlayMission1BGSound();
                break;
            case 2:
                audioManager.PlayMission2BGSound();
                break;
        }
    }

    IEnumerator FakeLoadingScreen(int sceneIndex)
    {
        loadingScreen.SetActive(true);//Enable Fake Loading Screen
        yield return new WaitForSeconds(2f);//Delay Before LoadScene
        SceneManager.LoadScene(sceneIndex);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void LoadSceneIndex(int index)
    {
        StartCoroutine(FakeLoadingScreen(index));
    }

    public void RestartScene()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        StartCoroutine(FakeLoadingScreen(SceneManager.GetActiveScene().buildIndex));
    }
}
