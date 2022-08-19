using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionLock : MonoBehaviour
{
    bool canPlay = false;
    public ScreenSwitcher _screenSwitcher;
    public TextMeshProUGUI missionLockText;
    public Animator animator;

    private void Awake()
    {
        _screenSwitcher = GameObject.Find("Main Camera").GetComponent<ScreenSwitcher>();
        missionLockText.enabled = false;
    }

    public void IsLock(int index)
    {
        CheckIndex(index);

        if (canPlay)
        {
            _screenSwitcher.LoadSceneIndex(index);
        }
    }

    public void CheckIndex(int index)
    {
        if (index == 1)
        {
            Debug.Log("You can play Mission 1.");
            canPlay = true;
        }
        else if (index == 2)
        {
            Debug.Log("You can play Mission 2.");
            canPlay = true;
        }
        else if (index == 3)
        {
            Debug.Log("Mission 3 is locked.");
            canPlay = false;
            ShowLockText(index);
        }
        else if (index == 4)
        {
            Debug.Log("Mission 4 is locked.");
            canPlay = false;
            ShowLockText(index);
        }
        else if (index == 5)
        {
            Debug.Log("Mission 5 is locked.");
            canPlay = false;
            ShowLockText(index);
        }
    }

    public void ShowLockText(int index)
    {
        missionLockText.enabled = true;
        animator.SetBool("IsOpening", true);
    }

    public void HideLockText()
    {
        missionLockText.enabled = false;
    }
}
