using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSoldierAI : MonoBehaviour
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
        if (detector.TargetVisible)
        {
            patrolPath.patrolPoints = new List<Transform>();
            for (int i = 0; i < 2; i++)
            {
                patrolPath.patrolPoints.Add(detector.Target.transform);
            }
            patrolBehaviour.PerformAction(tank, detector);

            if (Vector2.Distance(transform.position, detector.Target.transform.position) <= 0.5f)
            {
                shootBehaviour.PerformAction(tank, detector);
            }
        }
        else
        {
            patrolBehaviour.PerformAction(tank, detector);
        }
    }
}
