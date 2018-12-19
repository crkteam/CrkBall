using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour {
	public string SceneString;
	private AudioSource Click;
	// Use this for initialization
	void Start () {
		Click=GameObject.Find("Click").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnMouseDown()
	{
		
		Click.Play();
		Invoke("Scene",1f);
	}
	void Scene()
	{
		SceneManager.LoadScene(SceneString);
	}
}
