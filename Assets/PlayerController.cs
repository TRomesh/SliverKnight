using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D myRB;
    SpriteRenderer myRenderer;
    bool facingRight = true;

    //move
    public float maxSpeed;

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Horizontal");

        if (move > 0 && !facingRight) {
            Flip();
        }
        else if (move < 0 && facingRight) {
            Flip();
        }

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
	}


    void Flip(){
        facingRight = !facingRight;
        myRenderer.flipX = !myRenderer.flipX;
    }
}
