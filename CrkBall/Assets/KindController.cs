using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KindController : MonoBehaviour
{
	private float Scalecount;
	private int kind=5;
	public Sprite[] image;
	public Transform[] o_position;
	public GameObject[] t_position;
	public GameObject ballImage;
	// Use this for initialization
	void Start ()
	{
		
		init();
		ChangeBallImage();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void init()
	{
		
		Scalecount = 0;
	
		for (int i=0;i<t_position.Length;i++)
		{
			t_position[i].transform.position = o_position[i].transform.position;
			t_position[i].transform.localScale = o_position[i].transform.localScale;
			
		}
		
	}

	public void Scale(float move)
	{
		
		if (Scalecount <= .5)
		{


			if (move < 0)
			{
				t_position[2].GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0.02f);
				t_position[1].GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0.02f);
				t_position[3].GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0.02f);
				t_position[0].GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0.02f);


			}
			else
			{
				t_position[2].GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0.02f);
				t_position[1].GetComponent<RectTransform>().localScale -= new Vector3(0.02f, 0.02f, 0.02f);
				t_position[3].GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0.02f);
				t_position[4].GetComponent<RectTransform>().localScale += new Vector3(0.02f, 0.02f, 0.02f);

			}

			Scalecount += 0.02f;
		}
	}
	public void MovePoint(float move)
	{
		StartCoroutine(Move(move)); //移動250
	}
	IEnumerator  Move(float move)
	{
		int countp=0;
		while (true)
		{
			countp += 90;
			foreach (GameObject img in t_position)
			{
				Scale(move); 
				img.transform.position-=new Vector3(move*90,0f,0f);
				
			}

		if (countp >= 250)
        			{
        				
        				break;
        			}
			yield return new WaitForSeconds(.05f);
			

		}
							ChangeBallImage();
      
	}
	public void ChangeBallImage()
	{
		init();
		ballImage.GetComponent<Image>().sprite = image[kind];
		t_position[2].GetComponent<Image>().sprite = image[kind];
		
		if (kind-1<0)
		{
			t_position[1].GetComponent<Image>().sprite =null;
		}
		else
		{
			
			t_position[1].GetComponent<Image>().sprite = image[kind-1];
		}
		if (kind-2<0)
		{
			
			t_position[0].GetComponent<Image>().sprite =null;
		}
		else
		{
			
			t_position[0].GetComponent<Image>().sprite = image[kind-2];
		}
		if ((kind+1)>image.Length-1)
		{
			t_position[3].GetComponent<Image>().sprite =null;
		}
		else
		{
			t_position[3].GetComponent<Image>().sprite = image[kind+1];
		}
		if(kind+2>image.Length-1)
		{
			t_position[4].GetComponent<Image>().sprite =null;
		}
		else
		{
			t_position[4].GetComponent<Image>().sprite = image[kind+2];
		}
		
		

	}
	public int GetKind()
	{
		return kind;
	}
	public void increase(int x)
	{
		kind += x;
		
	}
}
