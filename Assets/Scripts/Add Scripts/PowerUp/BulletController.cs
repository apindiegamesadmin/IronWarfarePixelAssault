using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public Turret turret;
    public TurretData turretData;
    public TurretData[] turretDatas;
    public Transform leftBarrel;
    public Transform rightBarrel;
    public Transform midBarrel;
    public int barrelsInTurret;
    public float skillTimer;
    public float iconTimer;
    public bool damageUp;

    public GameObject tripleShootIcon;


     void Awake()
    {
        if (turret == null)
            turret = GetComponentInChildren<Turret>();

        if (turretDatas == null || turretDatas.Length == 0)
            turretDatas = GetComponentsInChildren<TurretData>();
        tripleShootIcon.SetActive(false);

    }



    void Update()
    {
        if(turret.turretBarrels.Count==1)
        {
            tripleShootIcon.SetActive(false);
        }


        if (damageUp)
        {
            tripleShootIcon.SetActive(true);
            turret.turretBarrels.Add(leftBarrel);
            turret.turretBarrels.Add(midBarrel);
            turret.turretBarrels.Add(rightBarrel);

            turret.bulletPoolCount = 3;


            skillTimer += Time.deltaTime;
            

            if (skillTimer >5.0f)
            {
                damageUp = false;
                skillTimer = 0;
              

            }

            
        }


        if (!damageUp)
        {
            turret.turretData = turretDatas[0];
            turret.turretBarrels.Remove(leftBarrel);
            turret.turretBarrels.Remove(midBarrel);
            turret.turretBarrels.Remove(rightBarrel);
            turret.bulletPoolCount = 1;
        }

        if (damageUp && skillTimer > 0.5)
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
