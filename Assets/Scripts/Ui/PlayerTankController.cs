using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerTankController : MonoBehaviour
{
    [SerializeField] Color heartColor;
    [SerializeField] UnityEvent OnDead;
    [SerializeField] UnityEvent OnContinue;
    Damagable damagable;
    Transform heartHolder;
    bool isFirstTime = false;
    int lifeCount = 2;
    public Vector3 lastPosition;

    Image[] hearts;
    Animator animator;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        damagable = GetComponentInChildren<Damagable>();

        heartHolder = GameObject.FindGameObjectWithTag("Heart").transform;//Get the reference of heart holder
        hearts = heartHolder.GetComponentsInChildren<Image>();//Get image component of hearts
        foreach (var heart in hearts)
        {
            heart.color = heartColor;//Assign Color
        }
    }

    public void CheckPlayerLife()
    {
        if (lifeCount >= 1)
        {
            StartCoroutine(DelaySpawn()); // Spawn and play animation after 1 sec

            Debug.Log(lifeCount);
            lifeCount--; // Reduce life
            for (int i = 0; i < 3; i++)
            {
                if (i > lifeCount)
                {
                    heartHolder.GetChild(i).gameObject.SetActive(false); // Disable last active heart
                }
                else
                {
                    heartHolder.GetChild(i).gameObject.SetActive(true); // Enable remaining hearts
                }
            }
        }
        else
        {
            heartHolder.GetChild(0).gameObject.SetActive(false); // Disable last active heart

            Time.timeScale = 0;
            OnDead.Invoke();
            // to know the player's last position before dead
            lastPosition = transform.position;
        }
    }

    public bool CanIncreasePlayerLife()
    {
        if (lifeCount < 2)
        {
            Debug.Log(lifeCount);
            lifeCount++;
            for (int i = 0; i < 3; i++)
            {
                if (i > lifeCount)
                {
                    heartHolder.GetChild(i).gameObject.SetActive(false); // Disable last active heart
                }
                else
                {
                    heartHolder.GetChild(i).gameObject.SetActive(true); // Enable remaining hearts
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator DelaySpawn()
    {
        damagable.Health = damagable.MaxHealth;
        yield return new WaitForSeconds(1);
        transform.GetChild(0).gameObject.SetActive(true);   // Enable player and
        animator.SetTrigger("Flick");        // play flicker animation
        damagable.enabled = false;
        yield return new WaitForSeconds(6);
        damagable.enabled = true;
    }

    public void ContinuePlayWithAd()
    {
        if (!isFirstTime)
        {
            CanIncreasePlayerLife();
            Time.timeScale = 1f;
            isFirstTime = true;
            OnContinue.Invoke();
        }
    }
}
