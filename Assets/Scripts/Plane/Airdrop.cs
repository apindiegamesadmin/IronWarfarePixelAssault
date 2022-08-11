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
        float posX = Random.Range(2, 10f);
        float posY = Random.Range(2, 10f);
        int randomValue = Random.Range(0, 4);
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
        float playerDistance = Vector2.Distance(transform.position, targetPos);
        float distance = playerDistance;
        while (playerDistance > 0)
        {

            playerDistance = Vector2.Distance(transform.position, targetPos);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            float scale = Mathf.Lerp(0.5f, 1, Mathf.InverseLerp(0, distance, playerDistance));
            transform.localScale = new Vector2(scale, scale);
            float Ypos = Mathf.Lerp(0, 1, Mathf.InverseLerp(0, distance, playerDistance));
            shadow.localPosition = new Vector2(0, -Ypos);

            yield return null;
        }
        int randomIndex1 = Random.Range(0, powerUps.Length);
        GameObject powerUp1 = Instantiate(powerUps[randomIndex1], transform.position, Quaternion.identity);
        powerUp1.GetComponent<PowerUpIcon>().airDrop = true;
        Destroy(this.gameObject);
    }
}
