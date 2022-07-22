using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public Turret turret;
    public TurretData turretData;
    public TurretData[] turretDatas;
    public float timer;
    public bool damageUp;

     void Awake()
    {
        if (turret == null)
            turret = GetComponentInChildren<Turret>();

        if (turretDatas == null || turretDatas.Length == 0)
            turretDatas = GetComponentsInChildren<TurretData>();
       
    }

    void Update()
    {
        if (damageUp)
        {
            timer += Time.deltaTime;
            if (timer > 10.0f)
            {
                damageUp = false;
                timer = 0;

            }
        }

        if (!damageUp)
        {
            turret.turretData = turretDatas[0];
        }

        if (damageUp && timer > 0.5)
        {
            turret.turretData = turretDatas[1];
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

        if (collision.transform.tag == "DamageUp")
        {
            Destroy(collision.transform.gameObject, 0.5f);
            damageUp = true;
        }
    }

}
