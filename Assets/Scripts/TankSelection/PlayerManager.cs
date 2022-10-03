using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject TankRed;
    public GameObject TankBlue;
    public GameObject TankSand;

    FollowCamera followCamera;
    Player player;

    private void Awake()
    {
        followCamera = FindObjectOfType<FollowCamera>();
        player = FindObjectOfType<Player>();

        TankBlue.SetActive(false);
        TankRed.SetActive(false);
        TankSand.SetActive(false);

        switch (player.tankIndex)
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
