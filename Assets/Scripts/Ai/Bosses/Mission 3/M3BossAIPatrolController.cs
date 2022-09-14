using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3BossAIPatrolController : MonoBehaviour
{
    [SerializeField] float timeToFly;
    [SerializeField] float timeBetweenFly;
    [SerializeField] Transform[] positions;
    [SerializeField] Transform shadow;
    Collider2D collision;
    [SerializeField] SpriteRenderer[] sprites;
    [SerializeField] float speed = 1f;

    bool flying;
    M3BossAI bossAI;
    void Awake()
    {
        bossAI = GetComponent<M3BossAI>();
        collision = GetComponentInChildren<Collider2D>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToFly && !flying)
        {
            flying = true;
            bossAI.flying = true;
            StartCoroutine(FlyToTargetPosition());
        }
    }

    IEnumerator FlyToTargetPosition()
    {
        collision.enabled = false;
        foreach(SpriteRenderer sprite in sprites)
        {
            sprite.sortingLayerName = "Detail_Top";
        }
        int randomIndex = Random.Range(0, positions.Length);

        float AngleRad = Mathf.Atan2(positions[randomIndex].position.y - transform.position.y, positions[randomIndex].position.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg + 90);

        float playerDistance = Vector2.Distance(transform.position, positions[randomIndex].position);
        while (playerDistance > 0)
        {
            playerDistance = Vector2.Distance(transform.position, positions[randomIndex].position);
            shadow.position = new Vector2(transform.position.x, transform.position.y - 1);
            transform.position = Vector2.MoveTowards(transform.position, positions[randomIndex].position, speed * Time.deltaTime);
            yield return null;
        }

        flying = false;
        collision.enabled = true;
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.sortingLayerName = "Enemy";
        }
        bossAI.flying = false;
        ResetTimeToSpawn();
    }

    public void ResetTimeToSpawn()
    {
        timeToFly = Time.time + timeBetweenFly;
    }


}
