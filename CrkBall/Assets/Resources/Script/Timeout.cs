using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeout : MonoBehaviour
{
	public GameObject PauseText,paddle;
 private bool timeout = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		if (timeout)
		{
			
			Time.timeScale = 1;
			paddle.GetComponent<Paddle>().enabled = true;
			gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Stop");
			
		}
		else
		{
			
			Time.timeScale = 0;
			paddle.GetComponent<Paddle>().enabled = false;
			gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Resume");
		}
		timeout = !timeout;
		PauseText.SetActive(!PauseText.activeSelf);
	}
	
}
