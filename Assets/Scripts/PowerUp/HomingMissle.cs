using UnityEngine;
using UnityEngine.Events;

public class HomingMissle : MonoBehaviour
{
    public BulletData bulletData;
    [SerializeField] string targetTag;
    public float duration = 4f;
    float timer = 0;

    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody2D rb2d;
    Vector2 previousPosition;
    public Vector2 direction;

    private float _rotateSpeed = 360f;

    public UnityEvent OnHit = new UnityEvent();

    AIDetector _aiDetector;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _aiDetector = GetComponentInChildren<AIDetector>();
    }

    private void OnEnable()
    {
        timer = 0;
    }

    private void FixedUpdate()
    {
        if ((Vector2)transform.position != previousPosition)
        {
            direction = ((Vector2)transform.position - previousPosition).normalized;
            previousPosition = transform.position;
        }

    }

    private void Update()
    {
        if (_aiDetector.TargetVisible && _aiDetector.Target != null)
        {
            Vector2 direction = (Vector2)_aiDetector.Target.transform.position - rb2d.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb2d.angularVelocity = -rotateAmount * _rotateSpeed;
            rb2d.velocity = transform.up * bulletData.speed;
        }
        else
        {
            rb2d.velocity = transform.up * bulletData.speed;
        }

        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        timer += Time.deltaTime;
        if (conquaredDistance >= bulletData.maxDistance || timer > duration)
        {
            DisableObject();
        }
    }

    public void Initialize(BulletData bulletData)
    {
        this.bulletData = bulletData;
        startPosition = transform.position;
        rb2d.velocity = transform.up * this.bulletData.speed;
        _aiDetector.Detection();
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
