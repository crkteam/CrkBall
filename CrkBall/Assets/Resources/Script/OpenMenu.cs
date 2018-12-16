using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour, IPointerDownHandler
{
	public int point;
	public GameObject Menu;
	// Use this for initialization
	void Start()
	{
		Menu.GetComponent<RectTransform>().localScale=new Vector3(0,0,0);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public  void OnPointerDown(PointerEventData eventData)
	{
		StartCoroutine(ScaleUpDown(point));
	}

	IEnumerator ScaleUpDown(int point)
	{
		
		float ScaleCount=0;
		if (point>0)
		{
			while (true)
            		{
            			ScaleCount += .1f;
            			Menu.GetComponent<RectTransform>().localScale+=new Vector3(.1f,.1f,.1f);
            			yield return new WaitForSeconds(.01f);
            			if (ScaleCount >= 1)
            			{
            				break;
            			}
            		}
		}
		else
		{
			while (true)
			{
				ScaleCount -= .1f;
				Menu.GetComponent<RectTransform>().localScale-=new Vector3(.1f,.1f,.1f);
				yield return new WaitForSeconds(.01f);
				if (ScaleCount < -1)
				{
					init();
					break;
				}
			}
		}
		
	}

	void init()
	{
		Menu.GetComponent<RectTransform>().localScale=new Vector3(0f,0f,0f);	
	}

}
