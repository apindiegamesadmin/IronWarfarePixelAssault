using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] TankController playerTank;
    [SerializeField] DefaultEnemyAI step2EnemyAIStatic;
    [SerializeField] DefaultEnemyAI step2EnemyAIPatrol;
    [SerializeField] AIDetector step3SpeedPowerUps;
    [SerializeField] AIDetector step3BulletPowerUps;
    [SerializeField] AIDetector step4HealthPack;
    [SerializeField] GameObject dialogueUI;

    public int tutorialIndex;
    public bool completeStep;

    int count;
    bool W, A, S, D;
    bool doOnce;

    DialogueManager dialogueManager;
    void Start()
    {
        dialogueManager = dialogueUI.GetComponent<DialogueManager>();
        dialogueUI.SetActive(true);//Show Dialogue

        playerTank.canShoot = false;//Disable Shoot Function Of Player
                                    //Here we need to Disable player machine guns

        step2EnemyAIStatic.canShoot = false;//Disable Shoot Function Of Enemy
        step2EnemyAIPatrol.canShoot = false;

        playerTank.transform.GetComponent<SpeedUpControl>().tutorial = true;// Turn On tutorial mode on power ups
        playerTank.transform.GetComponent<BulletController>().tutorial = true;
        playerTank.transform.GetComponent<HealthPackControl>().tutorial = true;
    }

    
    void Update()
    {
        if(tutorialIndex == 0)// Step 1
        {
            if (count < 4 && FindObjectOfType<TutorialManager>().tutorialIndex == 0)//Check for tutorial Movement //Not an efficient method,will fix later
            {
                if (Input.GetKeyDown(KeyCode.W))//Check if the player moved in all directions
                {
                    if (W)//Check if the player already moved in this direction
                        return;
                    count++;//increase count to check the completion of the step
                    W = true;//Player moved in this direction
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    if (A)
                        return;
                    count++;
                    A = true;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    if (S)
                        return;
                    count++;
                    S = true;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    if (D)
                        return;
                    count++;
                    D = true;
                }
                if (count >= 3)//If the player move at least 3 direction, this step will complete
                {
                    FindObjectOfType<TutorialManager>().completeStep = true;
                }
            }

            if (completeStep)//Show Complete Text
            {
                dialogueUI.SetActive(true);
                dialogueManager.StartDialogue(dialogueManager.dialogue[1]);
                tutorialIndex++;//Increase tutorial Step
                completeStep = false;//Reset completion
            }
        }
        else if (tutorialIndex == 1)// Step 2 A(Main Cannon)
        {
            if (step2EnemyAIStatic.detector.TargetVisible)
            {
                if (!doOnce)//We don't want to trigger multiple times because that can cause the dialogue error.
                {
                    dialogueUI.SetActive(true);//Show appropiate dialogue
                    dialogueManager.StartDialogue(dialogueManager.dialogue[2]);
                    playerTank.canShoot = true;//Player can start shooting in this step
                    doOnce = true;
                }
            }
            if (completeStep)//Show Complete Text
            {
                dialogueUI.SetActive(true);
                dialogueManager.StartDialogue(dialogueManager.dialogue[1]);
                tutorialIndex++;
                completeStep = false;//Reset completion
                doOnce = false;//Reset doOnce
            }
        }
        else if(tutorialIndex == 2)// Step 2 B(Machine Gun)
        {
            if (step2EnemyAIPatrol.detector.TargetVisible)
            {
                if (!doOnce)
                {
                    dialogueUI.SetActive(true);
                    dialogueManager.StartDialogue(dialogueManager.dialogue[3]);
                    //Here we need to enable player machine guns
                    doOnce = true;
                }
            }
            if (completeStep)//Show Complete Text
            {
                dialogueUI.SetActive(true);
                dialogueManager.StartDialogue(dialogueManager.dialogue[1]);
                tutorialIndex++;
                completeStep = false;
                doOnce = false;
            }
        }
        else if(tutorialIndex == 3)// Step 3 A Speed Power Up
        {
            if (step3SpeedPowerUps.TargetVisible)
            {
                if (!doOnce)
                {
                    dialogueUI.SetActive(true);
                    dialogueManager.StartDialogue(dialogueManager.dialogue[4]);
                    doOnce = true;
                }
            }
            if (completeStep)//Show Complete Text
            {
                dialogueUI.SetActive(true);
                dialogueManager.StartDialogue(dialogueManager.dialogue[1]);
                tutorialIndex++;
                completeStep = false;
                doOnce = false;
            }
        }
        else if(tutorialIndex == 4)// Step 3 B Bullet Power Up
        {
            if (step3BulletPowerUps.TargetVisible)
            {
                if (!doOnce)
                {
                    dialogueUI.SetActive(true);
                    dialogueManager.StartDialogue(dialogueManager.dialogue[5]);
                    doOnce = true;
                }
            }
            if (completeStep)//Show Complete Text
            {
                dialogueUI.SetActive(true);
                dialogueManager.StartDialogue(dialogueManager.dialogue[1]);
                tutorialIndex++;
                completeStep = false;
                doOnce = false;
            }
        }
        else if(tutorialIndex == 5)
        {
            if (step4HealthPack.TargetVisible)
            {
                if (!doOnce)
                {
                    dialogueUI.SetActive(true);
                    dialogueManager.StartDialogue(dialogueManager.dialogue[6]);
                    doOnce = true;
                }
            }
            if (completeStep)//Show Complete Text
            {
                dialogueUI.SetActive(true);
                dialogueManager.StartDialogue(dialogueManager.dialogue[1]);
                tutorialIndex++;
                completeStep = false;
                doOnce = false;
            }
        }
    }

    public void TutorialStepComplete(int index)
    {
        if(tutorialIndex == index)
        {
            completeStep = true;
        }
    }
}
