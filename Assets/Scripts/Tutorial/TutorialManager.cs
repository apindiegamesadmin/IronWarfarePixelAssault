using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] TankController playerTank;
    [SerializeField] GameObject tutorialStep2;
    [SerializeField] GameObject dialogueUI;

    public int tutorialIndex;
    public bool completeStep;
    DialogueManager dialogueManager;
    void Start()
    {
        dialogueManager = dialogueUI.GetComponent<DialogueManager>();
        dialogueUI.SetActive(true);
    }

    
    void Update()
    {
        if(tutorialIndex == 0 && completeStep)
        {
            dialogueUI.SetActive(true);
            dialogueManager.StartDialogue(dialogueManager.dialogue[1]);
            tutorialIndex++;
            completeStep = false;
        }
        else if (tutorialIndex == 1 && completeStep)
        {
            dialogueUI.SetActive(true);
            dialogueManager.StartDialogue(dialogueManager.dialogue[3]);
            tutorialIndex++;
            completeStep = false;
        }
    }

    public void TutorialDialogueTrigger(int index)
    {
        dialogueUI.SetActive(true);
        dialogueManager.StartDialogue(dialogueManager.dialogue[index]);
    }

    public void TutorialStepTwoComplete()
    {
        completeStep = true;
    }
}
