using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Image leftCharacter;
    [SerializeField] Image rightCharacter;

    [SerializeField] Sprite[] characters;

    public Dialogue[] dialogue;
    public Dialogue currentDialogue;
    [SerializeField] GameObject nextButton;
    public TextMeshProUGUI conversationTMPro;

    Queue<string> _sentences;
    Animator animator;
    PauseMenu pauseMenu;
    TankMachineGun playerMachineGun;

    int conversationIndex = 0;

    private void Awake()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        animator = GetComponent<Animator>();
        _sentences = new Queue<string>();
        nextButton.SetActive(false);
        playerMachineGun = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<TankMachineGun>();
    }

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        switch (dialogue.conversation[conversationIndex].Character)
        {
            case Conversation.character.TankCommander:
                animator.SetTrigger("Left_Start");
                leftCharacter.sprite = characters[0];
                break;
            case Conversation.character.Narrator:
                animator.SetTrigger("Right_Start");
                rightCharacter.sprite = characters[1];
                break;
            case Conversation.character.Villain:
                animator.SetTrigger("Right_Start");
                rightCharacter.sprite = characters[2];
                break;
        }

        pauseMenu.isGamePaused = true;
        playerMachineGun.StopShooting();
        Time.timeScale = 0;
        nextButton.SetActive(false);
        _sentences.Clear();

        // To Enqueue the dialogue sentences from dialogue class to this.sentences array
        foreach (string sentence in dialogue.conversation[conversationIndex].sentences)
        {
            _sentences.Enqueue(sentence);
        }

        currentDialogue = dialogue;
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
            conversationIndex++;
            if (conversationIndex + 1 > currentDialogue.conversation.Length)
            {
                conversationIndex = 0;
                StopAllCoroutines();
                StartCoroutine(CloseDialogue());
            }
            else
            {
                StartCoroutine(ChangeCharacter());
            }
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

        yield return new WaitForSecondsRealtime(0.4f);

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

    IEnumerator ChangeCharacter()
    {
        animator.SetTrigger("End");
        yield return new WaitForSecondsRealtime(0.3f);
        StartDialogue(currentDialogue);
    }

    IEnumerator CloseDialogue()
    {
        animator.SetTrigger("End");
        yield return new WaitForSecondsRealtime(0.3f);
        EndSentence();
    }

    /// <summary>
    /// if the player want to skip, we can create a btn and add this funtion to the btn
    /// Or
    /// when the dialogue is finished, the player play at the tutorial scene
    /// </summary>
    public void EndSentence()
    {
        pauseMenu.isGamePaused = false;
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
