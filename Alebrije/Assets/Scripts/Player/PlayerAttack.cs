using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
    //melee attack
    private float timeBTWNAttacks;
    [SerializeField] private float startTimeAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEmemies;
    
    //ranged attack

    // [SerializeField] private float attackCooldown;
     [SerializeField] private int damage;
    // [SerializeField] private Transform firePoint;
    // [SerializeField] private GameObject[] weapons;

    //private float cooldownTimer = Mathf.Infinity;

    //calling the animator and player movement script + cooldown for ranged attack
    private Animator anim;
    private playerMovement playerMovement;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<playerMovement>();
    }

    void Update()
    {
        //melee attack
        if(timeBTWNAttacks <= 0 ) {
            if(Input.GetButton("Attack")){
                anim.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEmemies);
                for (int i = 0; i < enemiesToDamage.Length; i++) 
                {
                    enemiesToDamage[i].GetComponent<Health>().TakeDamage(damage);
                }
            }
            timeBTWNAttacks = startTimeAttack;
        }else {
            timeBTWNAttacks -= Time.deltaTime;
        }
        //ranged attack
        // if(Input.GetMouseButton(1) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        // {
        //     Attack();
        // }

        // cooldownTimer += Time.deltaTime;
    }
    //find range of melee attack
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    //ranged attack method
    // private void Attack()
    // {
    //     anim.SetTrigger("Attack");
    //     cooldownTimer = 0;

    //     weapons[FindWeapon()].transform.position = firePoint.position;
    //     weapons[FindWeapon()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    // }

    // private int FindWeapon()
    // {
    //     for (int i = 0; i < weapons.Length; i++)
    //     {
    //         if(!weapons[i].activeInHierarchy)
    //             return i;
    //     }
    //     return 0;
    // }

    


}
