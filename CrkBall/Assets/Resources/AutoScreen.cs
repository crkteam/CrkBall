using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScreen : MonoBehaviour
{

	public GameObject autoBG,canvas;
	
	// Use this for initialization
	void Start () {
		
		if (Screen.height / Screen.width == 2)
		{
			GameObject g = Instantiate(autoBG);
			g.transform.parent = canvas.transform;
			g.transform.localPosition = new Vector2(0,0);
			g.transform.localScale = new Vector2(1,1);
		}
	}
	
}
