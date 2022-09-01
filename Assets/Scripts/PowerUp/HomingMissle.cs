using UnityEngine;
using UnityEngine.Events;

public class HomingMissle : MonoBehaviour
{
    public BulletData bulletData;
    [SerializeField] string targetTag;

    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody2D rb2d;
    public Vector2 direction;

    private float _rotateSpeed = 360f;
    [SerializeField] Transform target;
    [SerializeField] float range;
    Damagable enemyDamagable;

    public UnityEvent OnHit = new UnityEvent();

    AIDetector _aiDetector;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _aiDetector = GetComponent<AIDetector>();
    }

    private void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance >= bulletData.maxDistance)
        {
            DisableObject();
        }
        else
        {
            TriggerHomingMissle();
        }
    }

    public void TriggerHomingMissle()
    {

        if (_aiDetector.TargetVisible)
        {
            enemyDamagable = _aiDetector.Target.GetComponent<Damagable>();
            target = _aiDetector.Target.transform;
            Vector2 direction = (Vector2)target.transform.position - rb2d.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb2d.angularVelocity = -rotateAmount * _rotateSpeed;
            rb2d.velocity = transform.up * bulletData.speed;
        }
        else
        {
            rb2d.velocity = transform.up * this.bulletData.speed;
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

    // To draw Gizmoz lines in scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
