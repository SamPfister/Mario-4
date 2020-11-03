using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
    private Vector3 moveDirection;
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;

    void Start()
    {
      controller = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (!controller.isGrounded && hit.normal.y < 0.3f)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y += jumpForce* 1.5f;
                    if(moveDirection.y >= 12)
                    {
                        moveDirection.y = 12;
                    }
                }          
            }
    } 
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetButton("Fire1"))
            {
                moveSpeed = 4f;
            }
            
            else
            {
                moveSpeed = 12f;
            }
        }
        else
        {
            moveSpeed = 12f;
        }

        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")+ transform.right*Input.GetAxisRaw("Horizontal"));
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1) * moveSpeed;
        moveDirection.y = yStore;
 


        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y += jumpForce;
            }
        }
        
        moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale * Time.deltaTime;
        controller.Move(moveDirection*Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("exit1"))
        {
            SceneManager.LoadScene(1);
        }
    }

    
}
