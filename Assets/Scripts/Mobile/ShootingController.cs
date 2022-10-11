using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    PlayerInput playerInput;
    public Joystick joystick;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    public void MainTurretShoot()
    {
        playerInput.GetShootingInput();
    }

    public void MachineGunShoot()
    {
        playerInput.MachineGunShootingInput();
    }

    public void MachineGunStop()
    {
        playerInput.MachineGunShootingOutput();
    }
}
