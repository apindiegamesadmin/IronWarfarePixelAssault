using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenSwitcher : MonoBehaviour
{
    public GameObject loadingScreen;

    IEnumerator FakeLoadingScreen(int sceneIndex)
    {
        loadingScreen.SetActive(true);//Enable Fake Loading Screen
        yield return new WaitForSeconds(2f);//Delay Before LoadScene
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadSceneIndex(int index)
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        StartCoroutine(FakeLoadingScreen(index));
    }
}
