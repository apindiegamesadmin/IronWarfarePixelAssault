using UnityEngine;
using UnityEngine.UI;

public class MachineGun_Soldier : MonoBehaviour
{
    public float checkDistacne;
    private Rigidbody2D m_body;
    public Transform target;
    public float speed;
    private float destroy = 4.0f;
    private float combatRange = 5.0f;
    private float timer;
    //public Rigidbody2D bullet;
    public GameObject blood;//Blood Object Reference
    public Transform barrel;

    public BulletData BulletData;
    public Damagable damagable;

    private Animator m_Ani;

    private Vector2 movement;
    private Vector3 lookDir;

    [Header("..Soldier Health..")]
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Slider slider;
    [SerializeField] private float health;
    //[SerializeField] private bool alive;


    [Header("..Check Player's Conditions..")]
    [SerializeField] private bool away;
    [SerializeField] private bool found;
    [SerializeField] private bool shoot;
    [SerializeField] private int playerHealth;

    public TurretData turretData;
    public int bulletPoolCount = 10;
    private ObjectPool bulletPool;

    bool dead;

    private bool[] isFalse = new bool[5];

    private void Awake()
    {
        bulletPool = GetComponent<ObjectPool>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        bulletPool.Initialize(turretData.bulletPrefab, bulletPoolCount);

        health = slider.maxValue;
        healthBar.SetActive(false);
        m_body = GetComponent<Rigidbody2D>();
        m_Ani = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        if (dead)
            return;

        if(target.gameObject.activeInHierarchy)
        {
            checkDistacne = Vector2.Distance(target.transform.position, transform.position); // check the ditance between Player and Enemy
        }


        if (checkDistacne > combatRange)
        {
            away = true; found = false; shoot = false;
            speed = 0.0f;
        }

        if (checkDistacne <= combatRange)
        {
            away = false; found = true; shoot = false;
            speed = 1.0f;
            lookDir = target.transform.position - transform.position;///////
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;////////////Look Target Position
            m_body.rotation = angle;///////////////////////////////////////////////////
            lookDir.Normalize();//////////////////////////////////////////////////////

            m_body.MovePosition(transform.position + (lookDir * speed * Time.deltaTime));
            movement = lookDir;

        }

        if (checkDistacne <= combatRange / 2)
        {
            speed = 0.0f;
            m_body.MovePosition(transform.position + (lookDir * speed * Time.deltaTime));
            away = false; found = false; shoot = true;
        }

        m_Ani.SetBool("idle", away);
        m_Ani.SetBool("walk", found);
        m_Ani.SetBool("shoot", shoot);

        if (shoot)
        {
            timer = timer + Time.deltaTime;
            if (timer >= 0.2f)
            {
                timer = 0;
                var hit = Physics2D.Raycast(barrel.position, barrel.up);

                GameObject bullet = bulletPool.CreateObject();
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Initialize(BulletData);
                bullet.GetComponent<Bullet>().direction = barrel.up;
            }
        }
        playerHealth = target.GetComponentInChildren<Damagable>().Health;

        if (playerHealth < 0)
        {
            timer = 0; shoot = false;
            m_Ani.SetBool("shoot", false);
            m_Ani.SetBool("idle", true);
        }


        if (slider.value <= 0)
        {
            healthBar.SetActive(false);
            m_Ani.Play("Soldier_Machine_die2");
            if (blood != null)
            {
                blood.SetActive(true);//Spawn Blood Animation
                Destroy(blood, 1f);//Delay Before Destroying Blood
            }
            Destroy(gameObject, destroy / 2.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (dead)
            return;
        if (collision.transform.tag == "Player")
        {
            healthBar.SetActive(true);
            m_Ani.Play("Soldier_Machine_die2");

            slider.value = 0.0f;
        }
        else if(collision.transform.tag == "MachineGunBullet")
        {
            healthBar.SetActive(true);
            slider.value = slider.value - 0.5f;
        }
        else if (collision.transform.tag == "Bullet")
        {
            dead = true;
            m_Ani.Play("Soldier_Machine_diehard");
            GetComponent<BodyPartsSpawner>().SpawnBodyParts(collision.GetComponent<Bullet>().direction,collision.transform.position);
            Destroy(gameObject, destroy / 2.5f);
        }
    }
}

