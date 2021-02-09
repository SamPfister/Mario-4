using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody playerBody;
    public float moveSpeed;
    public float maxSpeed;
    public float jumpForce; 
    public Vector3 playerGravity;
    public Vector3 newVel;
    public bool isGrounded;
    public bool applyFriction;
    public bool speedBoosted;
    public bool jumpPad;
    public bool onWall;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        playerBody = GetComponent<Rigidbody>();
        //this is what controls the gravity on the player
        playerGravity = new Vector3(0f, -5f, 0f);
        moveSpeed = 100f;
        maxSpeed = 20f;
        jumpForce = 10f;
    }

    // Update is called once per frame
    
    void Update()
    {
        //changes movement speed depending on if player is grounded or not
        // makes airstrafing not op
        if (isGrounded)
        {
                moveSpeed = 100f;        
        }
        else
        {
            moveSpeed = 10f;
        }


        float strafe = Input.GetAxisRaw("Horizontal");
        float movement = Input.GetAxisRaw("Vertical");

        newVel = transform.forward * movement + transform.right * strafe;
        newVel = newVel.normalized * moveSpeed;

        //speed limiter, leaves y unaffected
        Vector3 temp = newVel;
        float tempy = temp.y;
        temp.y = 0;
        temp = Vector3.ClampMagnitude(temp, maxSpeed);
        temp.y = tempy;
        newVel = temp;
        
        //code for jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse );
        }

        // this is the code that controls crouching
        //if LCNTRL is pressed, character's height, speed, and jump height are halved
        if (Input.GetButton("Fire1"))
        {
            temp = transform.localScale;
            temp.y = 0.5f;
            transform.localScale = temp;
            maxSpeed = 10f;
            jumpForce = 5f;
        }
        else
        {
            temp = transform.localScale;
            temp.y = 1f;
            transform.localScale = temp;
            maxSpeed = 20f;
            jumpForce = 10f;
        }

        // this is the part that checks whether or not to apply friction
        // to apply friction, no movement input is pressed and the player is grounded
        if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && isGrounded)
        {
            applyFriction = true;
        }
        else
        {
            applyFriction = false;
        }
    }

    void LateUpdate()
    {
        if (applyFriction)
        {
            // applying friction simply reduces the velocity by 5% each frame
            playerBody.velocity -= 0.05f * playerBody.velocity;
        }
        if (speedBoosted)
        {
            // adds another velocity force if the player is on a speed pad
            playerBody.AddForce(newVel * 2 + playerGravity);
        }
        if (jumpPad)
        {
            // makes the player jump if they are on a jump pad
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        //this is the wall jump code
        //if the player is exclusively on a wall
        if(onWall && !isGrounded)
        {
            if(Input.GetAxisRaw("Horizontal") != 0 && Input.GetButton("Fire1"))
            {
                //when crouched and holding either direction, set newvel's y component to cancel our gravity
                Vector3 temp = newVel;
                float tempy = temp.y;
                temp.y = -playerGravity.y + 1;
                newVel = temp;
            }
            //if they are holding left (on a lefthand wall), push them up and to the right
            if(Input.GetAxisRaw("Horizontal") < 0 && Input.GetButton("Jump"))
            {
                playerBody.AddForce(Vector3.up * jumpForce*0.7f + (transform.right * jumpForce*0.5f), ForceMode.Impulse);
            }
            //if they are holding right (on a righthand wall), push them up and to the left
            if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetButton("Jump"))
            {
                playerBody.AddForce(Vector3.up * jumpForce * 0.7f - (transform.right * jumpForce * 0.5f), ForceMode.Impulse);
            }
        }
        playerBody.AddForce(newVel*2 + playerGravity);
    }


    //These two methods are used for checking if the player is colliding with something
    // used to limit ability of player to air-strafe
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("SpeedBoost"))
        {
            isGrounded = true;
            speedBoosted = true;

        }
        if (other.gameObject.CompareTag("JumpPad"))
        {
            isGrounded = true;
            jumpPad = true;
        }
        if (other.gameObject.CompareTag("wall"))
        {
            onWall = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        if (other.gameObject.CompareTag("SpeedBoost"))
        {
            speedBoosted = false;
        }
        if (other.gameObject.CompareTag("JumpPad"))
        {
            jumpPad = false;
        }
        if (other.gameObject.CompareTag("wall"))
        {
            onWall = false;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "exit0")
        {
            SceneManager.LoadScene(1);
        }
        if (other.tag == "exit1")
        {
            SceneManager.LoadScene(2);
        }
        if (other.tag == "exit2")
        {
            SceneManager.LoadScene(3);
        }
        if (other.tag == "exit3")
        {
            SceneManager.LoadScene(4);
        }
    }
}
