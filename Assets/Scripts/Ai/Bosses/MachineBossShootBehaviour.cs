using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBossShootBehaviour : AIBehaviour
{
    public float fieldOfVisionForShooting = 60;

    TankMachineGun[] tankMachineGuns;

    public override void PerformAction(TankController tank, AIDetector detector)
    {
        if (TargetInFOV(tank, detector))
        {
            tankMachineGuns = tank.GetComponentsInChildren<TankMachineGun>();
            foreach(TankMachineGun machineGun in tankMachineGuns)
            {
                machineGun.StartShooting();
            }
        }
    }

    public override void StopAction(TankController tank, AIDetector detector)
    {
        tankMachineGuns = tank.GetComponentsInChildren<TankMachineGun>();
        foreach (TankMachineGun machineGun in tankMachineGuns)
        {
            machineGun.StopShooting();
        }
    }

    private bool TargetInFOV(TankController tank, AIDetector detector)
    {
        foreach (AimTurret turrent in tank.aimTurret)
        {
            var direction = detector.Target.position - turrent.transform.position;
            if (Vector2.Angle(turrent.transform.right, direction) < fieldOfVisionForShooting / 2)
            {
                return true;
            }
        }
        return false;
    }
}
