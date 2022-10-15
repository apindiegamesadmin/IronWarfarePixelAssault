using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpControl : MonoBehaviour
{
    PowerupSound _powerupSound;
    // public TankMover tankmovement;
    public PlayerMovement playerMovement;
    public TankMovementData movementData;
    public TankMovementData[] tankMovementDatas;
    public float duration = 10f;
    float timer;
    public static bool speedUp;
    public bool tutorial;

    PowerUpIconManager iconManager;

    void Awake()
    {
        iconManager = FindObjectOfType<PowerUpIconManager>();
        _powerupSound = FindObjectOfType<PowerupSound>();

        // if (tankmovement == null)
        //     tankmovement = GetComponentInChildren<TankMover>();

        if (playerMovement == null)
            playerMovement = GetComponent<PlayerMovement>();


        if (tankMovementDatas == null || tankMovementDatas.Length == 0)
            tankMovementDatas = GetComponents<TankMovementData>();
    }


    void Update()
    {
        if (speedUp)
        {
            timer += Time.deltaTime;
            if (timer > duration)
            {
                speedUp = false;
                iconManager.HideIcon(1);
                playerMovement.movementData = tankMovementDatas[0];
                timer = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "SpeedUp")
        {
            _powerupSound.PlaySpeedUpClip();
            Destroy(collision.transform.gameObject);

            speedUp = true;
            playerMovement.movementData = tankMovementDatas[1];
            iconManager.ShowIcon(1);

            if (tutorial)
            {
                tutorial = false;
                FindObjectOfType<TutorialManager>().completeStep = true;
            }
        }
    }
}
