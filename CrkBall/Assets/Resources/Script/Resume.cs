using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
	public PauseController PC;
	private AudioSource click;
	public int point;
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
		PC.SetPoint(point);
		PC.PauseQuit();
	}
}
