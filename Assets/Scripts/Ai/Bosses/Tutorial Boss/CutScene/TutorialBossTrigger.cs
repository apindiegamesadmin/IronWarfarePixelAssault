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

    private void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
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
            CheckBossFightBGMusic();
            Time.timeScale = 0;
            director.Play();
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
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                AudioManager.instance.PlayMission1BossFightSound();
                break;

            case 2:
                AudioManager.instance.PlayMission2BossFightSound();
                break;

            case 3:
                AudioManager.instance.PlayMission3BossFightSound();
                break;

            case 4:
                AudioManager.instance.PlayMission4BossFightSound();
                break;

            case 5:
                AudioManager.instance.PlayMission5BossFightSound();
                break;
        }
    }
}
