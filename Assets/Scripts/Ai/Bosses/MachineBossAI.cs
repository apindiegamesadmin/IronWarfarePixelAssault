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
    PatrolPath patrolPath;
    List<Transform> path;

    private void Awake()
    {
        mainCannonDetector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<TankController>();
        patrolPath = GetComponentInChildren<PatrolPath>();
        path = patrolPath.patrolPoints;
    }

    private void Update()
    {
        if (mainCannonDetector.TargetVisible)// Check if main cannon detector's target is visible
        {
            shootBehaviour.PerformAction(tank, mainCannonDetector);
            patrolPath.patrolPoints = new List<Transform>();
            for (int i = 0; i < 2; i++)
            {
                patrolPath.patrolPoints.Add(mainCannonDetector.Target.transform);
            }
            patrolBehaviour.PerformAction(tank, mainCannonDetector);
        }
        else
        {
            patrolPath.patrolPoints = path;
            patrolBehaviour.PerformAction(tank, mainCannonDetector);
        }

        if (machineGunDetector.TargetVisible) // Check if machine gun detector's target is visible
        {
            machineShootBehaviour.PerformAction(tank, machineGunDetector);
        }
        else
        {
            machineShootBehaviour.StopAction(tank, machineGunDetector);
        }
    }
}
