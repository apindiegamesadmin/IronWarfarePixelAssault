using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class Objective : MonoBehaviour
{
    TextMeshProUGUI objectiveText;

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

    public void RemoveObjective()
    {
        objectiveText.text = "";
    }
}
