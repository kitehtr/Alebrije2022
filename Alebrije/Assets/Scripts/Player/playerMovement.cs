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
    private BoxCollider2D boxCollider;

    //flying duration variables
    private float currentTime = 0f;
    [SerializeField]private float startingTime = 5f;
    public bool timerActive = false;

    //air dashing variables
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 20f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    
    //testing other stuff
    //public GameObject Player;

    //[SerializeField] Text countdownText;

    private void Awake()
    {
        //Grab reference for rb, animator, and box collider + start timer for flying/dashing 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        currentTime = startingTime;
        timerActive = true;
        
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
            }
            
        }
        
        //flip player when moving left/right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);
        //jump prompts
        if(Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();
        //fly prompts
        if(Input.GetKey(KeyCode.Space) && currentTime > 0 && !isGrounded() )
            fly();
        // dash conditions/prompts
        if(Input.GetKey(KeyCode.LeftShift) && canDash && !isGrounded())
        {
            StartCoroutine(Dash());
        }
        //Set animator parameters
        anim.SetBool("Run", horizontalInput != 0);
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
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("Jump");

    }

    public void fly()
    {
        body.velocity = new Vector2(body.velocity.x, 5);
        anim.SetTrigger("Jump");
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
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return !onWall();
    }


    public void HasAbilities()
    {
        currentTime = 4f;
        timerActive = true;
        Debug.Log(currentTime);
       
    }
}
