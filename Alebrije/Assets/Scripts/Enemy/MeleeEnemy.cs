using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;

    [SerializeField] private LayerMask playerLayer;
    private Health playerHealth;
    private Animator anim;
    private Patrol Patrol;
    [SerializeField]private BoxCollider2D boxCollider;
    private float cooldownTimer = Mathf.Infinity;


    void Awake()
    {
        anim = GetComponent<Animator>();
        Patrol = GetComponentInParent<Patrol>();

    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(PlayerInSight())
        {
        if(cooldownTimer >= attackCooldown)
        {
            cooldownTimer = 0;
            anim.SetTrigger("MeleeAttack"); 


        }
        }
        if(Patrol != null)
            Patrol.enabled = !PlayerInSight();

    }

        private void Deactivate()
    {
        gameObject.SetActive(false);

    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),0, Vector2.left, 0, playerLayer);
        
        if(hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

            return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    
    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}



