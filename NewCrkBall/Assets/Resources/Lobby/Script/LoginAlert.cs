using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginAlert : MonoBehaviour
{
	public Login_Listener LoginListener;
	public GameObject Loginalert;
	private string id;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Login()
	{
		LoginListener.enabled = true;
		LoginListener.SetCondition(3);
	}
	public void show()
	{
		Loginalert.SetActive(true);
	}
}
