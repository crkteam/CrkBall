using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
	private String Id;
	private String password;

	private void Awake()
	{
		Id = PlayerPrefs.GetString("Id");
		password = PlayerPrefs.GetString("Password");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
	}

	public void show()
	{
		
	}
}
