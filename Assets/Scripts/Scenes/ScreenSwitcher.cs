using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenSwitcher : MonoBehaviour
{
    public GameObject loadingScreen;

    private void Awake()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                AudioManager.instance.PlayMainMenuBGSound();
                break;
            case 1:
                AudioManager.instance.PlayMission1BGSound();
                break;
            case 2:
                AudioManager.instance.PlayMission2BGSound();
                break;
            case 3:
                AudioManager.instance.PlayMission3BGSound();
                break;
            case 4:
                AudioManager.instance.PlayMission4BGSound();
                break;
            case 5:
                AudioManager.instance.PlayMission5BGSound();
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
