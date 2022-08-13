using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public TankController tankController;
    [SerializeField] Damagable playerDamagable;
    [SerializeField] int lifeCounter = 3;
    public Sprite[] sprites;
    Image heartImage;
    bool isDead;

    // Start is called before the first frame update
    void Awake()
    {
        playerDamagable = GameObject.Find("Tank").GetComponent<Damagable>();
        heartImage = GetComponent<Image>();
    }

    void Start()
    {
        tankController = GameObject.Find("Tank").GetComponent<TankController>();
        // sprites[lifeCounter - 1].SetActive(true);
        heartImage.sprite = sprites[lifeCounter - 1];
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

        while (lifeCounter != 0)
        {
            // sprites[lifeCounter - 1].SetActive(false);
            lifeCounter -= 1;
            heartImage.sprite = sprites[lifeCounter - 1];
            // sprites[lifeCounter - 1].SetActive(true);
        }
    }

    public void PlayerDie()
    {
        tankController.enabled = false;
        isDead = true;
        Debug.Log("Player is dead.");
    }
}
