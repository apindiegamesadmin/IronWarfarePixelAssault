using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Turret turret;
    public TurretData turretData;
    public TurretData[] turretDatas;
    public Transform[] barrels;
    public float duration = 10f;
    float skillTimer;
    public bool damageUp;
    public bool tutorial;
    public bool isHomingMissleActive = false;

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
        if (turret.turretBarrels.Count == 1)
        {
            tripleShootIcon.SetActive(false);
        }


        if (damageUp)
        {
            tripleShootIcon.SetActive(true);
            skillTimer += Time.deltaTime;

            if (skillTimer > duration)
            {
                damageUp = false;
                skillTimer = 0;
            }
        }

        if (!damageUp)
        {
            turret.turretData = turretDatas[0];
            foreach (Transform barrel in barrels)
            {
                turret.turretBarrels.Remove(barrel);
            }
            turret.bulletPoolCount = 1;
        }

        if (damageUp && skillTimer > 0.5)
        {
            turret.turretData = turretDatas[1];
        }

        if (isHomingMissleActive)
        {
            this.turretData = turretDatas[2];
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "HomingMissle")
        {
            Destroy(collision.transform.gameObject);
            isHomingMissleActive = true;
            // damageUp = false;
            Debug.Log("Homing missle is active");
        }

        if (collision.transform.tag == "DamageUp")
        {
            Destroy(collision.transform.gameObject);
            damageUp = true;

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
