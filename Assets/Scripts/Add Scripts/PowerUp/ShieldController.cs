using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] int duration;
    [SerializeField] int shieldPoint;
    [SerializeField] GameObject shieldPrefab;
    Damagable playerDamagable;
    [SerializeField] GameObject shieldIcon;
    public bool tutorial;

    float skillTimer;
    bool shield;
    GameObject shieldObj;
    void Start()
    {
        playerDamagable = GetComponent<Damagable>();
        shieldIcon.SetActive(false);
    }

    private void Update()
    {
        if (shield)
        {
            if (Time.time > skillTimer)
            {
                Destroy(shieldObj);
                shieldIcon.SetActive(false);
                shield = false;
                playerDamagable.shield = false;
            }
        }
    }

    void ShieldPlayer()
    {
        shieldIcon.SetActive(true);
        shield = true;
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
            if (!shield)
            {
                ShieldPlayer();
                Destroy(collision.transform.gameObject);
            }
            else
            {
                skillTimer += duration;
                Destroy(collision.transform.gameObject);
            }
        }
    }
}
