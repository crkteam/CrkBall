using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_achievement : MonoBehaviour {

	public void newhighPoint(int point)
	{
		int current = point;
		int pre = PlayerPrefs.GetInt("point");

		if (current > pre)
		{
			PlayerPrefs.SetInt("point",current);
		}
	}
}
