using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCheck : MonoBehaviour
{
    [SerializeField] int stepIndex;
    AIDetector aiDetector;
    TutorialManager tutorialManager;
    void Awake()
    {
        aiDetector = GetComponent<AIDetector>();
        tutorialManager = FindObjectOfType<TutorialManager>();
    }

    
    void Update()
    {
        if (aiDetector.TargetVisible)
        {
            tutorialManager.TutorialPowerUpCheck(stepIndex);
        }
    }
}
