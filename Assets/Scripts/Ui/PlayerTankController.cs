using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTankController : MonoBehaviour
{
    [SerializeField] Color heartColor;
    Transform heartHolder;
    Image[] hearts;
    void Start()
    {
        heartHolder = GameObject.FindGameObjectWithTag("Heart").transform;//Get the reference of heart holder
        hearts = heartHolder.GetComponentsInChildren<Image>();//Get image component of hearts
        foreach (var heart in hearts)
        {
            heart.color = heartColor;//Assign Color
        }
    }
}
