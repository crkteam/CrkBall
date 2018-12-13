using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour,IPointerDownHandler
{
	public string SceneString;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public  void OnPointerDown(PointerEventData eventData)
	{
        SceneManager.LoadScene(SceneString);
	}
    public void OnMouseDown()
    {
        SceneManager.LoadScene(SceneString);
    }
}
