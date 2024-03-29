using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flower : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float coolDown;
    public float currentHealth { get; private set;}
    playerMovement PlayerMovement;
    [SerializeField] GameObject player;
    Mana mana;

    private float currentTime = 0f;
    public bool timerActive = false;

    [SerializeField] private AudioClip pollinateSound;

    private Animator anim;

    public FlowerHealth HealthBar;

    //end controls 
    public bool Pollinated = false;
    


    void Awake()
    {
        PlayerMovement = player.GetComponent<playerMovement>();
        currentHealth = startingHealth;
        HealthBar.SetHealth(currentHealth,startingHealth);
        mana = player.GetComponent<Mana>();

    }

    private void Update()
    {
        if(timerActive)
        {
            if(currentTime > 0)
            {
                
                currentTime -= (1*Time.deltaTime);
            }
            else if (currentTime <= 0 && currentHealth < startingHealth)
               
            {
                AddHealth(1);
                currentTime = coolDown;
                
            }

            else if(currentHealth >= startingHealth)
            {
                timerActive = false;
            }

        }
    }



    public void pollinate()
    {
 
        if(currentHealth > 0)
        {
        mana.AddMana(1);
        SoundManager.instance.PlaySound(pollinateSound); 
        // Since there is no animation for pollinating yet, I am just going to comment out the animation trigger for it.
        //anim.SetTrigger("Pollinate");
        TakeDamage(1);

        timerActive = true;
        currentTime = coolDown;
        }
        if(!Pollinated)
        {
            Pollinated = true;
        }
        

    }

    public void TakeDamage(float _damage)
    {
        currentHealth= Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        HealthBar.SetHealth(currentHealth,startingHealth);

    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0,  startingHealth);
        HealthBar.SetHealth(currentHealth,startingHealth);
    }
}
