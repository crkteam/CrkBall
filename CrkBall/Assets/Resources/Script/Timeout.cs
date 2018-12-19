using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeout : MonoBehaviour
{
	public GameObject paddle;
	public PauseController PC;

	private AudioSource click;
	// Use this for initialization
	void Start ()
	{
		click = GameObject.Find("Click").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		click.Play();
		Time.timeScale = 0;
		PC.Pause();
		paddle.GetComponent<Paddle>().enabled = false;
	}
	
}
