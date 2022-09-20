using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    PowerupSound _powerupSound;
    Turret turret;
    ObjectPool objectPool;
    public TurretData[] turretDatas;
    public Transform[] barrels;
    public float duration = 10f;
    float skillTimer;
    public bool damageUp;
    public bool tutorial;
    bool isHomingMissileActive;

    PowerUpIconManager iconManager;


    void Awake()
    {
        iconManager = FindObjectOfType<PowerUpIconManager>();
        //_powerupSound = GameObject.Find("PowerupSound").GetComponent<PowerupSound>();

        if (turret == null)
            turret = GetComponentInChildren<Turret>();

        objectPool = GetComponentInChildren<Turret>().transform.GetComponent<ObjectPool>();

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

        if (isHomingMissileActive)
        {
            skillTimer += Time.deltaTime;

            if (skillTimer >= duration)
            {
                isHomingMissileActive = false;
                skillTimer = 0;
                turret.turretData = turretDatas[0];
                foreach (Transform barrel in barrels)
                {
                    turret.turretBarrels.Remove(barrel);
                }

                //turret.bulletPoolCount = 1;
                objectPool.DestroyBullets();
                objectPool.Initialize(turretDatas[0].bulletPrefab, 1);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "DamageUp")
        {
            //_powerupSound.PlayBulletPowerupClip();
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
        else if (collision.transform.tag == "HomingMissilePowerUp")
        {
            Debug.Log("Homing Missile Power Up");

            //_powerupSound.PlayHomingMissileClip();
            Destroy(collision.transform.gameObject);
            isHomingMissileActive = true;
            //iconManager.ShowIcon(0);
            turret.turretData = turretDatas[2];
            foreach (Transform barrel in barrels)
            {
                turret.turretBarrels.Add(barrel);
            }
            objectPool.DestroyBullets();
            objectPool.Initialize(turret.turretData.bulletPrefab, 10);
        }
    }

}
