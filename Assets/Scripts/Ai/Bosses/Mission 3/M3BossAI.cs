using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3BossAI : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour machineShootBehaviour, patrolBehaviour;

    [SerializeField]
    private TankController tank;
    [SerializeField]
    public AIDetector machineGunDetector;
    public bool flying;

    private void Awake()
    {
        tank = GetComponentInChildren<TankController>();
    }

    private void Update()
    {
        if (machineGunDetector.TargetVisible && !flying) // Check if machine gun detector's target is visible
        {
            machineShootBehaviour.PerformAction(tank, machineGunDetector);
        }
        else
        {
            machineShootBehaviour.StopAction(tank, machineGunDetector);
        }
    }
}
