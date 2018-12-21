using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour,IPointerDownHandler
{
    public GameObject ball;
	private AsyncOperation AO;
	private AudioSource ZoomIn;
	// Use this for initialization
	void Start () {
		ZoomIn=GameObject.Find("ZoomIn").GetComponent<AudioSource>();
		AO = SceneManager.LoadSceneAsync("Main");
		AO.allowSceneActivation = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public  void OnPointerDown(PointerEventData eventData)
	{
		ZoomIn.Play();
        ball.GetComponent<Animator>().SetTrigger("quit");
        Invoke("Scene", 2f);
	}

    void Scene()
    {
	    AO.allowSceneActivation = true;
    }
}
