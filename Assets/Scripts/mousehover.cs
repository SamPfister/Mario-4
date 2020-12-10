using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousehover : MonoBehaviour
{
	void Start()
	{
		GetComponent<Renderer>().material.color = Color.white;
	}

	void OnMouseEnter()
	{
		GetComponent<Renderer>().material.color = Color.red;
	}

	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = Color.white;
	}
}
