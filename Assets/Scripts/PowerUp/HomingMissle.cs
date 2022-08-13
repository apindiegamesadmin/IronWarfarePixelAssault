using System.Collections;
using System.Collections.Generic;
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
    public TurretData turretData;

    // Start is called before the first frame update
    void Awake()
    {
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
