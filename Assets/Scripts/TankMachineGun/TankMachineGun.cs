using UnityEngine;

public class TankMachineGun : MonoBehaviour
{
    public AudioSource machineGunSFX;
    public Transform barrel;
    public bool fire;
    public Rigidbody2D bullet;
    private float timer;

    public BulletData BulletData;
    public Damagable damagable;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            fire = true;
            machineGunSFX.Play();
        }

        else if (Input.GetMouseButtonUp(1))
        {
            fire = false;
            machineGunSFX.Stop();
        }

        if (fire)
        {
            //Rigidbody2D newBullet = Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);
            //newBullet.AddForce(gunPoint.transform.forward * 1000, ForceMode2D.Impulse);

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