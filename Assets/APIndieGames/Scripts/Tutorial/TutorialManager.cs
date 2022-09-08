using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    TankController playerTank;
    [SerializeField] DefaultEnemyAI enemyAIStatic;
    [SerializeField] DefaultEnemyAI enemyAIPatrol;
    [SerializeField] AIDetector bossBattle;
    [SerializeField] GameObject dialogueUI;
    [SerializeField] GameObject planeManager;

    public int tutorialIndex;
    public bool completeStep;

    int count;
    bool W, A, S, D;
    bool step1, step2, step3, step4, step5, step6, step7;

    DialogueManager dialogueManager;
    void Awake()
    {
        playerTank = GameObject.FindGameObjectWithTag("Player").GetComponent<TankController>();

        playerTank.canShoot = false;//Disable Shoot Function Of Player
        TankMachineGun machineGun = playerTank.GetComponentInChildren<TankMachineGun>();
        machineGun.canShoot = false;//Disable player machine guns

        playerTank.transform.GetComponent<SpeedUpControl>().tutorial = true;// Turn On tutorial mode on power ups
        playerTank.transform.GetComponent<BulletController>().tutorial = true;
        playerTank.transform.GetComponent<HealthPackControl>().tutorial = true;
        playerTank.transform.GetComponent<ShieldController>().tutorial = true;

        enemyAIStatic.canShoot = false;//Disable Shoot Function Of Enemy
        enemyAIPatrol.canShoot = false;

        dialogueManager = dialogueUI.GetComponent<DialogueManager>();
    }

    private void Start()
    {

    }

    void Update()
    {
        if (count < 3 && FindObjectOfType<TutorialManager>().tutorialIndex == 0)
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
                tutorialIndex = 0;
            }
        }

        //Check Tutorial Step Triggererd?
        if (enemyAIStatic.detector.TargetVisible)// check if player reach static enemy range
        {
            if (!step1)//We don't want to trigger multiple times because that can cause the dialogue error.
            {
                dialogueUI.SetActive(true);
                dialogueManager.StartDialogue(dialogueManager.dialogue[2]);//Show appropiate dialogue
                playerTank.canShoot = true;//Player can start shooting in this step
                tutorialIndex = 1;
                step1 = true;
            }
        }
        if (enemyAIPatrol.detector.TargetVisible)// Check if player reach patrolling enemy range
        {
            if (!step2)
            {
                dialogueUI.SetActive(true);
                dialogueManager.StartDialogue(dialogueManager.dialogue[3]);//Show appropiate dialogue
                TankMachineGun machineGun = playerTank.GetComponentInChildren<TankMachineGun>();
                machineGun.canShoot = true;//Enable player machine guns
                tutorialIndex = 2;
                step2 = true;
            }
        }
        if (bossBattle.TargetVisible)// check if player reach Boss 
        {
            if (!step7)
            {
                dialogueUI.SetActive(true);
                dialogueManager.StartDialogue(dialogueManager.dialogue[9]);//Show appropiate dialogue
                step7 = true;
            }
        }


        //Completion Tasks Dialogues
        if (tutorialIndex == 0 && completeStep)// Step 1
        {
            dialogueUI.SetActive(true);
            dialogueManager.StartDialogue(dialogueManager.dialogue[1]);// Show Completion Dialogue
            completeStep = false;//Reset completion
        }
        else if (tutorialIndex == 1 && completeStep)// Step 2 A(Main Cannon)
        {
            dialogueUI.SetActive(true);
            dialogueManager.StartDialogue(dialogueManager.dialogue[1]);// Show Completion Dialogue
            completeStep = false;//Reset completion
        }
        else if(tutorialIndex == 2 && completeStep)// Step 2 B(Machine Gun)
        {
            dialogueUI.SetActive(true);
            dialogueManager.StartDialogue(dialogueManager.dialogue[1]);// Show Completion Dialogue
            completeStep = false;
        }
        else if(tutorialIndex == 3 && completeStep)// Step 3 A Speed Power Up
        {
            dialogueUI.SetActive(true);
            dialogueManager.StartDialogue(dialogueManager.dialogue[1]);// Show Completion Dialogue
            completeStep = false;
        }
        else if(tutorialIndex == 4 && completeStep)// Step 3 B Bullet Power Up
        {
            dialogueUI.SetActive(true);
            dialogueManager.StartDialogue(dialogueManager.dialogue[1]);// Show Completion Dialogue
            completeStep = false;
        }
        else if (tutorialIndex == 5 && completeStep)// Step 3 C Shield Power Up
        {
            dialogueUI.SetActive(true);
            dialogueManager.StartDialogue(dialogueManager.dialogue[1]);// Show Completion Dialogue
            completeStep = false;
        }
        else if(tutorialIndex == 6 && completeStep)// Step 4 Health Pack
        {
            planeManager.SetActive(true); // Start Spawning Planes
            planeManager.GetComponent<PlaneManager>().ResetTimeToSpawn();// Reset the spawn time

            dialogueUI.SetActive(true);
            dialogueManager.StartDialogue(dialogueManager.dialogue[8]);// Show Completion Dialogue
            completeStep = false;
        }
    }

    public void TutorialPowerUpCheck(int index)
    {
        switch (index)
        {
            case 0:
                if (!step3)// check if the player found speed power up
                {
                    dialogueUI.SetActive(true);
                    dialogueManager.StartDialogue(dialogueManager.dialogue[4]);//Show appropiate dialogue
                    tutorialIndex = 3;
                    step3 = true;
                }
                break;
            case 1:
                if (!step4)// check if the player found bullet power up
                {
                    dialogueUI.SetActive(true);
                    dialogueManager.StartDialogue(dialogueManager.dialogue[5]);//Show appropiate dialogue
                    tutorialIndex = 4;
                    step4 = true;
                }
                break;
            case 2:
                if (!step5)// check if the player found shield power up
                {
                    dialogueUI.SetActive(true);
                    dialogueManager.StartDialogue(dialogueManager.dialogue[6]);//Show appropiate dialogue
                    tutorialIndex = 5;
                    step5 = true;
                }
                break;
            case 3:
                if (!step6)// check if the player found healthpack
                {
                    dialogueUI.SetActive(true);
                    dialogueManager.StartDialogue(dialogueManager.dialogue[7]);//Show appropiate dialogue
                    tutorialIndex = 6;
                    step6 = true;
                }
                break;
        }
    }

    public void TutorialStepComplete()
    {
        completeStep = true;
    }
}
