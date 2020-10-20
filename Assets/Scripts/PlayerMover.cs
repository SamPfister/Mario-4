using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

using System.Threading;
using UnityEngine;

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


    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            moveSpeed = 4f;
        }
        else if (Input.GetButton("Fire2"))
        {
            moveSpeed = 15f;
        }
        else
        {
            moveSpeed = 8f;
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
                moveDirection.y = jumpForce;
            }
        }
        
        moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale * Time.deltaTime;
        controller.Move(moveDirection*Time.deltaTime);
    }
}
