using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    PlayerInput playerInput;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    public void MachineGunShoot()
    {
        playerInput.MachineGunShootingInput();
        Debug.Log("Shooting...");
    }

    public void MachineGunStop()
    {
        playerInput.MachineGunShootingOutput();
        Debug.Log("Shooting stop...");
    }
}
