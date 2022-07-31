using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Open(int index)
    {
        animator.Play("Mission_" + index + "_Open");
    }

    public void Close(int index)
    {
        animator.Play("Mission_" + index + "_Close");
    }
}
