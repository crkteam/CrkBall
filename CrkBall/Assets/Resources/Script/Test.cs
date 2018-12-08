using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	private int[] type;
	
	// Use this for initialization
	void Start () {
		type = new int[7];

		for (int i = 0; i < 7; i++)
		{
			type[i] = Random.Range(0, 2);
			Debug.Log(type[i]);
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
