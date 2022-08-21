using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airdrop : MonoBehaviour
{
    [SerializeField] Transform shadow;
    [SerializeField] GameObject[] powerUps;
    [SerializeField]float speed = 1f;
    void Start()
    {
        StartCoroutine(randomDirection());
    }

    IEnumerator randomDirection()
    {
        float posX = Random.Range(2, 10f);// Randomize X postion
        float posY = Random.Range(2, 10f);// Randomize Y postion

        int randomValue = Random.Range(0, 4);// Randomize destination postion
        Vector2 targetPos = Vector2.zero;
        switch (randomValue)
        {
            case 0:
                targetPos = new Vector2(transform.position.x + posX, transform.position.y + posY);
                break;
            case 1:
                targetPos = new Vector2(transform.position.x - posX, transform.position.y + posY);
                break;
            case 2:
                targetPos = new Vector2(transform.position.x + posX, transform.position.y - posY);
                break;
            case 3:
                targetPos = new Vector2(transform.position.x - posX, transform.position.y - posY);
                break;
        }

        float playerDistance = Vector2.Distance(transform.position, targetPos);// Get the distance
        float distance = playerDistance;// Store the origianl distance
        while (playerDistance > 0)
        {
            playerDistance = Vector2.Distance(transform.position, targetPos);// Get the current distance
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);//Move to the destination

            float scale = Mathf.Lerp(0.5f, 1, Mathf.InverseLerp(0, distance, playerDistance));// Calculate original distance & current distance
            transform.localScale = new Vector2(scale, scale);// Decrease the scale of the airdrop

            float shadowScale = Mathf.Lerp(1, 0, Mathf.InverseLerp(0, distance, playerDistance));// Calculate original distance & current distance
            shadow.localScale = new Vector2(shadowScale, shadowScale);// Increase the scale of the shadow
            float Ypos = Mathf.Lerp(0, 3, Mathf.InverseLerp(0, distance, playerDistance)); // Change the position of the shadow
            shadow.localPosition = new Vector2(0, -Ypos);

            yield return null;
        }

        int randomIndex1 = Random.Range(0, powerUps.Length);// Spawn random powerup when arrived to the destination
        GameObject powerUp1 = Instantiate(powerUps[randomIndex1], transform.position, Quaternion.identity);

        powerUp1.GetComponent<PowerUpIcon>().airDrop = true; // Destroy the spawned powerup after 20s
        Destroy(this.gameObject);// Destroy the airdrop
    }
}
