using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] int index;

    GameObject dialogue;
    AIDetector detector;
    DialogueManager dialogueManager;
    void Awake()
    {
        dialogue = GameObject.FindGameObjectWithTag("Dialogue");
        detector = GetComponent<AIDetector>();
        dialogueManager = dialogue.GetComponent<DialogueManager>();
    }

    void Update()
    {
        if (detector.TargetVisible)
        {
            dialogue.SetActive(true);
            dialogueManager.StartDialogue(dialogueManager.dialogue[index]);
            Destroy(this.transform.parent.gameObject);
        }
    }
}
