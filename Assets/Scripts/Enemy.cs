using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public float speed;

   public HealthBar healthBar;
   private float pauseTime;
   public float startPauseTime;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
      
    }

    void Update()
    {
        
if(currentHealth <= 0)
        {
            this.enabled = false;
        }    
      
         
    }
  public void TakeDamage(int damage)
    {
        pauseTime = startPauseTime;
        currentHealth -= damage;
        SoundManagement.PlaySound("hit2");
        healthBar.SetHealth(currentHealth, maxHealth);

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
        
        Destroy(healthBar.gameObject);
     
       

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
    yield return new WaitForSeconds(1F);
}
 
}


