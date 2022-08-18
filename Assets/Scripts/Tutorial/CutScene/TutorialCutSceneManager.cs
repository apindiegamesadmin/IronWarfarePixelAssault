using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TutorialCutSceneManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialManager;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject blocks;

    PlayableDirector director;

    private void Start()
    {
        director = GetComponent<PlayableDirector>();

        Time.timeScale = 0;
        gameUI.SetActive(false);
        tutorialManager.SetActive(false);
        blocks.SetActive(false);
        director.Play();
    }
    public void EndTutorialCutScene()
    {
        Time.timeScale = 1;
        gameUI.SetActive(true);
        tutorialManager.SetActive(true);
        blocks.SetActive(true);
        director.Stop();
    }
}
