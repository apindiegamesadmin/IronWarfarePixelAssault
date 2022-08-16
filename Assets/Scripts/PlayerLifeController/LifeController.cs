using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeController : MonoBehaviour
{
    public TankController tankController;
    [SerializeField] Damagable playerDamagable;
    [SerializeField] int lifeCounter = 3;
    public TextMeshProUGUI lifeCounterTMPro;
    public DestroyUtil playerDestroyUtil;
    bool isDead;

    // Start is called before the first frame update
    void Awake()
    {
        playerDestroyUtil = GetComponent<DestroyUtil>();
        lifeCounterTMPro.text = lifeCounter.ToString();
        playerDamagable = GameObject.Find("Tank").GetComponent<Damagable>();
    }

    void Start()
    {
        tankController = GameObject.Find("Tank").GetComponent<TankController>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDamagable.Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (lifeCounter == 0)
        {
            PlayerDie();
        }

        while (lifeCounter > 0)
        {
            lifeCounter -= 1;
            lifeCounterTMPro.text = lifeCounter.ToString();
        }
    }

    public void PlayerDie()
    {
        isDead = true;
        Debug.Log("Player is dead.");
    }
}
