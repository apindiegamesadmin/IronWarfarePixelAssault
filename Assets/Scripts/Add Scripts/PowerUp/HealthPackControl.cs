using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackControl : MonoBehaviour
{
    PowerupSound _powerupSound;
    [SerializeField] int hpPoint;
    Damagable playerDamagable;
    public bool tutorial;
    PlayerTankController playerTankController;

    void Awake()
    {
        _powerupSound = FindObjectOfType<PowerupSound>();
        playerTankController = GetComponentInParent<PlayerTankController>();
    }

    void Start()
    {
        playerDamagable = GetComponent<Damagable>();
    }


    void HealPlayer()
    {
        // if(hpPoint + playerDamagable.Health > playerDamagable.MaxHealth)
        // {
        //     if (playerTankController.CanIncreasePlayerLife())
        //     {
        //         int healPoint = (hpPoint + playerDamagable.Health) - playerDamagable.MaxHealth;
        //         playerDamagable.Health = healPoint;

        //         Debug.Log("Heart Increased");
        //         Debug.Log("Heal Points is " + healPoint);
        //     }
        //     else
        //     {
        //         playerDamagable.Heal(hpPoint);
        //     }
        // }
        // else
        // {
        //     playerDamagable.Heal(hpPoint);
        // }

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
