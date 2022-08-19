using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackControl : MonoBehaviour
{
    [SerializeField] int hpPoint;
    Damagable playerDamagable;
    public bool tutorial;
    void Start()
    {
        playerDamagable = GetComponent<Damagable>();
    }

    
    void HealPlayer()
    {
        playerDamagable.Heal(hpPoint);
        if (tutorial)
        {
            tutorial = false;
            FindObjectOfType<TutorialManager>().completeStep = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "HealthPack")
        {
            HealPlayer();
            Destroy(collision.transform.gameObject);
        }
    }
}
