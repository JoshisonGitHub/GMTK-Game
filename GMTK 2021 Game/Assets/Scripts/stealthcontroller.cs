//stealth player controller

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stealthcontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool isonscreen = false;

    public float speed;
    
    private float moveInput;

    private bool facingRight = true;
    
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
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
}
