using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Stage 1")]
    public Dialogue[] dialogue;

    private Queue<string> _sentences;
    public TextMeshProUGUI conversationTMPro;
    public GameObject nextButton;
    public GameObject conversationTextField;
    public GameObject dialoguePanel;
    public Animator animator;

    int dialogueIndex;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        nextButton.SetActive(true);
        nextButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "START";
        conversationTextField.SetActive(true);
    }

    void Start()
    {
        _sentences = new Queue<string>();
        StartDialogue(dialogue[dialogueIndex]);
    }

    /// <summary>
    /// To start show the dialogue or sentences to the player
    /// </summary>
    /// <param name="dialogue"></param>
    /// 
    public void StartDialogue(Dialogue dialogue)
    {
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
        nextButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "NEXT";
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
        dialoguePanel.SetActive(false);
    }
}
