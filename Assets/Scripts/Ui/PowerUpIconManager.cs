using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIconManager : MonoBehaviour
{
    [SerializeField] GameObject[] powerUpIcons;
    void Start()
    {
        foreach(GameObject obj in powerUpIcons)
        {
            obj.SetActive(false);
        }
    }

    public void ShowIcon(int index)
    {
        for (int i = 0; i < powerUpIcons.Length; i++)
        {
            if(i == index)
            {
                powerUpIcons[i].SetActive(true);
            }
            else
            {
                powerUpIcons[i].SetActive(false);
            }
        }
    }

    public void HideIcon(int index)
    {
        if (powerUpIcons[index].activeInHierarchy)
        {
            powerUpIcons[index].SetActive(false);
        }
    }
}
