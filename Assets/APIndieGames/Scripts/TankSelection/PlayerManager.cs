using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject TankRed;
    public GameObject TankBlue;
    public GameObject TankSand;

    FollowCamera followCamera;


    private void Awake()
    {
        followCamera = FindObjectOfType<FollowCamera>();

        TankBlue.SetActive(false);
        TankRed.SetActive(false);
        TankSand.SetActive(false);

        int index = PlayerPrefs.GetInt("TankIndex");

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

    private void Start()
    {
        followCamera.ChangeTarget();
    }
}
