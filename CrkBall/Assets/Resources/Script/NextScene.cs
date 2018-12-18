using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour,IPointerDownHandler
{
    public GameObject ball;
	public string SceneString;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public  void OnPointerDown(PointerEventData eventData)
	{
        ball.GetComponent<Animator>().SetTrigger("quit");
        Invoke("Scene", 1f);
	}
    public void OnMouseDown()
    {
        SceneManager.LoadScene(SceneString);
    }
    void Scene()
    {
SceneManager.LoadScene(SceneString);
    }
}
