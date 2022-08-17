using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    public static bool isGamePaused = false;

    [SerializeField]
    private GameObject gameUiPanel;

    UIManager uiManager;

    private void Start()
    {
        gameUiPanel.SetActive(true);
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
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
        SceneManager.LoadScene("MainMenu");
    }
}
