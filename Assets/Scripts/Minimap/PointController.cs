using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    Damagable damagable;
    Transform player;
    public GameObject[] enemies;
    public float[] distanceBetweenPlayerAndEnemies;
    bool targetChanged = true;
    public GameObject enemy;
    float nearestEnemyDistance;
    public int enemyCounter = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;


        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        distanceBetweenPlayerAndEnemies = new float[enemies.Length];
    }

    private void Start()
    {
        FindNearestEnemy();
    }

    void Update()
    {
        // Before enemy dead, change another target
        if (damagable.Health <= (damagable.Health) / 2)
        {
            ChangeTarget();
        }
    }

    // To find the nearest enemy from player
    public void FindNearestEnemy()
    {
        for (int i = 0; i <= enemies.Length; i++)
        {
            distanceBetweenPlayerAndEnemies[i] = Vector2.Distance(player.position, enemies[i].transform.position);
            nearestEnemyDistance = float.MaxValue;

            if (distanceBetweenPlayerAndEnemies[i] < nearestEnemyDistance)
            {
                nearestEnemyDistance = distanceBetweenPlayerAndEnemies[i];
                enemy = enemies[i];
            }
        }
        damagable = enemy.GetComponent<Damagable>();
        gameObject.transform.parent = enemy.transform;
    }

    // Afteh the target enemy is dead, change the target to another enemy
    public void ChangeTarget()
    {
        if (targetChanged)
        {
            enemy = enemies[++enemyCounter];
            targetChanged = false;
            FindNearestEnemy();
        }
    }
}
