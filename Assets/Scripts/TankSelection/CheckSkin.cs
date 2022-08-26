using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSkin : MonoBehaviour
{
    public GameObject TankRed;
    public GameObject TankBlue;
    public GameObject TankSand;

    private void Awake()
    {
        int index = TankSelectionManager.skinIndex;

        if (index == 0)
        {
            TankBlue.SetActive(true);
            TankRed.SetActive(false);
            TankSand.SetActive(false);
        }
        else if (index == 1)
        {
            TankBlue.SetActive(false);
            TankRed.SetActive(true);
            TankSand.SetActive(false);
        }
        else if (index == 2)
        {
            TankBlue.SetActive(false);
            TankRed.SetActive(false);
            TankSand.SetActive(true);
        }
    }
}
