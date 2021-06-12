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
            
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true || Input.GetKeyDown(KeyCode.W) && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }

        
            if (Input.GetKeyDown(KeyCode.Q) && canpressQ)
            {
                isonscreen = !isonscreen;
                canpressQ = false;
                StartCoroutine(Reset());
            }
        
        //Debug.Log(isonscreen);
    }



    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(stopQtime);
        canpressQ = true;
    }
}
