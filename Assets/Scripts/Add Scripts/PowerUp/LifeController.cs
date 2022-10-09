using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    PlayerTankController playerTankController;

    private void Awake()
    {
        playerTankController = GetComponentInParent<PlayerTankController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "LifePowerUp")
        {
            playerTankController.CanIncreasePlayerLife();
            Destroy(collision.transform.gameObject);
        }
    }
}
