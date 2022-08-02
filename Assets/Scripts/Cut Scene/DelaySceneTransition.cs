using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelaySceneTransition : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(2);//Load Tutorial Scene
    }
}
