using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    [SerializeField] private Behaviour[] components;
    private bool invulnerable;
    public float currentHealth { get; private set;}
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth= Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if(currentHealth > 0 )
        {
            //anim.SetTrigger("Hurt");
        }
        else {
            if(!dead)
            {
                foreach (Behaviour component in components)
                    component.enabled = false;
                
                anim.SetTrigger("Die");
                anim.SetBool("Grounded", true);
                if (GetComponent<playerMovement>() != null)
                GetComponent<playerMovement>().enabled = false;
                dead = true;
            }

        }
       
    }
    
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0,  startingHealth);
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("Die");
        anim.Play("idle");
        GetComponent<playerMovement>().enabled = true;

        
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);

    }


}

