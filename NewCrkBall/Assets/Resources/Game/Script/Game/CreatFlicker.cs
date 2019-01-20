using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatFlicker : MonoBehaviour
{

	public GameObject flicker;
	// Use this for initialization
	void Start () {
		InvokeRepeating("CreateObject",1f,.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateObject()
	{
		Debug.Log(gameObject.transform.position.y);
		Vector3 InstantiatePosition=new Vector3(Random.Range(2.5f,-2.5f),gameObject.transform.position.y,0);
		GameObject prefab = Instantiate(flicker,gameObject.transform);
		prefab.transform.position = InstantiatePosition;
	}
}
