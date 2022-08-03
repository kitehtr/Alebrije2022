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
    private BoxCollider2D playerBoxCollider;

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
    private float dashingPower = 25f;
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

    private bool showBounds = true;

    public Color boundsColor = Color.green;
     
     private Vector3 v3FrontTopLeft;
     private Vector3 v3FrontTopRight;
     private Vector3 v3FrontBottomLeft;
     private Vector3 v3FrontBottomRight;
     private Vector3 v3BackTopLeft;
     private Vector3 v3BackTopRight;
     private Vector3 v3BackBottomLeft;
     private Vector3 v3BackBottomRight;  

    private void Awake()
    {
        //Grab reference for rb, animator, and box collider + start timer for flying/dashing 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
        playerBoxCollider.autoTiling = true;
        currentTime = startingTime;
        timerActive = true;
        mana = player.GetComponent<Mana>();
        PauseMenu = player.GetComponent<PauseMenu>();
    
    }
    void CalcPositons(Bounds bounds){
    //  Bounds bounds = GetComponent<MeshFilter>().mesh.bounds;
    // https://answers.unity.com/questions/461588/drawing-a-bounding-box-similar-to-box-collider.html
         
     Vector3 v3Center = bounds.center;
     Vector3 v3Extents = bounds.extents;
  
     v3FrontTopLeft     = new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z);  // Front top left corner
     v3FrontTopRight    = new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z);  // Front top right corner
     v3FrontBottomLeft  = new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z);  // Front bottom left corner
     v3FrontBottomRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z);  // Front bottom right corner
     v3BackTopLeft      = new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z);  // Back top left corner
     v3BackTopRight     = new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z);  // Back top right corner
     v3BackBottomLeft   = new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z);  // Back bottom left corner
     v3BackBottomRight  = new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z);  // Back bottom right corner
         
    v3FrontTopLeft     = transform.TransformPoint(v3FrontTopLeft);
     v3FrontTopRight    = transform.TransformPoint(v3FrontTopRight);
     v3FrontBottomLeft  = transform.TransformPoint(v3FrontBottomLeft);
     v3FrontBottomRight = transform.TransformPoint(v3FrontBottomRight);
     v3BackTopLeft      = transform.TransformPoint(v3BackTopLeft);
     v3BackTopRight     = transform.TransformPoint(v3BackTopRight);
     v3BackBottomLeft   = transform.TransformPoint(v3BackBottomLeft);
     v3BackBottomRight  = transform.TransformPoint(v3BackBottomRight);  

     Debug.Log("CalcPositions" + v3Center );  
 }
     
 void DrawBox() {
     //if (Input.GetKey (KeyCode.S)) {
     Debug.Log("DrawBox Start");
     Debug.DrawLine(new Vector3(200,200,200), Vector3.zero, Color.green, 20, false);
     Debug.Log(v3FrontTopLeft + " " + v3FrontTopRight);
     Debug.DrawLine (v3FrontTopLeft, v3FrontTopRight, boundsColor, 2f, false);
     Debug.DrawLine (v3FrontTopRight, v3FrontBottomRight, boundsColor);
     Debug.DrawLine (v3FrontBottomRight, v3FrontBottomLeft, boundsColor);
     Debug.DrawLine (v3FrontBottomLeft, v3FrontTopLeft, boundsColor);
         
     Debug.DrawLine (v3BackTopLeft, v3BackTopRight, boundsColor);
     Debug.DrawLine (v3BackTopRight, v3BackBottomRight, boundsColor);
     Debug.DrawLine (v3BackBottomRight, v3BackBottomLeft, boundsColor);
     Debug.DrawLine (v3BackBottomLeft, v3BackTopLeft, boundsColor);
         
     Debug.DrawLine (v3FrontTopLeft, v3BackTopLeft, boundsColor);
     Debug.DrawLine (v3FrontTopRight, v3BackTopRight, boundsColor);
     Debug.DrawLine (v3FrontBottomRight, v3BackBottomRight, boundsColor);
     Debug.DrawLine (v3FrontBottomLeft, v3BackBottomLeft, boundsColor);
     //}
 }
     






    private void Update()
    {
        
        if(showBounds)
        {   

            Debug.Log(playerBoxCollider);
            Debug.Log(playerBoxCollider.autoTiling);
            Debug.Log(playerBoxCollider.size);

            if(playerBoxCollider != null)
            {
            //     CalcPositons(playerBoxCollider.bounds);
            //     DrawBox();
                
            }
            else{
                Debug.Log("boxCollider:" + playerBoxCollider);
            }
        }

        if (Input.GetKey(KeyCode.B))
        {
            showBounds = !showBounds;
        }
         
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
                //Debug.Log(currentTime);
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
                
            }
            
        // dash conditions/prompts
        if(Input.GetButton("Dash") && canDash && !isGrounded() && hasJumped == true)
        {
            StartCoroutine(Dash());
            //anim.SetTrigger("Dash");
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
                SoundManager.instance.PlaySound(jumpSound);
            }

            body.velocity = new Vector2(body.velocity.x, speed);
            anim.SetTrigger("Jump");
            canFly = true;
            hasJumped = true;
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
                body.velocity = new Vector2(body.velocity.x, 5);
                anim.SetTrigger("Fly");
            }

            
        }else{
            isFlying = false;
        }

        
        //Debug.Log("fly: " + currentTime);
        
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
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerBoxCollider.bounds.center,playerBoxCollider.bounds.size,0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
        
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerBoxCollider.bounds.center,playerBoxCollider.bounds.size,0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return !onWall();
    }


}
