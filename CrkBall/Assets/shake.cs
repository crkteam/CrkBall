using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour {

	void sh()
	{
		gameObject.transform.position += new Vector3(0.01f,0.01f,0);
	}
	
	// Use this for initialization
	void Start ()
	{
		InvokeRepeating("sh",0,0.01f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
