using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] Transform[] path;
    [SerializeField] TankController playerTank;
    [SerializeField] GameObject dialogueUI;
    void Start()
    {
        dialogueUI.SetActive(true);
    }

    
    void Update()
    {

    }
}
