using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpControl : MonoBehaviour
{

   
    public TankMover tankmovement;  
    public TankMovementData movementData;
    public TankMovementData[] tankMovementDatas;
    public float duration = 10f;
    float timer;
    public static bool speedUp;
    public bool tutorial;

    //[Header("IconActive")]
    //public GameObject speedUp_Icon;
    //Fill up



   
    void Awake()
    {
        if (tankmovement == null)
            tankmovement = GetComponentInChildren<TankMover>();


        if (tankMovementDatas == null || tankMovementDatas.Length == 0)
            tankMovementDatas = GetComponents<TankMovementData>();
        //speedUp_Icon.SetActive(false);

    }
  

    void Update()
    {
        if (speedUp)
        {
            timer += Time.deltaTime;
            if (timer > duration)
            {
                speedUp = false;
                timer = 0;
            }
        }

        if (!speedUp)
        {
            tankmovement.movementData = tankMovementDatas[0];
            //speedUp_Icon.SetActive(false);
        }    
  
        if (speedUp && timer > 0.5)
        {
            tankmovement.movementData = tankMovementDatas[1];
            //speedUp_Icon.SetActive(true);
        }

    }









     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "SpeedUp" && collision.gameObject.layer == LayerMask.NameToLayer("Items"))
        {
            Destroy(collision.transform.gameObject);
            speedUp = true;
            if (tutorial)
            {
                tutorial = false;
                FindObjectOfType<TutorialManager>().completeStep = true;
            }
        }
    }
}
