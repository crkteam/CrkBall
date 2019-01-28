using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

public class Game_achievement : MonoBehaviour {

	public void newhighPoint(int point,int lv)
	{
		int current = point;
		int pre = PlayerPrefs.GetInt("point");

		if (current > pre)
		{
			PlayerPrefs.SetInt("point",current);
			PlayerPrefs.SetInt("lv",lv);
			
			firebasekeyin(point,lv);
		}
	}

	private void firebasekeyin(int point,int lv)
	{
		String ID = PlayerPrefs.GetString("Std_ID");
		
		
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://crkball-49368.firebaseio.com/");
		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference.Child("leaderboard");
		reference.Child(ID).Child("point").SetValueAsync(point);
		reference.Child(ID).Child("lv").SetValueAsync(lv);
	}
}
