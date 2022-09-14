using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour
{
    Transform tank;
    public Transform MinimapCam;
    public float MinimapSize;
    Vector3 TempV3;
    Transform player;
    [SerializeField] float radius;
    [SerializeField] LayerMask iconLayerMask;

    private void Awake()
    {
        tank = transform.parent.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        TempV3 = transform.parent.transform.position;
        TempV3.y = transform.position.y;
        transform.position = TempV3;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(tank.position.x, MinimapCam.position.x - MinimapSize, MinimapSize + MinimapCam.position.x),
                                       Mathf.Clamp(tank.position.y, MinimapCam.position.y - MinimapSize, MinimapSize + MinimapCam.position.y),
                                       transform.position.z);

        /*
        // * find the distance between and red dot
        // * subtract radius from that distance to show red dot in minimap camera view
        float distanceBetweenPlayerAndRedDot = Vector2.Distance(transform.position, player.position);
        float desiredDistanceToDisplay = distanceBetweenPlayerAndRedDot - radius;

        //  Checked if the red dot is inside the circle or not
        Collider2D collider2D = Physics2D.OverlapCircle(player.transform.position, radius, iconLayerMask);
        if (collider2D == null)
        {
            Debug.Log("hiiiiiiii");
            transform.position = new Vector3(Mathf.Clamp(tank.position.x, MinimapCam.position.x - MinimapSize, MinimapSize + MinimapCam.position.x - desiredDistanceToDisplay),
                                        Mathf.Clamp(tank.position.y, MinimapCam.position.y - MinimapSize, MinimapSize + MinimapCam.position.y - desiredDistanceToDisplay),
                                        transform.position.z);
        }
        else
        {
            Debug.Log("hellooooooooo");
            transform.position = new Vector3(Mathf.Clamp(tank.position.x, MinimapCam.position.x - MinimapSize, MinimapSize + MinimapCam.position.x),
                                        Mathf.Clamp(tank.position.y, MinimapCam.position.y - MinimapSize, MinimapSize + MinimapCam.position.y),
                                        transform.position.z);
        }
        */
    }
}