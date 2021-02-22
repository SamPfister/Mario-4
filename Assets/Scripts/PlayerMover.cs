using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{
    private Vector3 moveDirection;
    public float moveSpeed = 15f;
    public float jumpForce;
    public CharacterController controller;
    public float gravityScale;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("exitPortal"))
        {
            PlayerPrefs.SetInt("levelsComplete", PlayerPrefs.GetInt("levelsComplete") + 1);
            


        }
        
       
    }
    
}
