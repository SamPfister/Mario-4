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

    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime * 100;
        target.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime * 100;
        pivot.Rotate(-vertical, 0, 0);

        if(pivot.rotation.eulerAngles.x > 60f && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(60f, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 330f) {
        
            pivot.rotation = Quaternion.Euler(330f, 0, 0);
        }

        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        transform.position = target.position - (rotation*offset);
        if(transform.position.y  < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y-0.5f, transform.position.z);
        }
        transform.LookAt(target);
    }
}
