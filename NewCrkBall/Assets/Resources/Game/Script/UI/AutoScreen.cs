﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScreen : MonoBehaviour
{
	[SerializeField]private GameObject Background,Camera;
	// Use this for initialization
	void Start ()
	{
		Debug.Log(Screen.height);
		if (Screen.height / Screen.width==2)
		{
			Camera.GetComponent<Camera>().orthographicSize = 5.54f;
			GameObject AutoBackgroundUp = Instantiate(Background);
			GameObject AutoBackgroundDown = Instantiate(Background);
			AutoBackgroundUp.transform.position=new Vector2(0,5.5f);
			AutoBackgroundDown.transform.position=new Vector2(0,-5.5f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}