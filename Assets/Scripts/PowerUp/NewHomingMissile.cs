using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewHomingMissile : MonoBehaviour
{
    public BulletData bulletData;
    [SerializeField] string targetTag;
    public Vector2 direction;

    GameObject enemy;
    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private float _rotateSpeed = 360f;

    public UnityEvent OnHit = new UnityEvent();

    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        FindClosestEnemy();
    }

    private void Update()
    {
        if(enemy == null)
        {
            //enemy = FindClosestEnemy();
            rb2d.velocity = transform.up * bulletData.speed;
        }
        else
        {
            MoveTowardsEnemy();
        }

        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance >= bulletData.maxDistance)
        {
            DisableObject();
        }
    }

    void MoveTowardsEnemy()
    {
        Vector2 direction = (Vector2)enemy.transform.position - rb2d.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb2d.angularVelocity = -rotateAmount * _rotateSpeed;
        rb2d.velocity = transform.up * bulletData.speed;
    }

    GameObject FindClosestEnemy()
    {
        try
        {
            GameObject[] enemies;
            enemies = GameObject.FindGameObjectsWithTag(targetTag);

            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach( GameObject enemy in enemies)
            {
                Vector3 diff = enemy.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if(curDistance < distance)
                {
                    closest = enemy;
                    distance = curDistance;
                }
            }
            if(distance > 5.0f)
            {
                return null;
            }
            else
            {
                return closest;
            }
        }
        catch
        {
            return null;
        }
    }

    public void Initialize(BulletData bulletData)
    {
        this.bulletData = bulletData;
        startPosition = transform.position;
        rb2d.velocity = transform.up * this.bulletData.speed;
    }

    private void DisableObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);
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
