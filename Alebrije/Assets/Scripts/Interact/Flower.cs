using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    playerMovement PlayerMovement;
    [SerializeField] GameObject player;


    void Awake()
    {
        PlayerMovement = player.GetComponent<playerMovement>();
    }


    public void pollinate()
    {
        PlayerMovement.HasAbilities();
        
        // Since there is no animation for pollinating yet, I am just going to comment out the animation trigger for it.
        //anim.SetTrigger("Pollinate");
    }
}
