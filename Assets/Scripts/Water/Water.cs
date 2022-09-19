using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] int damage = 10;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Hit player");
            collider.GetComponentInChildren<Damagable>().Health -= damage;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Damage to player");
            other.GetComponentInChildren<Damagable>().Health -= damage;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("on collision");
            other.gameObject.GetComponentInChildren<Damagable>().Health -= damage;
        }
    }
}
