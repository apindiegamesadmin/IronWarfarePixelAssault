using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    Damagable damagable;
    [SerializeField] int damage = 1;

    private void Awake()
    {
        damagable = GetComponent<Damagable>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Water")
        {
            damagable.Hit(damage);
        }
    }
}
