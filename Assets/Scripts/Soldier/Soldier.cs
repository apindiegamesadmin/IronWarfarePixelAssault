using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public float checkDistacne;
    private Rigidbody2D m_body;
    public GameObject target;
    public float speed;
    private float destroy = 1.0f;
    private float combatRange = 5.0f;
    

    private Animator m_Ani;
    private Vector2 movement;
    private Vector3 lookDir;

    [SerializeField] private bool away;
    [SerializeField] private bool found;
    [SerializeField] private bool shoot;


    private void Start()
    {
       
        m_body = GetComponent<Rigidbody2D>();
        m_Ani = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        checkDistacne = Vector2.Distance(target.transform.position, transform.position); // check the ditance between Player and Enemy


        if(checkDistacne>combatRange)
        {
            away = true; found = false; shoot = false;
            speed = 0.0f;
            Debug.Log("Away");
        }

        if(checkDistacne<=combatRange)
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

        if (checkDistacne <= combatRange / 2)
        {
            speed = 0.0f;
            m_body.MovePosition(transform.position + (lookDir * speed * Time.deltaTime));
            away = false; found = false; shoot = true;
            Debug.Log("We start Shooting");
        }

        m_Ani.SetBool("idle", away);
        m_Ani.SetBool("walk", found);
        m_Ani.SetBool("shoot", shoot);

    }

 


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag =="Player")
        {
            m_Ani.Play("Soldier_Machine_die");
            Destroy(gameObject, destroy/2.5f);
        }

        if(collision.transform.tag =="Bullet")
        {
            m_Ani.Play("Soldier_Machine_die2");
            Destroy(gameObject, destroy/2.5f);
        }
    }


}
