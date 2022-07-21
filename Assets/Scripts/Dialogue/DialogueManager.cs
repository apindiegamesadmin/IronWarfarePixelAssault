using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> _sentences;
    public TextMeshProUGUI conversationTMPro;
    public GameObject startButton;
    public GameObject nextButton;
    public GameObject welcomeTextField;
    public GameObject conversationTextField;
    public GameObject dialoguePanel;
    public Animator animator;

    private void Awake()
    {
        startButton.SetActive(true);
        welcomeTextField.SetActive(true);

        nextButton.SetActive(false);
        conversationTextField.SetActive(false);
    }

    void Start()
    {
        _sentences = new Queue<string>();
    }

    /// <summary>
    /// To start show the dialogue or sentences to the player
    /// </summary>
    /// <param name="dialogue"></param>
    public void StartDialogue(Dialogue dialogue)
    {
        startButton.SetActive(false);
        welcomeTextField.SetActive(false);

        nextButton.SetActive(true);
        conversationTextField.SetActive(true);
        animator.SetBool("IsConversationOpen", true);
        Debug.Log("Starting dialogue..");

        _sentences.Clear();

        // To Enqueue the dialogue sentences from dialogue class to this.sentences array
        foreach(string sentence in dialogue.sentences)
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
        if(_sentences.Count == 0)
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
    IEnumerator CloseDialogue()
    {
        animator.SetBool("IsConversationOpen", false);
        yield return new WaitForSeconds(0.6f);
        EndSentence();
    }

    /// <summary>
    /// if the player want to skip, we can create a btn and add this funtion to the btn
    /// Or
    /// when the dialogue is finished, the player play at the tutorial scene
    /// </summary>
    public void EndSentence()
    {
        Debug.Log("End Sentence");

        dialoguePanel.SetActive(false);
    }
}
