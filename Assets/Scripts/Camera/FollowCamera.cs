using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowCamera : MonoBehaviour
{
    CinemachineVirtualCamera cinemachineCamera;

    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineCamera.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        cinemachineCamera.LookAt = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
