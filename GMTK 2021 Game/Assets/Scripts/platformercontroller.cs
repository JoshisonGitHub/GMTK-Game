//platformer player controller

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformercontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool isonscreen = true;
    private bool isclimbing = false;

    public float speed;
    public float jumpForce;
    private float moveInput;
    
    private bool facingRight = true;
    private bool isGrounded;
    public Transform GroundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    
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

        
        
        
    }
    void Update()
    {
        if (isonscreen)
        {
            if(!isclimbing){
            
                if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
                {
                    rb.velocity = Vector2.up * jumpForce;
                }
            }
            else{
                rb.gravityScale = 0;
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            isonscreen = !isonscreen;
        }
        Debug.Log(isonscreen);
    }



    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Climbable" && Input.GetKeyDown(KeyCode.W))
        {
            this.isclimbing = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Climbable")
        {
            this.isclimbing = false;
        }
    }
}
