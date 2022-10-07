using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour
{
    #region Variable
    public Transform tank;
    Transform MinimapCam;
    public float MinimapSize;
    public bool stayInideMap = false;

    #endregion

    private void Awake()
    {
        if (stayInideMap)
        {
            MinimapCam = GameObject.FindGameObjectWithTag("MiniMap").transform;
        }
    }

    private void Start()
    {
        tank = transform.parent.transform;
    }

    void LateUpdate()
    {
        if(tank != null && stayInideMap)
        {
            transform.position = new Vector3(Mathf.Clamp(tank.position.x, MinimapCam.position.x - MinimapSize, MinimapSize + MinimapCam.position.x),
                               Mathf.Clamp(tank.position.y, MinimapCam.position.y - MinimapSize, MinimapSize + MinimapCam.position.y),
                               transform.position.z);
        }
    }
}