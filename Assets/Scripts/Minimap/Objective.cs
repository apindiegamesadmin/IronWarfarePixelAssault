using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objective : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectiveText;

    PointController pointController;
    int id;

    private void Awake()
    {
        objectiveText.text = "Destroy the enemies tanks:";
        pointController = FindObjectOfType<PointController>();
        id = pointController.tankID;
    }

    private void Update()
    {
        if (id == 0)
        {
            objectiveText.text = "Destroy the static enemy!";
        }
        else if (id == 1)
        {
            objectiveText.text = "Destroy the patrol enemy!";
        }
        else
        {
            objectiveText.text = "Go & Destroy the enemy boss!";
        }
    }
}
