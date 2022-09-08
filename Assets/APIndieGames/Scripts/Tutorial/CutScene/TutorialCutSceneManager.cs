using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TutorialCutSceneManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialManager;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject blocks;
    [SerializeField] DialogueManager dialogueManager;

    GameObject player;
    PlayableDirector director;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        director = GetComponent<PlayableDirector>();

        player.GetComponentInChildren<TankMachineGun>().canShoot = false;
        Time.timeScale = 0;
        gameUI.SetActive(false);
        if(tutorialManager != null)
        {
            tutorialManager.SetActive(false);
        }
        if(blocks != null)
        {
            blocks.SetActive(false);
        }
        director.Play();
    }

    public void EndMission2CutScene()
    {
        player.GetComponentInChildren<TankMachineGun>().canShoot = true;
        Time.timeScale = 1;
        gameUI.SetActive(true);
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue(dialogueManager.dialogue[0]);
        }
        if (tutorialManager != null)
        {
            tutorialManager.SetActive(true);
        }
        if (blocks != null)
        {
            blocks.SetActive(true);
        }
        director.Stop();
    }

    public void EndTutorialCutScene()
    {
        Time.timeScale = 1;
        gameUI.SetActive(true);
        if(dialogueManager != null)
        {
            dialogueManager.StartDialogue(dialogueManager.dialogue[0]);
        }
        if (tutorialManager != null)
        {
            tutorialManager.SetActive(true);
        }
        if (blocks != null)
        {
            blocks.SetActive(true);
        }
        director.Stop();
    }
}
