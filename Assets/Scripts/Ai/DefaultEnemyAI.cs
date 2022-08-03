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
    private AIDetector detector;
    [SerializeField] bool tutorial;
    bool alreadyTriggered;

    private void Awake()
    {
        detector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<TankController>();
    }

    private void Update()
    {
        if (detector.TargetVisible && !tutorial)//Can't Shoot Back In Tutorial
        {
            shootBehaviour.PerformAction(tank, detector);
        }
        else if(detector.TargetVisible && tutorial)//Trigger Tutorial Dialogue For Step 2
        {
            if (!alreadyTriggered)
            {
                FindObjectOfType<TutorialManager>().TutorialDialogueTrigger(2);
                alreadyTriggered = true;
            }
        }
        else
        {
            patrolBehaviour.PerformAction(tank, detector);
        }
    }
}
