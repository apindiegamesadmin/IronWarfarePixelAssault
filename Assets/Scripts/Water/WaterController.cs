using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    Damagable damagable;
    [SerializeField] int damage = 10;

    private void Awake()
    {
        damagable = transform.GetComponent<Damagable>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        Debug.Log("on trigger enter");
        if (collider2D.transform.tag == "Water")
        {
            Debug.Log("Damage to player");
            damagable.Health -= damage;
        }
    }
}
