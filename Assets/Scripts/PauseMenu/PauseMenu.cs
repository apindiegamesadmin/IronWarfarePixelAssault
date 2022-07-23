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

    //@Xavier - Refactored to work while pausing
    [SerializeField]
    private GameObject player;

    private void Start()
    {
        gameUiPanel.SetActive(true);
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.P))
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
        player.GetComponent<PlayerInput>().enabled = false;
        gameUiPanel.SetActive(false);
    }

    public void Resume()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isGamePaused = false;
        player.GetComponent<PlayerInput>().enabled = true;
        gameUiPanel.SetActive(true);
    }

    public void Restart()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameUiPanel.SetActive(true);
    }

    public void MainMenu()
    {
        _pauseMenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
