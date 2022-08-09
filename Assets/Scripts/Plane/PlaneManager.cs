using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float timeToSpawn;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] GameObject planePrefab;
    void Start()
    {
        
    }


    void Update()
    {
        if(Time.time > timeToSpawn)
        {
            SpawnPlane();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }

    void SpawnPlane()
    {
        GameObject plane = Instantiate(planePrefab, playerTransform.position,Quaternion.identity);
        plane.transform.SetParent(this.transform);

        int randomIndex = Random.Range(-90, 180);
        plane.transform.Rotate(0,0,randomIndex);
    }
}
