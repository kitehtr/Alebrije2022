using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    //patrol points
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    //enemy
    [SerializeField] private Transform enemy;

    //movement parameters
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    //idle time
    [SerializeField] private float idleDuration;
    private float idleTimer;

    //enemy animator
    [SerializeField] private Animator anim;


    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("Moving", false);
    }

    private void Update()
    {

        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            MoveInDirection(-1);
            else
            {
                DirectionChange();
                
            }
        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
            MoveInDirection(1);
            else
            DirectionChange();
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("Moving", false);

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("Moving", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, 
        enemy.position.y, enemy.position.z );

    }
}
