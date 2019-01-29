using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login_Listener : MonoBehaviour
{
	private int condition = 0;
	private String Id;

	public GameObject login;
	// Update is called once per frame
	void Update () {
		
		if (condition > 0)
		{
			if (condition == 1)
			{
				PlayerPrefs.SetInt("Login",1);
				PlayerPrefs.SetInt("point",0);
				PlayerPrefs.SetInt("level",0);
				PlayerPrefs.SetString("Std_ID",Id);
				login.SetActive(false);
			}

			
			init();
			gameObject.GetComponent<Login_Listener>().enabled = false;
		}
		
	}

	private void init()
	{
		condition = 0;
	}

	public void SetCondition(int condition)
	{
		this.condition = condition;
	}
	
	public void SetID(String id)
	{
		Id = id;
	}
}
