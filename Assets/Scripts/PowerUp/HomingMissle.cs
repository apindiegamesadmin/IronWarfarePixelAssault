using UnityEngine;

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

    // Start is called before the first frame update
    void Awake()
    {
        // enemyDamagable = GameObject.Find("EnemyTank").GetComponent<Damagable>();
        enemyDamagable = GameObject.FindWithTag("Enemy").GetComponent<Damagable>();
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        // bulletData = GetComponent<BulletData>();
        // _speed = bulletData.speed;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 5.0f)
        {
            _timer = 0f;
            DisableGameObject();
        }
        TriggerHomingMissle();
    }

    public void TriggerHomingMissle()
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (Collider2D collider in colliderArray)
        {
            Debug.Log(collider.transform.name);
            if (collider.transform.tag == "Enemy")
            {
                enemyDamagable = collider.GetComponent<Damagable>();
                target = collider.transform;
                Vector2 direction = (Vector2)target.transform.position - _rb.position;
                direction.Normalize();
                float rotateAmount = Vector3.Cross(direction, transform.up).z;
                _rb.angularVelocity = -rotateAmount * _rotateSpeed;
                _rb.velocity = transform.up * _speed;
            }
        }
    }

    public void DisableGameObject()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.transform.tag == "Enemy")
        {
            Debug.Log("Enemy is dead");
            enemyDamagable.Health -= bulletData.damage;
        }
    }

    // To draw Gizmoz lines in scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
