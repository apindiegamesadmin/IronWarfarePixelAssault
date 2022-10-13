using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    PlayerInput playerInput;
    Vector2 aimVelocity;
    public Joystick aimJoystick;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
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
