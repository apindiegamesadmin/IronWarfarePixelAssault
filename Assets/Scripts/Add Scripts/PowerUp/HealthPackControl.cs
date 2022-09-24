using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackControl : MonoBehaviour
{
    PowerupSound _powerupSound;
    [SerializeField] int hpPoint;
    Damagable playerDamagable;
    public bool tutorial;

    void Awake()
    {
        _powerupSound = FindObjectOfType<PowerupSound>();
    }

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
            _powerupSound.PlayHealthClip();
            HealPlayer();
            Destroy(collision.transform.gameObject);
        }
    }
}
