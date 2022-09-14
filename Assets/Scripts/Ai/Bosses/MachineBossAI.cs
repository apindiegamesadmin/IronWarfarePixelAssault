using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBossAI : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shootBehaviour , machineShootBehaviour, patrolBehaviour;

    [SerializeField]
    private TankController tank;
    [SerializeField]
    public AIDetector mainCannonDetector;
    public AIDetector machineGunDetector;

    private void Awake()
    {
        //mainCannonDetector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<TankController>();
    }

    private void Update()
    {
        if (mainCannonDetector.TargetVisible)// Check if main cannon detector's target is visible
        {
            shootBehaviour.PerformAction(tank, mainCannonDetector);

            if (machineGunDetector.TargetVisible) // Check if machine gun detector's target is visible
            {
                machineShootBehaviour.PerformAction(tank, machineGunDetector);
            }
            else
            {
                machineShootBehaviour.StopAction(tank, machineGunDetector);
            }
        }
        else
        {
            patrolBehaviour.PerformAction(tank, mainCannonDetector);
            machineShootBehaviour.StopAction(tank, machineGunDetector);
        }
    }
}
