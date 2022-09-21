using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] GameObject staticEnemies;
    [SerializeField] GameObject patrolEnemies;
    [SerializeField] GameObject redotPrefab;
    public List<GameObject> enemies;
    public int tankID;

    public GameObject enemy;
    Transform player;
    float nearestEnemyDistance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        foreach (Transform enemy in staticEnemies.transform)
        {
            enemies.Add(enemy.GetChild(0).gameObject);
        }
        foreach (Transform enemy in patrolEnemies.transform)
        {
            enemies.Add(enemy.GetChild(0).gameObject);
        }
    }

    private void Start()
    {
        FindNearestEnemy();
    }

    public void ChangeTarget(GameObject currentEnemy)
    {
        enemies.Remove(currentEnemy);
        FindNearestEnemy();
    }

    // To find the nearest enemy from player
    public void FindNearestEnemy()
    {
        nearestEnemyDistance = float.MaxValue;

        for (int i = 0; i < enemies.Count; i++)
        {
            float distance = Vector2.Distance(player.position, enemies[i].transform.position);

            if (nearestEnemyDistance > distance)
            {
                nearestEnemyDistance = distance;
                enemy = enemies[i].gameObject;
                if (enemy == staticEnemies)
                {
                    tankID = 0;
                }
                else if (enemy == patrolEnemies)
                {
                    tankID = 1;
                }
                else
                {
                    tankID = 2;
                }
            }
        }

        GameObject redDot = Instantiate(redotPrefab, transform.position, Quaternion.identity);
        redDot.transform.SetParent(enemy.transform);
    }
}
