using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] int index;

    GameObject dialogue;
    AIDetector detector;
    DialogueManager dialogueManager;
    Objective objective;
    void Awake()
    {
        dialogue = GameObject.FindGameObjectWithTag("Dialogue");
        detector = GetComponentInChildren<AIDetector>();
        dialogueManager = dialogue.GetComponent<DialogueManager>();
        objective = FindObjectOfType<Objective>();
    }

    void Update()
    {
        if (detector.TargetVisible)
        {
            dialogue.SetActive(true);
            dialogueManager.StartDialogue(dialogueManager.dialogue[index]);
            objective.ShowObjective(index);
            objective.UpdateObjectivePointer(index);
            Destroy(this.transform.gameObject);
        }
    }
}
