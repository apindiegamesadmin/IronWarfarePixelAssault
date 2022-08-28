using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class TankMachineGun : MonoBehaviour
{
    #region Variables

    public List<Transform> turretBarrels;
    public TurretData turretData;

    public bool canShoot;
    bool fire;

    float timer;
    Animator animator;

    AudioSource machineGunSFX;
    Collider2D[] tankColliders;

    ObjectPool bulletPool;
    [SerializeField]
    public int bulletPoolCount = 10;
    #endregion

    private void Awake()
    {
        machineGunSFX = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        tankColliders = GetComponentsInParent<Collider2D>();
        bulletPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        bulletPool.Initialize(turretData.bulletPrefab, bulletPoolCount);
    }

    public void ResetMachineGun()
    {
        fire = false;
        animator.SetBool("IsShooting", false);
        machineGunSFX.Stop();
    }

    void Update()
    {
        if (!canShoot)
            return;

        if (Input.GetMouseButtonDown(1))
        {
            fire = true;
            animator.SetBool("IsShooting", true);
            machineGunSFX.Play();
        }

        else if (Input.GetMouseButtonUp(1))
        {
            fire = false;
            animator.SetBool("IsShooting", false);
            machineGunSFX.Stop();
        }

        if (fire)
        {
            timer += Time.deltaTime;
            if (timer >= 0.2f)
            {
                timer = 0.0f;

                foreach (var barrel in turretBarrels)
                {
                    var hit = Physics2D.Raycast(barrel.position, barrel.up);

                    GameObject bullet = bulletPool.CreateObject();
                    bullet.transform.position = barrel.position;
                    bullet.transform.localRotation = barrel.rotation;
                    bullet.GetComponent<Bullet>().Initialize(turretData.bulletData);
                    bullet.GetComponent<Bullet>().direction = barrel.up;

                    foreach (var collider in tankColliders)
                    {
                        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                    }

                }
            }
        }
    }
}