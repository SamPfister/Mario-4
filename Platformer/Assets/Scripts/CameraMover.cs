using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public bool useOffsetValues;

    public float mouseSens;

    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // get x pos of mmouse and rotate the target
        float horizontal = Input.GetAxis("Mouse X") * mouseSens;
        float vertical = Input.GetAxis("Mouse Y") * mouseSens;
        target.Rotate(-vertical, horizontal, 0);
        //move camera based on rotation of target and orig. offset
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = target.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation*offset);

        //target.Rotate(0, horizontal, vertical);
        //transform.position = target.position - offset;
        transform.LookAt(target);
    }
}
