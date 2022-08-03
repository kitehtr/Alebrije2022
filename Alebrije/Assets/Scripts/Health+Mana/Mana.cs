using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] private float startingMana;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    //private bool dead;

    private bool invulnerable;
    public float currentMana { get; private set;}

    playerMovement PlayerMovement;
    //private Animator anim;

    private void Awake()
    {
        currentMana = startingMana;
        PlayerMovement = player.GetComponent<playerMovement>();
        //anim = GetComponent<Animator>();
    }

    public void reduceMana(float _mana)
    {
        currentMana= Mathf.Clamp(currentMana - _mana, 0, startingMana);
       
    }
    private void Update()
    {
        // if(Input.GetKeyDown(KeyCode.E) && !PauseMenu.isPaused)
        // {
        //     AddMana(1);
        // }

    }
    
    public void AddMana(float _value)
    {
        currentMana = Mathf.Clamp(currentMana + _value, 0,  startingMana);
    }

    public void Respawn()
    {
        //dead = false;
        AddMana(startingMana);   
    }

    
}
