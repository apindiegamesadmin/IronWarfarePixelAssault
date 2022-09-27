using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4BossAi : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shootBehaviour, patrolBehaviour;

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
        patrolBehaviour.PerformAction(tank, detector);
    }
}
