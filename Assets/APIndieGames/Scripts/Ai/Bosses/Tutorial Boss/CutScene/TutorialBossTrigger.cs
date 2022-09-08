using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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
            if(dialogue != null)
            {
                dialogue.SetActive(true);
                dialogueManager.StartDialogue(dialogueManager.dialogue[10]);
            }
            Destroy(this.gameObject);
        }
    }
}
