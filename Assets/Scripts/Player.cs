using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerBody;
    public float moveSpeed;
    public float maxSpeed;
    public float jumpForce; 
    public Vector3 playerGravity;
    public Vector3 newVel;
    public bool isGrounded;
    
 
    // Start is called before the first frame update
    void Start()
    {
 
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


        // credits to this link for the movement input stuff https://answers.unity.com/questions/1445397/why-is-it-so-hard-to-make-a-rigidbody-jump-in-the.html
        // and this one for the x and z speed cap https://answers.unity.com/questions/772165/constrain-velocity-on-only-x-z-let-the-jump-fly-fr.html

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

        //playerBody.AddForce(newVel + playerGravity);

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

    }

    void LateUpdate()
    {
        playerBody.AddForce(newVel + playerGravity);
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
            moveSpeed = 200f;
            maxSpeed = 40f;
        }
        if (other.gameObject.CompareTag("JumpPad"))
        {
            jumpForce = 30f;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
