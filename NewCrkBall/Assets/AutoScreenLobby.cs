using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScreenLobby : MonoBehaviour
{
	public GameObject autoBG, canvas;
	// Use this for initialization
	void Start () {
		if (Screen.height / Screen.width == 2)
		{
			GameObject Background = Instantiate(autoBG);
			Background.transform.parent = canvas.transform;
			Background.transform.localPosition=new Vector2(0,0);
			Background.transform.localScale=new Vector2(1,1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
