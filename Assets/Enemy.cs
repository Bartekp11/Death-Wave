using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float timer = 0.0f;
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public float speed;
   private bool movingRight = true;
   public Transform groundDetection;

    void Start()
    {
        currentHealth = maxHealth;
      
    }

    void Update()
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


        if(currentHealth == 20)
            {
                 StartCoroutine("MyCoroutine");
        }
        
         if(currentHealth == 60)
            {
                 StartCoroutine("MyCoroutine");
                }

         
        
         if(currentHealth <= 0)
        {
            this.enabled = false;
        }    
    }
  public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hit");
        if(currentHealth <= 0)
        {
        Death();
        }
    }
    void Death()
    {
        animator.SetBool("IsDead", true);

        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }

    void End()
    {
        
        animator.enabled = false;
    }

    IEnumerator MyCoroutine()
{
    speed  = 0;
    yield return new WaitForSeconds(0.5F);
    speed = 2;
    
}
    IEnumerator MyCoroutine2()
{
    speed  = 0;
    yield return new WaitForSeconds(0.5F);
    speed = 2;
    
}

}
