using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
	private int point;
	public GameObject paddle;
	public GameObject PauseBackground;
	public GameObject[] item;
	private AsyncOperation AO;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pause()
	{
        		PauseBackground.SetActive(true);
        		Time.timeScale = 0;
        	
	}
	public void PauseQuit()
	{
	
		StartCoroutine(PauseOut());
	}
//	IEnumerator PauseIn()
//	{
//			
//		
//	}

	IEnumerator PauseOut()
	{
		switch (point)
		{
			case 1:
				AO = SceneManager.LoadSceneAsync("Main");
				AO.allowSceneActivation=false;
				
			
				break;
			case 2:
				AO = SceneManager.LoadSceneAsync("Lobby");
				AO.allowSceneActivation=false;

	
				break;
		}
		
		PauseBackground.GetComponent<Animator>().SetTrigger("quit");
		yield return new WaitForSeconds(.01f);
		switch (point)
		{case 0 :
				paddle.GetComponent<Paddle>().enabled = true;
				PauseBackground.SetActive(false);
				break;
		default:
			AO.allowSceneActivation = true;
			break;
			
		}
        		PauseBackground.SetActive(false);
	}
	public void SetPoint(int Point)
	{
		point = Point;
	}
}
