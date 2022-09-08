using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    PowerupSound _powerupSound;
    Turret turret;
    ObjectPool objectPool;
    public TurretData turretData;
    public TurretData[] turretDatas;
    public Transform[] barrels;
    public float duration = 10f;
    float skillTimer;
    public bool damageUp;
    public bool tutorial;
    float timer;
    bool isHomingMissileActive;

    PowerUpIconManager iconManager;


    void Awake()
    {
        iconManager = FindObjectOfType<PowerUpIconManager>();
        _powerupSound = GameObject.Find("PowerupSound").GetComponent<PowerupSound>();

        if (turret == null)
            turret = GetComponentInChildren<Turret>();

        if (turretDatas == null || turretDatas.Length == 0)
            turretDatas = GetComponentsInChildren<TurretData>();

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
            timer += Time.deltaTime;

            if (timer >= duration)
            {
                isHomingMissileActive = false;
                turret.turretData = turretDatas[0];
                objectPool.Initialize(turretDatas[0].bulletPrefab, 10);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "DamageUp")
        {
            _powerupSound.PlayBulletPowerupClip();
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

        if (collision.transform.tag == "HomingMissile")
        {
            _powerupSound.PlayHomingMissileClip();
            Destroy(collision.transform.gameObject);
            isHomingMissileActive = true;
            turret.turretData = turretDatas[2];
            objectPool.Initialize(turret.turretData.bulletPrefab, 10);
        }
    }

}
