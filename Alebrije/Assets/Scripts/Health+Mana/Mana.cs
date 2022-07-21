using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] private float startingMana;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    private bool dead;

    private bool invulnerable;
    public float currentMana { get; private set;}
    //private Animator anim;

    private void Awake()
    {
        currentMana = startingMana;
        //anim = GetComponent<Animator>();
    }

    public void reduceMana(float _mana)
    {
        currentMana= Mathf.Clamp(currentMana - _mana, 0, startingMana);
        
        if(currentMana > 0 )
        {
            //anim.SetTrigger("Hurt");
        }
        else {
            if(!dead)
            {
                //foreach (Behaviour component in components)
                //component.enabled = false;
                
                //anim.SetTrigger("Die");
                //anim.SetBool("Grounded", true);
                if (GetComponent<playerMovement>() != null)
                GetComponent<playerMovement>().enabled = false;
                dead = true;
            }

        }
       
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !PauseMenu.isPaused)
        {
            reduceMana(1);
        }

    }
    
    public void AddMana(float _value)
    {
        currentMana = Mathf.Clamp(currentMana + _value, 0,  startingMana);
    }

    
}
