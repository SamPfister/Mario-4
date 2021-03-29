using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class projectileDeleter : MonoBehaviour
{
    public AudioSource hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
              
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            hit.Play();
        }

    }
}
