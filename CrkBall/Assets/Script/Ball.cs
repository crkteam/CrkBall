using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private Rigidbody2D rigidbody2D;
	
	// Use this for initialization
	void Start ()
	{
		rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		rigidbody2D.velocity = new Vector2(5,5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
}
