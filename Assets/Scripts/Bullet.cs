using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;
    [SerializeField] string targetTag;

    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody2D rb2d;

    public UnityEvent OnHit = new UnityEvent();
    public Vector2 direction;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Initialize(BulletData bulletData)
    {
        this.bulletData = bulletData;
        startPosition = transform.position;
        rb2d.velocity = transform.up * this.bulletData.speed;
    }

    private void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance >= bulletData.maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHit?.Invoke();
        if (collision.transform.tag == targetTag)
        {
            var damagable = collision.GetComponent<Damagable>();
            if (damagable != null)
            {
                damagable.Hit(bulletData.damage);
            }
        }
        DisableObject();
    }
}
