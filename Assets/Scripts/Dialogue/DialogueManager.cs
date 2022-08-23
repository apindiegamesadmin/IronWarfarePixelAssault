using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Dialogue[] dialogue;
    [SerializeField] GameObject nextButton;
    public TextMeshProUGUI conversationTMPro;

    Queue<string> _sentences;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _sentences = new Queue<string>();
        nextButton.SetActive(false);
    }

    void Start()
    {
        //yield return new WaitForSeconds(0.3f);
        StartDialogue(dialogue[0]);
    }

    /// <summary>
    /// To start show the dialogue or sentences to the player
    /// </summary>
    /// <param name="dialogue"></param>
    /// 
    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;
        nextButton.SetActive(false);
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
        nextButton.SetActive(false);
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

        yield return new WaitForSecondsRealtime(0.3f);

        foreach(char letter in sentence.ToCharArray())
        {
            conversationTMPro.text += letter;
            yield return null;
        }
        nextButton.SetActive(true);
    }

    /// <summary>
    /// To wait for closing the dialogue text field and animation
    /// </summary>
    /// <returns></returns>
    /// 
    IEnumerator CloseDialogue()
    {
        animator.Play("Dialogue_Close");
        yield return new WaitForSecondsRealtime(0.4f);
        EndSentence();
    }

    /// <summary>
    /// if the player want to skip, we can create a btn and add this funtion to the btn
    /// Or
    /// when the dialogue is finished, the player play at the tutorial scene
    /// </summary>
    public void EndSentence()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
