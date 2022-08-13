using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private AudioClip Cactus;
    [SerializeField] private AudioClip CactusDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        
        {
        collision.GetComponent<Health>().TakeDamage(damage);
        SoundManager.instance.PlaySound(Cactus);
        SoundManager.instance.PlaySound(CactusDamage);
        }
    }
}
