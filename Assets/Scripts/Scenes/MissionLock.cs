using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionLock : MonoBehaviour
{
    bool canPlay = false;
    public ScreenSwitcher _screenSwitcher;

    private void Awake()
    {
        _screenSwitcher = GameObject.Find("Main Camera").GetComponent<ScreenSwitcher>();
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
            Debug.Log("You can play");
            canPlay = true;
        }
        else if (index == 2)
        {
            Debug.Log("You can play");
            canPlay = true;
        }
        else if (index == 3)
        {
            Debug.Log("Mission is locked.");
            canPlay = false;
        }
        else if (index == 4)
        {
            Debug.Log("Mission is locked.");
            canPlay = false;
        }
        else if (index == 5)
        {
            Debug.Log("Mission is locked.");
            canPlay = false;
        }
    }
}
