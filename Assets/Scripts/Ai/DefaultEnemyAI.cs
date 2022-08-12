using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyAI : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shootBehaviour, patrolBehaviour;

    [SerializeField]
    private TankController tank;
    [SerializeField]
    public AIDetector detector;
    public bool canShoot = true;
    public bool boss;

    private void Awake()
    {
        detector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<TankController>();
    }

    private void Update()
    {
        if (boss)
        {
            if (detector.TargetVisible && canShoot)// Shoot and move
            {
                shootBehaviour.PerformAction(tank, detector);
                patrolBehaviour.PerformAction(tank, detector);
            }
            else
            {
                patrolBehaviour.PerformAction(tank, detector);
            }
        }
        else
        {
            if (detector.TargetVisible && canShoot)//Can't Shoot Back In Tutorial
            {
                shootBehaviour.PerformAction(tank, detector);
            }
            else
            {
                patrolBehaviour.PerformAction(tank, detector);
            }
        }
    }
}
