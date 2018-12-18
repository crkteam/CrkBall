using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeout : MonoBehaviour
{
	public GameObject paddle;

	public PauseController PC;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		Time.timeScale = 0;
		PC.Pause();
		paddle.GetComponent<Paddle>().enabled = false;
	}
	
}
