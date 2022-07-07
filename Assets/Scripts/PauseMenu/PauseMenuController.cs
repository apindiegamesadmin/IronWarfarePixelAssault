using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;

    void Start()
    {
        _pauseMenu.SetActive(false);
    }

    void Update()
    {

    }

    public void Pause()
    {
        
    }
}
