using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class Objective : MonoBehaviour
{
    TextMeshProUGUI objectiveText;
    [SerializeField] Transform[] objectivePoints;
    [SerializeField] StayInside objectivePointer;

    [SerializeField] string[] objectives;

    private void Awake()
    {
        objectiveText = GetComponent<TextMeshProUGUI>();
        objectiveText.text = "";
    }

    public void ShowObjective(int index)
    {
        objectiveText.text = objectives[index];
    }

    public void UpdateObjectivePointer(int i)
    {
        objectivePointer.tank = objectivePoints[i];
    }

    public void RemoveObjective()
    {
        objectiveText.text = "";
    }
}
