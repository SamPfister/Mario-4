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
    public bool isGrounded;
    
 
    // Start is called before the first frame update
    void Start()
    {
 
        playerBody = GetComponent<Rigidbody>();

        //this is what controls the gravity on the player
        playerGravity = new Vector3(0f, -6f, 0f);
 
        moveSpeed = 100f;
        maxSpeed = 20f;
        jumpForce = 80f;

}

    // Update is called once per frame
    void Update()
    {
        // credits to this link ofr the movement input stuff https://answers.unity.com/questions/1445397/why-is-it-so-hard-to-make-a-rigidbody-jump-in-the.html
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

        Vector3 newVel = transform.forward * movement + transform.right * strafe;
        newVel = newVel.normalized * moveSpeed;

        //speed limiter, leaves y unaffected
        Vector3 temp = newVel;
        float tempy = temp.y;
        temp.y = 0;
        temp = Vector3.ClampMagnitude(temp, maxSpeed);
        temp.y = tempy;
        newVel = temp;
        
        
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse );
        }

        playerBody.AddForce(newVel + playerGravity);

    }

    //These two methods are used for checking if the player is colliding with something
    // used to limit ability of player to air-strafe
    void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
    }
    void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }
}
