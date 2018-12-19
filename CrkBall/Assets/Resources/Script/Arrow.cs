using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Arrow : MonoBehaviour,IPointerDownHandler
{
	public int kind;
	public GameObject Arrowopposite;
	private GameObject ArrowLeft;
	public CreateImage CI;
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public  void OnPointerDown(PointerEventData eventData )
	{
		
			
		CI.increase(kind);
		CI.MovePoint(kind);
		CI.check(gameObject,Arrowopposite);
	}
}
