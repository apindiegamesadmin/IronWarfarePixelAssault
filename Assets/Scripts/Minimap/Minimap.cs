using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    Transform point;
    Transform _player;
    Transform _target;
    float minimapSize = 5f;

    void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Enemy").transform;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void LateUpdate()
    {
        Vector3 newPosition = _player.position;
        newPosition.z = transform.position.z;
        transform.position = newPosition;

        // Center of Minimap
        Vector2 _centerPosition = transform.localPosition;

        // Distance from the gameobject to minimap
        float distance = Vector2.Distance(_target.position, _centerPosition);

        // If the Distance is less than MinimapSize, it is within the Minimap view and we don't need to do anything
        // But if the Distance is greater than the MinimapSize, then do this
        if (distance > minimapSize)
        {
            // Target - Minimap
            Vector2 fromOriginToObject = (Vector2)_target.position - _centerPosition;

            // Multiply by MinimapSize and Divide by Distance
            fromOriginToObject *= minimapSize / distance;

            // Minimap + above calculation
            transform.position = _centerPosition + fromOriginToObject;
        }
    }
}
