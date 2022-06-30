using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }


    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag =="Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            
        }
    }
}
