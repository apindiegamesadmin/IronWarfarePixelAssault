using UnityEngine;
using UnityEngine.Events;

public class HomingMissle : MonoBehaviour
{
    public Rigidbody2D _rb;
    private float _rotateSpeed = 360f;
    private float _speed = 5f;
    public BulletData bulletData;
    private Vector2 _startPosition;
    private float _timer = 0f;
    public Transform target;
    [SerializeField] float range;
    public Damagable enemyDamagable;
    [SerializeField] string TARGET_TAG;

    public UnityEvent OnHit = new UnityEvent();

    AIDetector _aiDetector;

    // Start is called before the first frame update
    void Awake()
    {
        enemyDamagable = GameObject.FindWithTag("Enemy").GetComponent<Damagable>();
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        _aiDetector = transform.GetComponent<AIDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        TriggerHomingMissle();
        _timer += Time.deltaTime;
        if (_timer >= 5.0f)
        {
            _timer = 0f;
            DisableGameObject();
        }

    }

    public void TriggerHomingMissle()
    {
        // Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, range);

        // foreach (Collider2D collider in colliderArray)
        // {
        //     Debug.Log(collider.transform.name);
        //     if (collider.transform.tag == "Enemy")
        //     {
        //         enemyDamagable = collider.GetComponent<Damagable>();
        //         target = collider.transform;
        //         Vector2 direction = (Vector2)target.transform.position - _rb.position;
        //         direction.Normalize();
        //         float rotateAmount = Vector3.Cross(direction, transform.up).z;
        //         _rb.angularVelocity = -rotateAmount * _rotateSpeed;
        //         _rb.velocity = transform.up * _speed;
        //     }
        // }

        if (_aiDetector.TargetVisible)
        {
            enemyDamagable = _aiDetector.Target.GetComponent<Damagable>();
            target = _aiDetector.Target.transform;
            Vector2 direction = (Vector2)target.transform.position - _rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            _rb.angularVelocity = -rotateAmount * _rotateSpeed;
            _rb.velocity = transform.up * _speed;
        }
        else
        {
            _rb.velocity = transform.up * this.bulletData.speed;
        }
    }

    public void DisableGameObject()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.transform.tag == TARGET_TAG)
        {
            OnHit?.Invoke();
            var damagable = collider2D.GetComponent<Damagable>();
            if (damagable != null)
            {
                damagable.Hit(bulletData.damage);
            }
        }
        DisableGameObject();
    }

    // To draw Gizmoz lines in scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
