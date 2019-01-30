using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

public class Game_achievement : MonoBehaviour {

	public void newhighPoint(int point,int lv,String start,String end)
	{
		int current = point;
		int pre = PlayerPrefs.GetInt("point");
		int login = PlayerPrefs.GetInt("Login");
		int battle = PlayerPrefs.GetInt("battle");

		if (current > pre)
		{
			PlayerPrefs.SetInt("point",current);
			PlayerPrefs.SetInt("lv",lv);

			if (login > 0)
			{
				if (battle == 1)
				{
					firebasekeyin(point,lv,start,end);
				}
			}

			
		}
	}

	private void firebasekeyin(int point,int lv,String start,String end)
	{
		String ID = PlayerPrefs.GetString("Std_ID");
		
		
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://crkball-49368.firebaseio.com/");
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference.Child("leaderboard");
		reference.Child(ID).Child("point").SetValueAsync(point);
		reference.Child(ID).Child("lv").SetValueAsync(lv);
		reference.Child(ID).Child("start").SetValueAsync(start);
		reference.Child(ID).Child("end").SetValueAsync(end);
	}
}
