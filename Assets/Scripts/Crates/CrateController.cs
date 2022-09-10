using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    BodyPartsSpawner partsSpawner;
    // Start is called before the first frame update
    void Awake()
    {
        partsSpawner = GetComponent<BodyPartsSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            partsSpawner.SpawnBodyParts(collision.GetComponent<Bullet>().direction, collision.transform.position);
            Destroy(this.gameObject);
        }
    }
}
