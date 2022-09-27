using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4TurretAi : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shootBehaviour;

    [SerializeField]
    private TankController tank;
    [SerializeField]
    public AIDetector detector;

    private void Awake()
    {
        detector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<TankController>();
    }

    private void Update()
    {
        if (detector.TargetVisible)
        {
            shootBehaviour.PerformAction(tank, detector);
        }
    }
}
