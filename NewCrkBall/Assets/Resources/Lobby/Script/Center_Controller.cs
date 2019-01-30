using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

public class Center_Controller : MonoBehaviour
{
    private int condition = 0;

    private int battle;

    // Use this for initialization
    private void Awake()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://crkball-49368.firebaseio.com/");
        FirebaseDatabase.DefaultInstance
            .GetReference("control")
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    condition = 1;
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    // Do something with snapshot...
                    battle = int.Parse(snapshot.Child("center").Value.ToString());
                    condition = 1;
                }
            });
    }

    // Update is called once per frame
    void Update()
    {
        if (condition > 0)
        {
            int buffer = PlayerPrefs.GetInt("battle");

            if (buffer != battle)
            {
                PlayerPrefs.SetInt("battle",battle);
                if (battle == 0)
                {
                    PlayerPrefs.SetInt("Login",0);
                }
            }

            condition = 0;
        }
    }
}