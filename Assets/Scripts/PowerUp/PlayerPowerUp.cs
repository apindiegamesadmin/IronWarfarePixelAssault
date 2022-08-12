using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public GameObject tripleShotPrefab;
    public GameObject tripleShotIcon;

    private Turret _turret;
    private Damagable _damagable;
    private TurretData _turretData;
    private ObjectPool _bulletPool;

    private void Awake()
    {
        if (_turret == null)
        {
            _turret = GetComponentInChildren<Turret>();
        }

        if (_turretData == null)
        {
            _turretData = GetComponentInChildren<TurretData>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "TripleShot")
        {
            // TripleShot Trigger
            TriggerTripleShot();
        }

        if (collision.transform.tag == "AOEPowerup")
        {
            // Large and powerful shot 
            TriggerPowerfulShot();
        }
    }

    void TriggerTripleShot()
    {

    }

    void TriggerPowerfulShot()
    {

    }
}
