using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    Damagable damagable;
    Transform player;
    GameObject[] enemies;
    bool targetChanged = true;
    public GameObject enemy;
    float nearestEnemyDistance;
    public int enemyCounter = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (enemies == null)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
        enemy = enemies[0];
        damagable = enemy.GetComponent<Damagable>();
        gameObject.transform.SetParent(enemy.transform);
    }

    void Start()
    {
        nearestEnemyDistance = float.MaxValue;               // Vector2.Distance(player.position, enemy.transform.position);
    }

    void Update()
    {
        // if first target enemy is dead, then change target to nearest enemy
        if (damagable.Health < 10)
        {
            ChangeTarget();
            Debug.Log("Damage to enemy");
        }
    }

    // To find the nearest enemy from player
    public void FindNearestEnemy()
    {
        foreach (GameObject _enemy in enemies)
        {
            float distanceBetweenPlayerAndEnemy = Vector2.Distance(player.position, _enemy.transform.position);

            if (distanceBetweenPlayerAndEnemy < nearestEnemyDistance)
            {
                nearestEnemyDistance = distanceBetweenPlayerAndEnemy;
                enemy = _enemy;
                gameObject.transform.SetParent(enemy.transform);
            }
        }
    }

    // Afteh the target enemy is dead, change the target to another enemy
    public void ChangeTarget()
    {
        if (targetChanged)
        {
            enemy = enemies[++enemyCounter];
            targetChanged = false;
            float distanceBetweenPlayerAndEnemy = Vector2.Distance(player.position, enemy.transform.position);
            if ((enemy.transform.parent.name == "GunSoldiers" || enemy.transform.parent.name == "RPGSoldiers"))
            {
                return;
            }
            else
            {
                gameObject.transform.SetParent(enemy.transform);
                Debug.Log(enemy.transform.parent.name);
            }
        }
    }
}
