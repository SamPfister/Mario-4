using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerBody;
    public float moveSpeed = 50f;
    public float maxSpeed = 20f;
    public float jumpForce = 80f;
    public Vector3 movement;
    public Vector3 playerGravity;
 
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerBody.useGravity = true;
        //this is what controls the gravity on the player
        playerGravity = new Vector3(0f, -5f, 0f);
        
    }

    // Update is called once per frame
    void Update()
    {

        //Bug to fix: Player gravity while jumping works normally when no input held after starting jump, but moves down linearlly if input held
        //this is probably something to do with the speed limiter capping total magnitude of vector3
        // if it could only cap x and z magnitudes and leave y alone that would be cool

        // credits to this link https://answers.unity.com/questions/1445397/why-is-it-so-hard-to-make-a-rigidbody-jump-in-the.html
        //Movement input
        float strafe = Input.GetAxisRaw("Horizontal");
        float movement = Input.GetAxisRaw("Vertical");

        Vector3 newVel = transform.forward * movement + transform.right * strafe;
        newVel = newVel.normalized * moveSpeed;

        //speed limiter
        if (playerBody.velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, maxSpeed);
        }

        playerBody.AddForce(newVel + playerGravity);

        
        if (Input.GetButtonDown("Jump"))
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse );
        }
    }
    void FixedUpdate()
    {    
        //playerBody.AddForce(playerGravity);
    }
}
