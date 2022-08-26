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
        TankBlue.SetActive(false);
        TankRed.SetActive(false);
        TankSand.SetActive(false);

        int index = TankSelectionManager.tankIndex;

        switch (index)
        {
            case 0:
                TankBlue.SetActive(true);
                break;
            case 1:
                TankRed.SetActive(true);
                break;
            case 2:
                TankSand.SetActive(true);
                break;
        }
    }
}
