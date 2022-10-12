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

    private void Update()
    {
        // TurretAim();
    }

    // public void MainTurretShoot()
    // {
    // TurretAim();
    // playerInput.GetShootingInput();
    // }

    // public void TurretAim()
    // {
    //     aimVelocity = new Vector2(aimJoystick.Horizontal, aimJoystick.Vertical);
    //     Vector2 aimInput = new Vector2(aimVelocity.x, aimVelocity.y);
    //     Vector2 lookAtPoint = (Vector2)transform.position + aimInput;
    //     transform.LookAt(lookAtPoint);
    // }

    public void MachineGunShoot()
    {
        playerInput.MachineGunShootingInput();
    }

    public void MachineGunStop()
    {
        playerInput.MachineGunShootingOutput();
    }
}
