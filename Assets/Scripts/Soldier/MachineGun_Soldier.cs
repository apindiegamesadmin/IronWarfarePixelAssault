using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MachineGun_Soldier : MonoBehaviour
{
    public float checkDistacne;
    private Rigidbody2D m_body;
    Transform target;
    public float speed;
    private float combatRange = 5.0f;
    private float timer;
    //public Rigidbody2D bullet;
    public GameObject blood;//Blood Object Reference
    public Transform barrel;

    public BulletData BulletData;
    public Damagable damagable;

    [SerializeField] UnityEvent OnDead;

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
    AIDetector aiDetector;

    private void Awake()
    {
        bulletPool = GetComponent<ObjectPool>();
        aiDetector = GetComponentInChildren<AIDetector>();
    }

    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
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

        if (aiDetector.TargetVisible && gameObject.activeInHierarchy)
        {
            target = aiDetector.Target;
            checkDistacne = Vector2.Distance(target.transform.position, transform.position); // check the ditance between Player and Enemy

            if (checkDistacne > combatRange)
            {
                away = true; found = false; shoot = false;
                speed = 0.0f;
            }

            if (checkDistacne <= combatRange)
            {
                away = false; found = true; shoot = false;
                speed = 0.8f;
                lookDir = target.transform.position - transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;//Look Target Position
                m_body.rotation = angle;
                lookDir.Normalize();

                m_body.MovePosition(transform.position + (lookDir * speed * Time.deltaTime));

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
            playerHealth = target.GetComponent<Damagable>().Health;

            if (playerHealth < 0)
            {
                timer = 0; shoot = false;
                m_Ani.SetBool("shoot", false);
                m_Ani.SetBool("idle", true);
            }
        }
        else
        {
            timer = 0;
            away = true;
            found = false;
            shoot = false;
            m_Ani.SetBool("idle", away);
            m_Ani.SetBool("walk", found);
            m_Ani.SetBool("shoot", shoot);
        }


        if (slider.value <= 0)
        {
            OnDead.Invoke();

            dead = true;
            healthBar.SetActive(false);
            int rand = Random.Range(0, 2);
            switch (rand)
            {
                case 0:
                    m_Ani.Play("Soldier_Machine_die1");
                    break;
                case 1:
                    m_Ani.Play("Soldier_Machine_die2");
                    break;
            }
            if (blood != null)
            {
                blood.SetActive(true);//Spawn Blood Animation
                Destroy(blood, 1f);//Delay Before Destroying Blood
            }
            this.GetComponent<Collider2D>().enabled = false;
            this.gameObject.tag = "Untagged";
            this.gameObject.layer = 0;
            Destroy(gameObject, 2.5f);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        var damagable = collision.GetComponent<Damagable>();
        if (collision.transform.tag == "Player" || (collision.transform.tag == "Enemy" && damagable != null))
        {
            OnDead.Invoke();
            dead = true;
            healthBar.SetActive(false);
            int rand = Random.Range(0, 2);
            switch (rand)
            {
                case 0:
                    m_Ani.Play("Soldier_Machine_die1");
                    break;
                case 1:
                    m_Ani.Play("Soldier_Machine_die2");
                    break;
            }
            this.GetComponent<Collider2D>().enabled = false;
            this.gameObject.tag = "Untagged";
            this.gameObject.layer = 0;
            Destroy(gameObject, 2.5f);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (dead)
            return;
        /*if (collision.transform.tag == "Player")
        {
            OnDead.Invoke();
            dead = true;
            healthBar.SetActive(false);
            int rand = Random.Range(0, 2);
            switch (rand)
            {
                case 0:
                    m_Ani.Play("Soldier_Machine_die1");
                    break;
                case 1:
                    m_Ani.Play("Soldier_Machine_die2");
                    break;
            }
            this.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 2.5f);
        }*/
        if (collision.transform.tag == "MachineGunBullet")
        {
            healthBar.SetActive(true);
            slider.value = slider.value - 0.5f;
        }
        else if (collision.transform.tag == "Bullet")
        {
            OnDead.Invoke();
            dead = true;
            healthBar.SetActive(false);
            int rand = Random.Range(0, 4);
            switch (rand)
            {
                case 0:
                    m_Ani.Play("Soldier_Machine_diehard");
                    break;
                case 1:
                    m_Ani.Play("Soldier_Machine_diehard1");
                    break;
                case 2:
                    m_Ani.Play("Soldier_Machine_diehard2");
                    break;
                case 3:
                    m_Ani.Play("Soldier_Machine_diehard3");
                    break;
            }
            this.GetComponent<Collider2D>().enabled = false;
            this.gameObject.tag = "Untagged";
            this.gameObject.layer = 0;
            GetComponent<BodyPartsSpawner>().SpawnBodyParts(collision.GetComponent<Bullet>().direction, collision.transform.position);
            Destroy(gameObject, 2.5f);
        }
        else if (collision.transform.tag == "HomingMissile")
        {
            OnDead.Invoke();
            dead = true;
            healthBar.SetActive(false);
            int rand = Random.Range(0, 4);
            switch (rand)
            {
                case 0:
                    m_Ani.Play("Soldier_Machine_diehard");
                    break;
                case 1:
                    m_Ani.Play("Soldier_Machine_diehard1");
                    break;
                case 2:
                    m_Ani.Play("Soldier_Machine_diehard2");
                    break;
                case 3:
                    m_Ani.Play("Soldier_Machine_diehard3");
                    break;
            }
            this.GetComponent<Collider2D>().enabled = false;
            this.gameObject.tag = "Untagged";
            this.gameObject.layer = 0;
            GetComponent<BodyPartsSpawner>().SpawnBodyParts(collision.GetComponent<HomingMissle>().direction, collision.transform.position);
            Destroy(gameObject, 2.5f);
        }
    }
}

