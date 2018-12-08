using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	public GameObject _gameObject;
	// Use this for initialization
	void Start () {

		StartCoroutine(test());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator test()
	{
		while (true)
		{
			if(_gameObject.transform.localScale.x > 50)
				break;
			
			_gameObject.transform.localScale += new Vector3(1f,1f,0);
			yield return new WaitForSeconds(0.01f);
		}	
		
		
	}
}
