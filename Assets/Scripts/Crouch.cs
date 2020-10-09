using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    CharacterController characterCollider;
    public Vector3 temp;
    public float currenty;
    // Start is called before the first frame update
    void Start()
    {
        characterCollider = gameObject.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterCollider.height = 0.5f;
            temp = transform.localScale;
            temp.y = 0.6f;
            transform.localScale = temp;
        }
        else
        {
            characterCollider.height = 1.8f;
            temp = transform.localScale;
            temp.y = 1f;
            transform.localScale = temp;
        }
            
    }
}
