using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    TMP_Dropdown dropDown;
    Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        dropDown = GetComponent<TMP_Dropdown>();
    }

    private void Start()
    {
        switch (player.screenIndex)
        {
            case 0:
                dropDown.value = 0;
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            case 1:
                dropDown.value = 1;
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
        }
    }
    public void OnDropDownValueChanged()
    {
        if(dropDown.value == 0)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    private void OnDisable()
    {
        player.screenIndex = dropDown.value;
        player.SavePlayerData();
    }
}
