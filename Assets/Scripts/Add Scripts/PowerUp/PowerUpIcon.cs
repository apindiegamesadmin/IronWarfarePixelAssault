using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpIcon : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool airDrop;

    IEnumerator Start()
    {
        if (airDrop)
        {
            yield return new WaitForSeconds(5);
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        transform.Rotate(0,0,speed*Time.deltaTime);
    }


}
