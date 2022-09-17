using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour
{
    #region Variable
    public Transform tank;
    Transform MinimapCam;
    public float MinimapSize;
    Vector3 TempV3;
    Transform player;

    #endregion

    private void Start()
    {
        MinimapCam = GameObject.FindGameObjectWithTag("MiniMap").transform;
        tank = transform.parent.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //TempV3 = transform.parent.transform.position;
        //TempV3.y = transform.position.y;
        //transform.position = TempV3;
    }

    void LateUpdate()
    {
        if(tank != null)
        {
            transform.position = new Vector3(Mathf.Clamp(tank.position.x, MinimapCam.position.x - MinimapSize, MinimapSize + MinimapCam.position.x),
                               Mathf.Clamp(tank.position.y, MinimapCam.position.y - MinimapSize, MinimapSize + MinimapCam.position.y),
                               transform.position.z);
        }
    }
}