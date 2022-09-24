using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour
{
    [SerializeField] Sprite[] crateSprites;
    [SerializeField] float randomXValue = 1f;
    [SerializeField] float randomForceValue = 100f;

    BodyPartsSpawner partsSpawner;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    CrateSound crateSound;

    void Awake()
    {
        partsSpawner = GetComponent<BodyPartsSpawner>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        crateSound = FindObjectOfType<CrateSound>();
    }

    private void Start()
    {
        if (crateSprites.Length > 0)
        {
            int index = Random.Range(0, crateSprites.Length);// Randomize sprite
            spriteRenderer.sprite = crateSprites[index];
        }

        int randomIndex = Random.Range(0, 4);// Randomize rotation
        switch (randomIndex)
        {
            case 0:
                transform.Rotate(Vector3.zero);
                break;
            case 1:
                transform.Rotate(0, 0, 90);
                break;
            case 2:
                transform.Rotate(0, 0, 180);
                break;
            case 3:
                transform.Rotate(0, 0, -90);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            partsSpawner.SpawnBodyParts(collision.GetComponent<Bullet>().direction, collision.transform.position);
            crateSound.PlayCrateSound();
            Destroy(this.gameObject);
        }
        else if (collision.tag == "HomingMissile")
        {
            partsSpawner.SpawnBodyParts(collision.GetComponent<NewHomingMissile>().direction, collision.transform.position);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "MachineGunBullet")
        {
            AddForce(collision.GetComponent<Bullet>().direction, collision.transform.position);
            //StartCoroutine(StopSimulate());
        }
        else
        {
            Debug.Log(collision.name);
            //StartCoroutine(StopSimulate());
        }
    }

    void AddForce(Vector2 dir, Vector2 pos)
    {
        float randomValue = Random.Range(0f, randomXValue);
        //float randomForce = Random.Range(10f, randomForceValue);
        rb.AddForceAtPosition((new Vector2(dir.x - randomValue, dir.y - randomValue)) * randomForceValue, pos);
    }

    IEnumerator StopSimulate()
    {
        yield return new WaitForSeconds(0.5f);
        rb.simulated = false;
        //rb.simulated = true;
    }
}
