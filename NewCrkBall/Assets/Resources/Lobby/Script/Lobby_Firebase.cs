using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

public class Lobby_Firebase : MonoBehaviour
{
    public Login_Listener loginListener;

    public void check(String id, String password)
    {
        if (id.Length == 8)
        {
            loginListener.enabled = true;
            firebase_check(id, password);
        }
        else
        {
            Debug.Log("學號是8個數字喔");
        }
    }

    private void firebase_check(String id, String password)
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://crkball-49368.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        String current_password;
        FirebaseDatabase.DefaultInstance
            .GetReference("user/" + id + "/password")
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    // Do something with snapshot...
                    current_password = snapshot.Value.ToString();

                    if (password.Equals(current_password))
                    {
                        loginListener.SetCondition(1); // 1登入成功
                        loginListener.SetID(id);
                        Debug.Log("登入成功");
                    }
                    else
                    { 
                        loginListener.SetCondition(2); // 2密碼失敗
                        Debug.Log("密碼錯誤");
                    }
                }
                
            });
    }
}