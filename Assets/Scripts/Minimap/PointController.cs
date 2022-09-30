using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] GameObject staticEnemies;
    [SerializeField] GameObject patrolEnemies;
    [SerializeField] GameObject redot;
    public List<GameObject> enemies;

    public GameObject enemy;
    Transform player;

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

    private void FixedUpdate()
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
        float nearestEnemyDistance = float.MaxValue;

        for (int i = 0; i < enemies.Count; i++)
        {
            float distance = Vector2.Distance(player.position, enemies[i].transform.position);

            if (nearestEnemyDistance > distance)
            {
                nearestEnemyDistance = distance;
                enemy = enemies[i].gameObject;
            }
        }

        redot.GetComponent<StayInside>().tank = enemy.transform;
        /*GameObject redDot = Instantiate(redotPrefab, transform.position, Quaternion.identity);
        redDot.transform.SetParent(enemy.transform);*/
    }
}
