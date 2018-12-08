using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		GameObject.Find("Main Camera").GetComponent<Game_Controller>().death();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
