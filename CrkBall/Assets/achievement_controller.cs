using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achievement_controller : MonoBehaviour
{
	private JsonPlayer _jsonPlayer;

	private void Awake()
	{
		_jsonPlayer = new JsonPlayer();
		int[] a = _jsonPlayer.getBall();
		if (a[1] == 0)
		{
			if (_jsonPlayer.gethighPoint() > 50)
			{
				a[1] = 1;
				_jsonPlayer.setBall(a);
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
