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

    public UnityEvent OnHit = new UnityEvent();

    AIDetector _aiDetector;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _aiDetector = GetComponentInChildren<AIDetector>();
    }

    private void Update()
    {
        if (_aiDetector.TargetVisible)
        {
            float AngleRad = Mathf.Atan2(_aiDetector.Target.position.y - transform.position.y, _aiDetector.Target.position.x - transform.position.x);
            // Get Angle in Degrees
            float AngleDeg = (180 / Mathf.PI) * AngleRad;
            // Rotate Object
            this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

            transform.position = Vector2.MoveTowards(transform.position, _aiDetector.Target.position, 10 * Time.deltaTime);

            /*Vector2 direction = (Vector2)_aiDetector.Target.transform.position - rb2d.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb2d.angularVelocity = -rotateAmount * _rotateSpeed;*/
            //rb2d.velocity = transform.up * bulletData.speed;
        }
        else
        {
            rb2d.velocity = transform.up * this.bulletData.speed;
        }

        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance >= bulletData.maxDistance)
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
