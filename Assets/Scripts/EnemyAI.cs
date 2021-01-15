using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask rayCastMask;
    public float rayCastLength;
    public float attackDistance;
    public float speed;
    public float timer;
    public float damage;
    


    public Transform Lleft;
    
    public Transform Lright;



    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float lastAttack;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private bool damaging;
    public float intTimer;
    

    void Awake()
    {
         SelectTarget();
        intTimer =timer;
        anim = GetComponent<Animator>();
    }

void Update()
    {

        if(!attackMode)
        {
             Move();
        }

        if(!Limits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            SelectTarget();
        }
      if(inRange)
      {
          hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, rayCastMask);
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
          StopAttack();
      }
      Enemy sc = gameObject.GetComponent<Enemy>();
      if(sc.currentHealth < 0 )
      {
          this.enabled = false;
      }
    
    }

    void Move()
    {   
        anim.SetBool("Walk", true); 
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }


    void Attack()
    {
        timer = intTimer;
        attackMode = true;
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", true);
       

       
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;
        damaging = false;
       
        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        damaging = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if(distance > attackDistance)
        {
           
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
            if(damaging)
            {
            DealDamage();
            }
           
        }
        if(cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inRange = true;
            Flip();
        }
    }

    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        }
        else if(attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    public void TriggerDamage()
    {
        damaging = true;
    }

    private bool Limits()
    {
        return transform.position.x > Lleft.position.x && transform.position.x < Lright.position.x;
    }

    private void SelectTarget()
    {
        float distanceL = Vector2.Distance(transform.position, Lleft.position);
        float distanceR = Vector2.Distance(transform.position, Lright.position);

        if(distanceL > distanceR)
        {
            target = Lleft;
        }
        else
        {
            target = Lright;
        }
        Flip();
    }

    private void Flip()
    {
        Vector3 flip = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            flip.y = 180f;
        }
        else
        {
            flip.y = 0f;
        }
        transform.eulerAngles = flip;
    }
    void DealDamage()
    {
         if(Time.time > lastAttack + timer)
        {
        target.SendMessage("TakeDamage", damage);
        lastAttack = Time.time;
        }
    }

}

 