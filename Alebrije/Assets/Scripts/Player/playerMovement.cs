using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    //checking for collisions with the walls and celling
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    
    //movment speeds
    [SerializeField] public float flyingSpeed = 12f;
    public float dashDistance = 15f;

    //grabbing reference from the player
    private Rigidbody2D body;
    private Animator anim;
    private CapsuleCollider2D capsuleCollider;

    //flying duration variables
    public bool canFly;
    private bool isFlying;
    public float flyingDuration;
    public float flyingStartTime;
    private float currentTime = 0f;
    [SerializeField]private float startingTime = 5f;
    public bool timerActive = false;

    //air dashing variables
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 20f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    //jump variables
    private bool hasJumped = false;

 
    //mana system
    [SerializeField] GameObject player;
    Mana mana;

    //audio
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip walkSound;

    PauseMenu PauseMenu;
    private bool isMoving;

    private void Awake()
    {
        //Grab reference for rb, animator, and box collider + start timer for flying/dashing 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        currentTime = startingTime;
        timerActive = true;
        mana = player.GetComponent<Mana>();
        PauseMenu = player.GetComponent<PauseMenu>();
    
    }

    private void Update()
    {
         
        if (isDashing)
        {
            return;
        }
        // use a+d or arrow keys to move left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //count down timer
        if(timerActive)
        {
            if(currentTime > 0)
            {
                
                currentTime -= 1 * Time.deltaTime;
                Debug.Log(currentTime);
            }
            else{
            currentTime = 0;
            timerActive = false;
            canFly = false;
            mana.reduceMana(1);
            
            }
            
        }
        
        //flip player when moving left/right
        if (horizontalInput > 0.01f && PauseMenu.isPaused == false)
        {
            transform.localScale = Vector3.one;
            isMoving = true;
        }
        else if (horizontalInput < -0.01f && PauseMenu.isPaused == false)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if (isMoving) {
            //SoundManager.instance.PlaySound(walkSound);
        }
        else{
            isMoving = false;
        }


        //jump prompts
        if(Input.GetButtonDown("Jump") && isGrounded())
            Jump();
            
        //fly prompts
        if(Input.GetButton("Fly") && mana.currentMana > 0 && !isGrounded() && hasJumped == true && canFly == true )
            {   
                if(isFlying == false)
                {
                    currentTime = 2f;
                    timerActive = true;
                    isFlying = true;
                    
                }
                fly();
                //Debug.Log(currentTime);
                
            }
            
        // dash conditions/prompts
        if(Input.GetButton("Dash") && canDash && !isGrounded() && hasJumped == true)
        {
            StartCoroutine(Dash());
        }
        //Set animator parameters
        anim.SetBool("Run", horizontalInput != 0 && PauseMenu.isPaused == false);
        anim.SetBool("Grounded", isGrounded());

        
    }

    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
    }

    public void Jump()
    {
        bool grounded = isGrounded();
        if(grounded && !onWall())
        {
            if(PauseMenu.isPaused == false){
                //SoundManager.instance.PlaySound(jumpSound);
            }

            body.velocity = new Vector2(body.velocity.x, speed);
            anim.SetTrigger("Jump");
            canFly = true;
            hasJumped = true;
            anim.SetTrigger("Fall");
        }     
    }

    public void fly()
    {
        if(mana.currentMana == 0 )
        {
            canFly = false;
        }
        

        if(timerActive)
        {
            
            if(isFlying)
            {
                anim.SetTrigger("Fly");
                body.velocity = new Vector2(body.velocity.x, 5);
            }

            
        }else{
            isFlying = false;
            anim.SetTrigger("Fall");
        }

        Debug.Log("fly: " + currentTime);
        
    }

    public IEnumerator Dash ()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        body.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center,capsuleCollider.bounds.size,0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
        
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center,capsuleCollider.bounds.size,0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return !onWall();
    }


}
