using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    PowerupSound _powerupSound;
    [SerializeField] int duration;
    [SerializeField] int shieldPoint;
    [SerializeField] GameObject shieldPrefab;
    Damagable playerDamagable;
    public bool tutorial;

    float skillTimer;
    bool shield;
    GameObject shieldObj;
    PowerUpIconManager iconManager;


    void Awake()
    {
        iconManager = FindObjectOfType<PowerUpIconManager>();
        _powerupSound = FindObjectOfType<PowerupSound>();
        playerDamagable = GetComponent<Damagable>();
    }

    private void Update()
    {
        if (shield)
        {
            if (Time.time > skillTimer || playerDamagable.shieldPoint <= 0)
            {
                Destroy(shieldObj);
                iconManager.HideIcon(2);
                shield = false;
                playerDamagable.shield = false;
            }
        }
    }

    void ShieldPlayer()
    {
        shield = true;
        iconManager.ShowIcon(2);

        skillTimer = Time.time + duration;
        shieldObj = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
        shieldObj.transform.SetParent(transform);

        playerDamagable.shield = true;
        playerDamagable.shieldPoint = shieldPoint;

        if (tutorial)
        {
            tutorial = false;
            FindObjectOfType<TutorialManager>().completeStep = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Shield")
        {
            _powerupSound.PlayShieldPowerupClip();
            if (!shield)
            {
                ShieldPlayer();
                Destroy(collision.transform.gameObject);
            }
            else
            {
                skillTimer += duration;
                ShieldPlayer();
                Destroy(collision.transform.gameObject);
            }
        }
    }
}
