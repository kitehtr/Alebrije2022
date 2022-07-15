using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    //patrol points
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    //Enemy
    [SerializeField] private Transform enemy;
    //movement parameters
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [SerializeField] private Animator anim;
    
    private void awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {   
        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            MoveInDirection(-1);
            else
                DirectionChange();
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
        anim.SetBool ("Moving", false);
        movingLeft = !movingLeft;
    }


    private void MoveInDirection(int _direction)
    {
        anim.SetBool ("Moving", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z );
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z );
    }

}
