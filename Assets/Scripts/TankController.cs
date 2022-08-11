using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public TankMover tankMover;
    public AimTurret[] aimTurret;
    public Turret[] turrets;
    public bool canShoot = true;
    public bool canMove = true;
    public static int playerScore = 0;
    public static string PLAYERSCORE = "PlayerScore";

    private void Awake()
    {
        if (tankMover == null)
            tankMover = GetComponentInChildren<TankMover>();
        if (aimTurret == null || aimTurret.Length == 0)
        {
            aimTurret = GetComponentsInChildren<AimTurret>();
        }

        if (turrets == null || turrets.Length == 0)
        {
            turrets = GetComponentsInChildren<Turret>();
        }
    }

    private void Start()
    {
        playerScore = PlayerPrefs.GetInt(PLAYERSCORE, playerScore);
    }

    public void HandleShoot()
    {
        if (canShoot)
        {
            foreach (var turret in turrets)
            {
                turret.Shoot();
            }
        }

    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        if (canMove)
        {
            tankMover.Move(movementVector);
        }
        else
        {
            tankMover.Move(Vector2.zero);
        }
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        foreach (AimTurret turrent in aimTurret)
        {
            turrent.Aim(pointerPosition);
        }
    }
}
