using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] float timeToSpawn;
    [SerializeField] float timeBetweenWaves;
    [SerializeField] GameObject planePrefab;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip planeSound;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (Time.time > timeToSpawn)
        {
            SpawnPlane();
            ResetTimeToSpawn();
        }
    }

    public void ResetTimeToSpawn()
    {
        timeToSpawn = Time.time + timeBetweenWaves;
    }

    void SpawnPlane()
    {
        PlaneSound();
        GameObject plane = Instantiate(planePrefab, playerTransform.position, Quaternion.identity);//Spawn plane
        plane.transform.SetParent(this.transform);

        int randomIndex = Random.Range(-90, 180);// Randomize plane's rotation
        plane.transform.Rotate(0, 0, randomIndex);
    }

    public void PlaneSound()
    {
        audioSource.PlayOneShot(planeSound);
    }
}
