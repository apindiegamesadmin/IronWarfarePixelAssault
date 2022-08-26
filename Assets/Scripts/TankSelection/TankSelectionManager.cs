using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankSelectionManager : MonoBehaviour
{
    [SerializeField]UnityEvent OnFirstTime;
    [SerializeField] GameObject[] borders;
    public static int tankIndex;
    public static bool firstTime = true;

    void Start()
    {
        CheckTank();
    }

    public void CheckTank()
    {
        if (firstTime)
        {
            OnFirstTime.Invoke();
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
        firstTime = false;
    }
}
