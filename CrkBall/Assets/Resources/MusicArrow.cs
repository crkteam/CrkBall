﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MusicArrow : MonoBehaviour,IPointerDownHandler {
	public int kind;
	public CreateMusic CM;
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public  void OnPointerDown(PointerEventData eventData )
	{
		
		CM.Playmusic();
		CM.increase(kind);
		CM.MovePoint(kind);
		CM.Check();
	}
}
