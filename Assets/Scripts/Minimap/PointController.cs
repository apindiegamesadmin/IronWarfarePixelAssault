using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    Transform player;
    public GameObject minimapIconPrefab;
    GameObject[] enemies;
    GameObject enemy;
    float nearestEnemyDistance;
    int enemyCounter = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (enemies == null)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }

        enemy = null;
    }

    void Start()
    {
        enemy = enemies[enemyCounter];
        nearestEnemyDistance = Vector2.Distance(player.position, enemy.transform.position);
    }

    void FixedUpdate()
    {
        // if first target enemy is dead, then change target to nearest enemy
        if (enemy == null)
        {
            FindNearestEnemy();
        }
    }

    // To find the nearest enemy from player
    public void FindNearestEnemy()
    {
        foreach (GameObject _enemy in enemies)
        {
            float distanceBetweenPlayerAndEnemy = Vector2.Distance(player.position, _enemy.transform.position);

            if (distanceBetweenPlayerAndEnemy <= nearestEnemyDistance)
            {
                nearestEnemyDistance = distanceBetweenPlayerAndEnemy;
                enemy = _enemy;
            }
        }
    }
}
