using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissleController : MonoBehaviour
{
    public BulletData bulletData;
    public Turret turret;
    public TurretData turretData;
    public Transform[] barrels;
    private bool _isHomingMissleActive = false;

    private void Awake()
    {
        if (turret == null)
        {
            turret = GetComponentInChildren<Turret>();
        }
        if (turretData == null)
        {
            turretData = GetComponentInChildren<TurretData>();
        }
    }

    void Update()
    {
        if (_isHomingMissleActive)
        {
            Debug.Log("Homing Missle is active...");
            TriggerHomingMissle();
        }
        else
        {
            Debug.Log("Homing Missle is not active");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "HomingMissle")
        {
            Destroy(other.gameObject);
            _isHomingMissleActive = true;
        }
    }

    void TriggerHomingMissle()
    {
        Debug.Log("blah blah");
    }
}
