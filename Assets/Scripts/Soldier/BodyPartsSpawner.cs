using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] bodyPartsPrefabs;
    float torque;
    Rigidbody2D rb;
    void Start()
    {

    }

    public void SpawnBodyParts(Vector2 dir,Vector2 pos)
    {
        for (int i = 0; i < bodyPartsPrefabs.Length; i++)
        {
            GameObject bodyPart = Instantiate(bodyPartsPrefabs[i],transform.position,Quaternion.identity);
            rb = bodyPart.GetComponent<Rigidbody2D>();

            float randomValue = Random.Range(0f, 1f);
            rb.AddForceAtPosition((new Vector2(dir.x - randomValue,dir.y)) * 50f, pos);

            StartCoroutine(StopSimulating(rb));
            torque = Random.Range(5, 15);
            rb.AddTorque(torque, ForceMode2D.Force);
        }
    }

    IEnumerator StopSimulating(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(2);
        rb.simulated = false;
        Destroy(rb.gameObject);
    }
}
