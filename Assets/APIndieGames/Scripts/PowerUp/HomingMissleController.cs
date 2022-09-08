using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissleController : MonoBehaviour
{
    Turret _turrent;
    [SerializeField] ObjectPool _objectPool;
    [SerializeField] TurretData _turretData;
    [SerializeField] GameObject bullet;
    float timer, duration = 5f;

    private void Awake()
    {
        _turrent = GetComponentInChildren<Turret>();
        // _objectPool = GetComponentInChildren<ObjectPool>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "HomingMissile")
        {
            Destroy(collision.transform.gameObject);
            _turrent.turretData = _turretData;
            _objectPool.Initialize(_turrent.turretData.bulletPrefab, 3);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
        {

        }
    }
}
