using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour,IPointerDownHandler
{
    public GameObject ball;
	public string SceneString;

	private AudioSource ZoomIn;
	// Use this for initialization
	void Start () {
		ZoomIn=GameObject.Find("ZoomIn").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public  void OnPointerDown(PointerEventData eventData)
	{
		ZoomIn.Play();
        ball.GetComponent<Animator>().SetTrigger("quit");
        Invoke("Scene", 1f);
	}
    public void OnMouseDown()
    {
	    ZoomIn.Play();
        SceneManager.LoadScene(SceneString);
    }
    void Scene()
    {
SceneManager.LoadScene(SceneString);
    }
}
