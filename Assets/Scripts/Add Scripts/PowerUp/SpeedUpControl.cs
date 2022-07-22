using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpControl : MonoBehaviour
{

   
    public TankMover tankmovement;  
    public TankMovementData movementData;
    public TankMovementData[] tankMovementDatas;
    public float timer;
    public bool speedUp;


   
    void Awake()
    {
        if (tankmovement == null)
            tankmovement = GetComponentInChildren<TankMover>();

        if (tankMovementDatas == null || tankMovementDatas.Length == 0)
        
            tankMovementDatas = GetComponents<TankMovementData>();
        

    }
  

    void Update()
    {
        if (speedUp)
        {
            timer += Time.deltaTime;
            if (timer > 10.0f)
            {
                speedUp = false;
                timer = 0;

            }
        }

        if (!speedUp)
        {
            tankmovement.movementData = tankMovementDatas[0];
        }    
  
        if (speedUp && timer > 0.5)
        {
            tankmovement.movementData = tankMovementDatas[1];
        }




    }







    void OnCollisionStay2D(Collision2D collision)
    {
        
        Debug.Log(collision.transform.name);
        Debug.Log("Power Up Collision Work");
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.name);
        Debug.Log("Power Up Trigger Work");

        if(collision.transform.tag == "SpeedUp")
        {
            Destroy(collision.transform.gameObject, 0.5f);
            speedUp = true;
        }
    }
}
