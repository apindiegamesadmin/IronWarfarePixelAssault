using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] bodyPartsPrefabs;
    float dirX;
    float dirY;
    float torque;
    Rigidbody2D rb;
    void Start()
    {

    }

    public void SpawnBodyParts()
    {
        for (int i = 0; i < bodyPartsPrefabs.Length; i++)
        {
            dirX = Random.Range(-1f, 1f);
            dirY = Random.Range(0, 1f);
            torque = Random.Range(5, 15);
            GameObject bodyPart = Instantiate(bodyPartsPrefabs[i],transform.position,Quaternion.identity);
            rb = bodyPart.GetComponent<Rigidbody2D>();

            rb.AddForce(new Vector2(dirX, dirY), ForceMode2D.Impulse);

            StartCoroutine(StopSimulating(rb));
            rb.AddTorque(torque, ForceMode2D.Force);
        }
    }

    IEnumerator StopSimulating(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(1);
        rb.simulated = false;
        Destroy(rb.gameObject);
    }
}
