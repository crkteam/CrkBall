using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Arrow : MonoBehaviour,IPointerDownHandler
{
	public int kind;

	public KindController kc;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public  void OnPointerDown(PointerEventData eventData )
	{
		kc.increase(kind);
		
		kc.MovePoint(kind);
	}
}
