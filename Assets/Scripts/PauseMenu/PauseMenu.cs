using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    public bool isGamePaused = false;

    [SerializeField]
    GameObject settingPanel;

    [SerializeField]
    private GameObject gameUiPanel;

    UIManager uiManager;

    private void Start()
    {
        settingPanel.SetActive(false);
        gameUiPanel.SetActive(true);
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGamePaused)
        {
            Pause();
        }
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        gameUiPanel.SetActive(false);
    }

    public void Resume()
    {
        uiManager.PopDown(_pauseMenu);
        Time.timeScale = 1.0f;
        isGamePaused = false;
        gameUiPanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void Setting()
    {
        Time.timeScale = 1.0f;
        uiManager.PopUp(settingPanel);
    }

    public void Back()
    {
        uiManager.PopDown(settingPanel);
    }
}
