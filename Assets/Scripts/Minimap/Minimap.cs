using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    Transform point;
    Transform _player;
    public Transform _target;
    float _minimapSize = 5f;
    public GameObject redDot;
    public GameObject yellowDot;
    bool isFirstTime = true;
    bool isAgain = true;

    void Awake()
    {
        // _target = GameObject.FindGameObjectWithTag("Enemy").transform;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        redDot.SetActive(false);
    }

    public void LateUpdate()
    {
        Vector3 newPosition = _player.position;
        newPosition.z = transform.position.z;
        transform.position = newPosition;

        float distanceBetweenPlayerAndTarget = Vector2.Distance(_player.position, _target.position);

        if (_target != null)
        {
            if (distanceBetweenPlayerAndTarget > _minimapSize)
            {
                Debug.Log("The target is off the screen.");
                if (isFirstTime)
                {
                    isFirstTime = false;
                    // To spawn a red dot in minimap
                    Vector2 centerPosition = transform.localPosition;
                    Vector2 spawnPosition = new Vector2(centerPosition.x + 5, transform.position.y);
                    Instantiate(yellowDot, spawnPosition, Quaternion.identity);
                }
                else { redDot.SetActive(true); }
            }
            else
            {
                Debug.Log("The target is near to player");
                redDot.SetActive(false);
            }
        }
        else
        {
            Debug.Log("The target is dead.");
            redDot.SetActive(false);
        }

        // Calculate the angle between player and enemy
        // Vector2 direction = _target.position - _player.position;

        // float angle = Vector2.Angle(Vector2.right, direction);

        // Debug.Log("The angle between x and the enemy is " + angle);

        // // To spawn a red dot in minimap
        // Vector2 centerPosition = transform.localPosition;
        // Vector2 spawnPosition = new Vector2(centerPosition.x + 5, transform.position.y);
        // Instantiate(yellowDot, spawnPosition, Quaternion.identity);

        float xPosition = _target.position.x - _player.position.x;
        float yPosition = _target.position.y - _player.position.y;

        float angle = Mathf.Atan2(yPosition, xPosition) * Mathf.Rad2Deg;
        Debug.Log("The angle between x and the enemy is " + angle);
    }
}
