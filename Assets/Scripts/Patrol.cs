using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
  
  
  public float speed;
  public Transform rayCast;
  public LayerMask rayCastMask;
  public float rayCastLength;
  public float attackDistance;
  public float timer;
  public Transform groundDetection;
  
  
    private bool movingRight = true;
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    
   


    void Update()
    {

        if(inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, rayCastMask);
            RaycastDebugger();
        }
        if(hit.collider != null)
        {
            EnemyLogic();
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }
        if(inRange == false)
        {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if(groundInfo.collider == false)
            {
            if(movingRight == true)
                {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
                }
            else
                {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
                }
            }
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }

    void RaycastDebugger()
    {
        if(distance > attackDistance)
    {
        Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
    }
        else if(attackDistance > distance)
        {
             Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }

    }
    

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if(distance > attackDistance)
        {
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if(cooling == true)
        {
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
      
    }

    void StopAttack()
    {

    }

    void Attack()
    {

    }
}
