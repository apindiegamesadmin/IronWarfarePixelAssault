using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    Transform player;
    //Vector3 pos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // transform.position = new Vector3(-12.1417198f, -13.2733755f, 0.110948563f);
    }

    public void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
