﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;
    public bool canClimb = false;

    private Animator anim;

    // Use this for initialization
    void Start () {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
        
        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (canClimb && Input.GetKey(KeyCode.W) && isGrounded == false) {
            right = KeyCode.None;
            left = KeyCode.None;
            anim.SetBool("Climb", true);
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
	}

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stairs" && isGrounded == true)
        {
            canClimb = true;
            jump = KeyCode.W;
            jumpForce = 8;
            Time.timeScale = 0.5f;
        }

        if (other.gameObject.tag == "Stairs (1)" && isGrounded == true)
        {
            canClimb = true;
            jump = KeyCode.W;
            jumpForce = 9.5f;
            Time.timeScale = 0.5f;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
       jump = KeyCode.Space;
       jumpForce = 5;
       Time.timeScale = 1f;
       canClimb = false;
       right = KeyCode.D;
       left = KeyCode.A;
       anim.SetBool("Climb", false);
    }
}