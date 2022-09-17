using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDotHandler : MonoBehaviour
{
    PointController pointController;
    private void Awake()
    {
        pointController = FindObjectOfType<PointController>();
    }
    public void ChangeTarget()
    {
        pointController.ChangeTarget(this.gameObject);
    }
}
