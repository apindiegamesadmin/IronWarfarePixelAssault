using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Dialogue[] dialogue;
    public TextMeshProUGUI conversationTMPro;

    int dialogueIndex;
    TankController playerTank;
    Queue<string> _sentences;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _sentences = new Queue<string>();
        playerTank = GameObject.FindGameObjectWithTag("Player").GetComponent<TankController>();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.3f);
        StartDialogue(dialogue[dialogueIndex]);
    }

    /// <summary>
    /// To start show the dialogue or sentences to the player
    /// </summary>
    /// <param name="dialogue"></param>
    /// 
    public void StartDialogue(Dialogue dialogue)
    {
        playerTank.canMove = false;
        _sentences.Clear();

        // To Enqueue the dialogue sentences from dialogue class to this.sentences array
        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    /// <summary>
    /// To display next dialogue by clicking the next btn
    /// </summary>
    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            StopAllCoroutines();
            StartCoroutine(CloseDialogue());
            return;
        }

        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    /// <summary>
    /// To make the writing effect in dialogue box
    /// </summary>
    /// <param name="sentence"></param>
    /// <returns></returns>
    IEnumerator TypeSentence(string sentence)
    {
        conversationTMPro.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            conversationTMPro.text += letter;
            yield return null;
        }
    }

    /// <summary>
    /// To wait for closing the dialogue text field and animation
    /// </summary>
    /// <returns></returns>
    /// 
    IEnumerator CloseDialogue()
    {
        animator.Play("Dialogue_Close");
        yield return new WaitForSeconds(0.4f);
        dialogueIndex++;
        EndSentence();
    }

    /// <summary>
    /// if the player want to skip, we can create a btn and add this funtion to the btn
    /// Or
    /// when the dialogue is finished, the player play at the tutorial scene
    /// </summary>
    public void EndSentence()
    {
        playerTank.canMove = true;
        this.gameObject.SetActive(false);
    }
}
