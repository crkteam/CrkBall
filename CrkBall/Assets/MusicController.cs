using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
	private JsonPlayer json;
	private GameObject burst, hit, death, connect;

	private AudioClip[] clip;
	// Use this for initialization
	void Start ()
	{
		
		json=new JsonPlayer();
		burst=GameObject.Find("burst");
		hit=GameObject.Find("hit");
		death=GameObject.Find("death");
		connect=GameObject.Find("connect");
		for (int i = 0; i < json.getMusic().Length; i++)
		{
			if (json.getMusic()[i] == 2)
			{
			Debug.Log("music/" + i + "/burst");
			clip[0] = Resources.Load<AudioClip>("music/" + i + "/burst");
			clip[1] = Resources.Load<AudioClip>("music/" + i + "/hit");
			clip[2] = Resources.Load<AudioClip>("music/" + i + "/death");
			clip[3] = Resources.Load<AudioClip>("music/" + i + "/connect");
				break;
			}
		}

		burst.GetComponent<AudioSource>().clip = clip[0];
		hit.GetComponent<AudioSource>().clip = clip[1];
		death.GetComponent<AudioSource>().clip = clip[2];
		connect.GetComponent<AudioSource>().clip = clip[3];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
