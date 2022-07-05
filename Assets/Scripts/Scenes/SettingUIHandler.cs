using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingUIHandler : MonoBehaviour
{
    public GameObject[] navButtons;
    public Color gray;
    public void OnClickButton(GameObject activeButton)
    {
        foreach(GameObject button in navButtons)
        {
            if(button == activeButton)
            {
                button.GetComponent<Image>().color = Color.white;
            }
            else
            {
                button.GetComponent<Image>().color = gray;
            }
        }
    }
}
