using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flower : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set;}
    playerMovement PlayerMovement;
    [SerializeField] GameObject player;
    Mana mana;

    private float currentTime = 0f;
    public bool timerActive = false;

    [SerializeField] private AudioClip pollinateSound;

    private Animator anim;
    


    void Awake()
    {
        PlayerMovement = player.GetComponent<playerMovement>();
        currentHealth = startingHealth;
        mana = player.GetComponent<Mana>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(timerActive)
        {
            if(currentTime > 0)
            {
                
                currentTime -= 1 * Time.deltaTime;
                //Debug.Log(currentTime);
            }
            else{
            currentTime = 0;        
            }
            
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("endcredits");
    }


    public void pollinate()
    {
        Debug.Log(currentHealth);

        if(currentHealth > 0)
        {

        mana.AddMana(1);
        SoundManager.instance.PlaySound(pollinateSound); 
        // Since there is no animation for pollinating yet, I am just going to comment out the animation trigger for it.
        //anim.SetTrigger("Pollinate");
        TakeDamage(1);
        Debug.Log(currentHealth);
        timerActive = true;
        currentTime = 10f;
        //Debug.Log(currentTime);
        }
        if(currentTime == 0 && currentHealth ==0)
        {
            AddHealth(1);
            Debug.Log(currentHealth);
        }


    }

    public void TakeDamage(float _damage)
    {
        currentHealth= Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0,  startingHealth);
    }
}
