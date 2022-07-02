using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSwitcher : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsMenuPanel;

    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
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

}
