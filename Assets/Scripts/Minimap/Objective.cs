using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objective : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectiveText;
    PointController pointController;

    private void Awake()
    {
        objectiveText.text = "Destroy the enemies tanks:";
        pointController = FindObjectOfType<PointController>();

        if (pointController == null)
        {
            Debug.Log("not found point controller");
        }
        else
        {
            Debug.Log("found");
            Debug.Log(pointController.dmg);
        }
    }

    private void Update()
    {

    }
}
