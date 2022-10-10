using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    PowerupSound powerupSound;
    Turret turret;
    ObjectPool objectPool;
    public TurretData[] turretDatas;
    public Transform barrel;
    public Transform[] barrels;
    /*public Transform barrel_1;
    public Transform barrel_2;
    public Transform barrel_3;*/
    public float duration = 10f;
    float skillTimer;
    public bool damageUp;
    public bool tutorial;
    bool isHomingMissileActive;

    PowerUpIconManager iconManager;

    void Awake()
    {
        iconManager = FindObjectOfType<PowerUpIconManager>();
        powerupSound = FindObjectOfType<PowerupSound>();

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
                turret.turretBarrels.Clear();
                turret.turretBarrels.Add(barrel);

                /*turret.turretBarrels.Remove(barrel_1);
                turret.turretBarrels.Remove(barrel_2);
                turret.turretBarrels.Remove(barrel_3);*/

                turret.bulletPoolCount = 3;
            }
        }

        if (isHomingMissileActive)
        {
            skillTimer += Time.deltaTime;

            if (skillTimer >= duration)
            {
                isHomingMissileActive = false;
                skillTimer = 0;
                iconManager.HideIcon(3);

                turret.turretData = turretDatas[0];
                turret.turretBarrels.Clear();
                turret.turretBarrels.Add(barrel);

                objectPool.Initialize(turret.turretData.bulletPrefab, 3);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "DamageUp")
        {
            powerupSound.PlayBulletPowerupClip();
            Destroy(collision.transform.gameObject);
            damageUp = true;
            iconManager.ShowIcon(0);
            turret.turretData = turretDatas[1];

            turret.turretBarrels.Clear();
            foreach (Transform barrel in barrels)
            {
                 turret.turretBarrels.Add(barrel);
            }

            /*
            turret.turretBarrels.Add(barrel_1);
            turret.turretBarrels.Add(barrel_2);
            turret.turretBarrels.Add(barrel_3);
            */

            turret.bulletPoolCount = 3;

            if (tutorial)
            {
                tutorial = false;
                FindObjectOfType<TutorialManager>().completeStep = true;
            }
        }
        else if (collision.transform.tag == "HomingMissilePowerUp")
        {
            powerupSound.PlayHomingMissileClip();
            Destroy(collision.transform.gameObject);
            isHomingMissileActive = true;
            iconManager.ShowIcon(3);
            turret.turretData = turretDatas[2];
            turret.turretBarrels.Clear();
            foreach (Transform barrel in barrels)
            {
                turret.turretBarrels.Add(barrel);
            }

            objectPool.Initialize(turret.turretData.bulletPrefab, 10);
        }
    }

}
