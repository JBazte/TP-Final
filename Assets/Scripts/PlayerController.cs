using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;
    private float inputVertical;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsLadder;

    public bool isGrounded;
    public float distance;
    private bool isClimbing;

    private Animator anim;

    // Use this for initialization
    void Start() {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

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

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }

    void FixedUpdate(){
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if(hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
                anim.SetBool("Climb", true);
            }
        }
        else
        {
            isClimbing = false;
            anim.SetBool("Climb", false);
        }

        if (isClimbing == true)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            theRB.velocity = new Vector2(theRB.velocity.x, inputVertical * climbSpeed);
            theRB.gravityScale = 0;
        }
        else
        {
            theRB.gravityScale = 1;
        }
    }
}