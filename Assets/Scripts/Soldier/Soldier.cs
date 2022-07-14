 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soldier : MonoBehaviour
{
    public float checkDistacne;
    private Rigidbody2D m_body;
    public GameObject target;
    public float speed;
    private float destroy = 4.0f;
    private float combatRange = 5.0f;
    private float timer;
    public GameObject bullet;
    public Transform barrel;
    

    private Animator m_Ani;
   
    private Vector2 movement;
    private Vector3 lookDir;

    [Header("..Soldier Health..")]
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Slider slider;
    [SerializeField] private float health;
    [SerializeField] private bool alive;


    [Header("..Check Player Distance..")]
    [SerializeField] private bool away;
    [SerializeField] private bool found;
    [SerializeField] private bool shoot;


     void Start()
    {
        
        health = slider.maxValue;
        healthBar.SetActive(false);
        m_body = GetComponent<Rigidbody2D>();
        m_Ani = GetComponentInChildren<Animator>();
       
    }


    void Update()
    {
        if(slider.value>0.5f)
        {
            alive = true;
        }
        checkDistacne = Vector2.Distance(target.transform.position, transform.position); // check the ditance between Player and Enemy


        if(alive && checkDistacne>combatRange)
        {
            away = true; found = false; shoot = false;
            speed = 0.0f;
            Debug.Log("Away");
        }

        if( alive && checkDistacne<=combatRange)
        {
            away = false; found = true; shoot = false;
            speed = 1.0f;
            lookDir = target.transform.position - transform.position;///////
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;////////////Look Target Position
            m_body.rotation = angle;///////////////////////////////////////////////////
            lookDir.Normalize();//////////////////////////////////////////////////////

            m_body.MovePosition(transform.position + (lookDir * speed * Time.deltaTime));
            movement = lookDir;
            Debug.Log("We found target and star moving");
            
        }

        if (alive && checkDistacne <= combatRange / 2)
        {
            speed = 0.0f;
            m_body.MovePosition(transform.position + (lookDir * speed * Time.deltaTime));
            away = false; found = false; shoot = true;
            Debug.Log("We start Shooting");
        }

        m_Ani.SetBool("idle", away);
        m_Ani.SetBool("walk", found);
        m_Ani.SetBool("shoot", shoot);


        if(shoot)
        {
            timer = timer + Time.deltaTime;
            if(timer>=1.0f)
            {
                timer = 0;
                GameObject newBullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
                newBullet.transform.position = barrel.up * 10*Time.deltaTime;
                
            }
        }
        if(slider.value<=0)
        {
          alive = false;
          healthBar.SetActive(false);
          m_Ani.Play("Soldier_Machine_die2");
          Destroy(gameObject, destroy / 2.5f);
          

        }

       

    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag =="Player")
        {
           healthBar.SetActive(true);
           m_Ani.Play("Soldier_Machine_die2");
            slider.value = 0.0f;
        }

        if(collision.transform.tag =="Bullet")
        {
           healthBar.SetActive(true);
            
           
           slider.value = slider.value - 0.5f;
      
        }
    }

   /* public void DeadAnimation()
    {
        lookDir = transform.position;
        int random = Random.Range(0, 2);//Randomize int for Random Death Animation
        switch (random)
        {
            case 0:
                m_Ani.Play("Soldier_Machine_die");
                break;
            case 1:
                m_Ani.Play("Soldier_Machine_die2");
                break;
        }
        Destroy(gameObject, destroy);//Delay before destroy
    } */


}

