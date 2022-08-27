using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Turret turret;
    ObjectPool objectPool;
    public TurretData turretData;
    public TurretData[] turretDatas;
    public Transform[] barrels;
    public float duration = 10f;
    float skillTimer;
    public bool damageUp;
    public bool tutorial;
    public bool isHomingMissleActive = false;

    PowerUpIconManager iconManager;


    void Awake()
    {
        iconManager = FindObjectOfType<PowerUpIconManager>();

        if (turret == null)
            turret = GetComponentInChildren<Turret>();

        if (turretDatas == null || turretDatas.Length == 0)
            turretDatas = GetComponentsInChildren<TurretData>();

        objectPool = GetComponentInChildren<ObjectPool>();

    }



    void Update()
    {

        if (damageUp)
        {
            skillTimer += Time.deltaTime;

            if (skillTimer > duration)
            {
                damageUp = false;
                skillTimer = 0;
                iconManager.HideIcon(0);

                turret.turretData = turretDatas[0];
                foreach (Transform barrel in barrels)
                {
                    turret.turretBarrels.Remove(barrel);
                }
                turret.bulletPoolCount = 1;
            }
        }

        if (isHomingMissleActive)
        {
            turret.turretData = turretDatas[2];
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "HomingMissle")
        {
            Destroy(collision.transform.gameObject);
            turret.turretData = turretDatas[2];

            isHomingMissleActive = true;
            // damageUp = false;
            Debug.Log("Homing missile is active");
        }

        if (collision.transform.tag == "DamageUp")
        {
            Destroy(collision.transform.gameObject);
            damageUp = true;
            iconManager.ShowIcon(0);
            turret.turretData = turretDatas[1];

            foreach (Transform barrel in barrels)
            {
                turret.turretBarrels.Add(barrel);
            }

            turret.bulletPoolCount = 3;

            if (tutorial)
            {
                tutorial = false;
                FindObjectOfType<TutorialManager>().completeStep = true;
            }
        }


    }

}
