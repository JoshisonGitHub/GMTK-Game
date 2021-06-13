//platformer player controller

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformercontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool isonscreen = true;

    public float speed;
    public float jumpForce;
    private float moveInput;
    
    private bool facingRight = true;
    private bool isGrounded;
    public Transform GroundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float stopQtime;
    private bool canpressQ = true;

    public LayerMask whatIsLadder;
    public float distance;
    private bool isClimbing;
    public float climbspeed;
    private float inputVertical;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if (isonscreen)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            
        }
        

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
        
        if(hitInfo.collider != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                isClimbing = true;
            }

        }
        else
        {
            isClimbing = false;
        }

        if (isClimbing)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbspeed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = (float)2.4;
        }

        
    }
    void Update()
    {
        if (isonscreen)
        {
            
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
                anim.SetBool("isjumping", true);
            }
            else
            {
                anim.SetBool("isjumping", false);
            }
        }

        
            if (Input.GetKeyDown(KeyCode.Q) && canpressQ)
            {
                isonscreen = !isonscreen;
                canpressQ = false;
                StartCoroutine(Reset());
            }

        //Debug.Log(isonscreen);
        Debug.Log(moveInput);
        if (isonscreen)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool("iswalking", true);
            }
            else
            {
                anim.SetBool("iswalking", false);
            }
        }
    }



    void Flip()
    {
        if (isonscreen)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(stopQtime);
        canpressQ = true;
    }

    
}
