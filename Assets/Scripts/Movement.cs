using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public ParticleSystem dust;
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public Animator animator;
    private Rigidbody2D _rigidbody;
    private bool facingRight;
    public int maxHealth = 100;
    int PcurrentHealth;
    public HealthBar  Pbar;
    private void Start()
    {
        PcurrentHealth = maxHealth;
        Pbar.SetHealth(PcurrentHealth, maxHealth);
        _rigidbody = GetComponent<Rigidbody2D>();
        facingRight = true;
    }
  
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(movement));
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
        if((movement < 0 && facingRight) || (movement > 0) && !facingRight)
        {
           dust.Play();
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
           
         if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            dust.Play();
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
       
        if(PcurrentHealth <= 0)
        {
            this.enabled = false;
        }
        
        
    }

    public void CreateDust()
    {
        dust.Play();
    }

     public void TakeDamage(int damage)
    {
        PcurrentHealth -= damage;
        Pbar.SetHealth(PcurrentHealth, maxHealth);
        if(PcurrentHealth <= 0)
        {
        Debug.Log("dead");
        }
    }
}
