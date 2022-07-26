using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    playerMovement PlayerMovement;
    [SerializeField] GameObject player;
    Mana mana;


    void Awake()
    {
        PlayerMovement = player.GetComponent<playerMovement>();
        mana = player.GetComponent<Mana>();
    }


    public void pollinate()
    {
        mana.AddMana(1);
        
        // Since there is no animation for pollinating yet, I am just going to comment out the animation trigger for it.
        //anim.SetTrigger("Pollinate");
    }
}
