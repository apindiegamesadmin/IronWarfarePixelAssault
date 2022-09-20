using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBossAI : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shootBehaviour, patrolBehaviour;

    [SerializeField]
    private TankController tank;
    [SerializeField]
    public AIDetector detector;
    PatrolPath patrolPath;
    List<Transform> path;

    private void Awake()
    {
        detector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<TankController>();
        patrolPath = GetComponentInChildren<PatrolPath>();
        path = patrolPath.patrolPoints;
    }

    private void Update()
    {
        if (detector.TargetVisible)// Shoot and move
        {
            shootBehaviour.PerformAction(tank, detector);
            patrolPath.patrolPoints = new List<Transform>();
            for (int i = 0; i < 2; i++)
            {
                patrolPath.patrolPoints.Add(detector.Target.transform);
            }
            patrolBehaviour.PerformAction(tank, detector);
        }
        else
        {
            patrolPath.patrolPoints = path;
            patrolBehaviour.PerformAction(tank, detector);
        }
    }
}
