using UnityEngine;
using UnityEngine.Events;

public class TankMachineGun : MonoBehaviour
{
    #region Variables
    public AudioSource machineGunSFX;
    public Transform barrel;
    public bool canShoot;
    public bool fire;
    public Rigidbody2D bullet;
    private float timer;
    public Animator animator;
    public BulletData BulletData;
    public Damagable damagable;
    public UnityEvent OnShoot;
    #endregion

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
                Rigidbody2D newBullet = Instantiate(bullet);
                newBullet.transform.position = barrel.position;
                newBullet.transform.localRotation = barrel.rotation;
                newBullet.AddForce(barrel.up * 100, ForceMode2D.Force);
                newBullet.GetComponent<Bullet>().Initialize(BulletData);
            }
        }
    }
}