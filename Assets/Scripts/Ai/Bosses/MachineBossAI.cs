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
        mainCannonDetector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<TankController>();
    }

    private void Update()
    {
        if (mainCannonDetector.TargetVisible)// Shoot and move
        {
            shootBehaviour.PerformAction(tank, mainCannonDetector);
            machineShootBehaviour.PerformAction(tank, machineGunDetector);
        }
        else
        {
            patrolBehaviour.PerformAction(tank, mainCannonDetector);
            machineShootBehaviour.StopAction(tank, machineGunDetector);
        }
    }
}
