using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby_achievet : MonoBehaviour
{

	public Text point_ui,level_ui;
	
	// Use this for initialization
	void Start ()
	{
		int point = PlayerPrefs.GetInt("point");
		int level = PlayerPrefs.GetInt("level");

		point_ui.text = point.ToString();
		level_ui.text = level.ToString();
	}
}
