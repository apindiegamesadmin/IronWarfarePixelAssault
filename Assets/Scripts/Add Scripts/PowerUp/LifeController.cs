using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    PlayerTankController playerTankController;
    PowerupSound powerupSound;

    private void Awake()
    {
        playerTankController = GetComponentInParent<PlayerTankController>();
        powerupSound = FindObjectOfType<PowerupSound>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "LifePowerUp")
        {
            powerupSound.PlayLifePowerUpClip();
            playerTankController.CanIncreasePlayerLife();
            Destroy(collision.transform.gameObject);
        }
    }
}
