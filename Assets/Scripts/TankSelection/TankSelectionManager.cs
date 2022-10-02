using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankSelectionManager : MonoBehaviour
{
    [SerializeField] UnityEvent OnFirstTime;
    [SerializeField] UnityEvent OnNotFirstTime;
    [SerializeField] GameObject[] borders;
    public static int tankIndex;

    public void CheckTank()
    {
        if (Player.instance.firstTime)
        {
            borders[1].SetActive(true);// Default Red Tank
            tankIndex = 1;

            OnFirstTime.Invoke();
        }
        else
        {
            OnNotFirstTime.Invoke();
        }
    }

    public void SelectTank(int index)
    {
        for (int i = 0; i < borders.Length; i++)
        {
            if(i == index)
            {
                borders[i].SetActive(true);
            }
            else
            {
                borders[i].SetActive(false);
            }
        }
        tankIndex = index;
    }

    public void ConfirmTank()
    {
        Player.instance.firstTime = false;
        Player.instance.tankIndex = tankIndex;
        Player.instance.SavePlayerData(); // Save player data
        OnNotFirstTime.Invoke();
    }
}
