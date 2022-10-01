using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TutorialBossTrigger : MonoBehaviour
{
    PlayableDirector director;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject blocks;
    [SerializeField] GameObject dialogue;
    DialogueManager dialogueManager;
    AudioManager audioManager;
    int sceneID;

    private void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        audioManager = FindObjectOfType<AudioManager>();
        sceneID = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        director = GetComponentInParent<PlayableDirector>();
    }

    public void PlayCutScene()
    {
        if (director != null)
        {
            gameUI.SetActive(false);
            blocks.SetActive(false);
            Time.timeScale = 0;
            director.Play();
            CheckBossFightBGMusic();
        }
    }

    public void EndCutScene()
    {
        if (director != null)
        {
            gameUI.SetActive(true);
            blocks.SetActive(true);
            Time.timeScale = 1;
            director.Stop();
            if (dialogue != null)
            {
                dialogue.SetActive(true);
                dialogueManager.StartDialogue(dialogueManager.dialogue[10]);
            }
            Destroy(this.gameObject);
        }
    }

    private void CheckBossFightBGMusic()
    {
        switch (sceneID)
        {
            case 1:
                audioManager.PlayMission1BossFightSound();
                break;

            case 2:
                audioManager.PlayMission1BossFightSound();
                break;

            case 3:
                audioManager.PlayMission3BossFightSound();
                break;

            case 4:
                audioManager.PlayMission4BossFightSound();
                break;

            case 5:
                audioManager.PlayMission5BossFightSound();
                break;
        }
    }
}
