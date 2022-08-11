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

    public FlowerHealth HealthBar;

    //end controls 
    public int flowersPollinated;
    public bool Pollinated = false;
    public int checker = 1;
    


    void Awake()
    {
        PlayerMovement = player.GetComponent<playerMovement>();
        currentHealth = startingHealth;
        HealthBar.SetHealth(currentHealth,startingHealth);
        mana = player.GetComponent<Mana>();
        anim = GetComponent<Animator>();
        flowersPollinated = 10;

    }

    private void Update()
    {
        if(timerActive)
        {
            if(currentTime > 0)
            {
                
                currentTime -= 1 * Time.deltaTime;
            }
            else{
            currentTime = 0;        
            }
            
        }
    }

    public void EndGame()
    {
        if(flowersPollinated >= 10)
        {
            SceneManager.LoadScene("endcredits");
        }

    }


    public void pollinate()
    {
 
        if(currentHealth > 0)
        {
        mana.AddMana(1);
        SoundManager.instance.PlaySound(pollinateSound); 
        checker --;
        Debug.Log(flowersPollinated);
        //Debug.Log(checker);

        
        //Debug.Log(flowersPollinated);
        //Debug.Log(Pollinated);
        // Since there is no animation for pollinating yet, I am just going to comment out the animation trigger for it.
        //anim.SetTrigger("Pollinate");
        TakeDamage(1);

        timerActive = true;
        currentTime = 10f;
        }
        if(!Pollinated && checker == 0)
        {
            Pollinated = true;
            flowersPollinated++;
            Pollinated = false;
        }
        if(currentTime == 0 && currentHealth ==0)
        {
            AddHealth(1);
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
