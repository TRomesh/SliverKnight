using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D myRB;
    SpriteRenderer myRenderer;
    Animator myAnim;

    bool facingRight = true;

    bool canMove = true;

    //move
    public float maxSpeed;

    //jump
    bool grounded = false;
    float groundCheckRadius = 2.0f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpPower;


	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if(canMove && grounded && Input.GetAxis("Jump") > 0)
        {
            myAnim.SetBool("isGrounded", false);
            myRB.velocity = new Vector2(myRB.velocity.x, 0f);
            myRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            grounded = false;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        myAnim.SetBool("isGrounded",grounded);

        float move = Input.GetAxis("Horizontal");

        if (canMove)
        {

            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }

            myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
            myAnim.SetFloat("MoveSpeed", Mathf.Abs(move));

        }
        else
        {
            myRB.velocity = new Vector2(0, myRB.velocity.y);
            myAnim.SetFloat("MoveSpeed", 0);
        }
	}


    void Flip(){
        facingRight = !facingRight;
        myRenderer.flipX = !myRenderer.flipX;
    }

    public void toggleCanMove()
    {
        canMove = !canMove;
    }
}
