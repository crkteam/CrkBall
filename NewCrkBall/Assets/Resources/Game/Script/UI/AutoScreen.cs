using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScreen : MonoBehaviour
{
	[SerializeField]private GameObject Background,Camera;
	// Use this for initialization
	void Start()
	{
		float newOrthographicSize = ((float) Screen.height / (float) Screen.width) * 1080f / 1920f * 4.96f;
		Camera.GetComponent<Camera>().orthographicSize = newOrthographicSize;
		GameObject AutoBackgroundUp = Instantiate(Background);
		GameObject AutoBackgroundDown = Instantiate(Background);
		AutoBackgroundUp.transform.position = new Vector2(0, 5.5f);
		AutoBackgroundDown.transform.position = new Vector2(0, -5.5f);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
