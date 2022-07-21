using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIcon : MonoBehaviour
{
    [SerializeField] private float speed;


     void Update()
    {


        transform.Rotate(Vector2.up * speed * Time.deltaTime);
    }


}
