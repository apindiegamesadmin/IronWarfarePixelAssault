using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airdrop : MonoBehaviour
{
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
        Debug.Log(targetPos);
        float playerDistance = Vector2.Distance(transform.position, targetPos);
        while (playerDistance > 0)
        {
            playerDistance = Vector2.Distance(transform.position, targetPos);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if(transform.localScale.x > 0.5f)
            {
                transform.localScale = new Vector2(transform.localScale.x - 0.001f, transform.localScale.y - 0.001f);
            }
            yield return null;
        }
        int randomIndex = Random.Range(0, powerUps.Length);
        GameObject powerUp = Instantiate(powerUps[randomIndex],transform.position,Quaternion.identity);
        powerUp.GetComponent<PowerUpIcon>().airDrop = true;
        Destroy(this.gameObject);
    }
}
