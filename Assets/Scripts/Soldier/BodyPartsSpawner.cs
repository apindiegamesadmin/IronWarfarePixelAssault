using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsSpawner : MonoBehaviour
{
    [SerializeField] float randomXValue = 1f;
    [SerializeField] float randomForceValue = 100f;
    [SerializeField] GameObject[] bodyPartsPrefabs;

    public void SpawnBodyParts(Vector2 dir,Vector2 pos)
    {
        for (int i = 0; i < bodyPartsPrefabs.Length; i++)
        {
            GameObject bodyPart = Instantiate(bodyPartsPrefabs[i],transform.position,Quaternion.identity);
            Rigidbody2D rb = bodyPart.GetComponent<Rigidbody2D>();

            float randomValue = Random.Range(0f, randomXValue);
            float randomForce = Random.Range(50f, randomForceValue);
            rb.AddForceAtPosition((new Vector2(dir.x - randomValue,dir.y - randomValue)) * randomForce, pos);

            Destroy(bodyPart, 1f);
        }
    }
}
