using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScreen : MonoBehaviour
{
	[SerializeField]private GameObject Background,Camera;
	// Use this for initialization
	void Start()
	{
		float factor =1920f/(GetComponent<Camera>().orthographicSize*2); //高比
		float neworthographicSize = 1080 / factor;
		if (Screen.height / Screen.width >= 2)
		{
			Camera.GetComponent<Camera>().orthographicSize = neworthographicSize;
			GameObject AutoBackgroundUp = Instantiate(Background);
			GameObject AutoBackgroundDown = Instantiate(Background);
			AutoBackgroundUp.transform.position = new Vector2(0, 5.5f);
			AutoBackgroundDown.transform.position = new Vector2(0, -5.5f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
