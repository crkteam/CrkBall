using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public GameObject[] rank = new GameObject[5];
    public List<Text[]> texts_ui = new List<Text[]>();
    public Rank[] texts;
    public GameObject leaderboard;

    public GameObject self;
    private int condition = 0;

    private void Awake()
    {
        leaderboard.SetActive(true);
//        rank = GameObject.FindGameObjectsWithTag("Rank");
        texts = new Rank[50];
        foreach (var VARIABLE in rank)
        {
            texts_ui.Add(VARIABLE.GetComponentsInChildren<Text>());
        }

        for (int i = 0; i < 50; i++)
        {
            Rank buffer = new Rank();
            texts[i] = buffer;
        }

        leaderboard.SetActive(false);
    }

    public void show()
    {
        leaderboard.SetActive(true);
        showself();
        firebase_Keyin();
    }

    private void showself()
    {
        String id = PlayerPrefs.GetString("Std_ID");
        int point = PlayerPrefs.GetInt("point");
        int level = PlayerPrefs.GetInt("lv");

        Text[] bufferText = self.GetComponentsInChildren<Text>();

        bufferText[1].text = id;
        bufferText[2].text = "Lv " + level;
        bufferText[0].text = point.ToString();
    }

    private void Update() //listener
    {
        if (condition > 0)
        {
            //listen
            ui_Keyin();
            condition = 0;
        }
    }

    private void ui_Keyin()
    {
        int count = texts_ui.Count - 1;

        for (int i = 0; i < texts_ui.Count; i++)
        {
            texts_ui[i][1].text = texts[i].id;
            texts_ui[i][2].text = texts[i].name;
            texts_ui[i][3].text = texts[i].lv;
            texts_ui[i][4].text = texts[i].point;
        }
    }

    private void firebase_Keyin()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://crkball-49368.firebaseio.com/");
        FirebaseDatabase.DefaultInstance
            .GetReference("leaderboard").OrderByChild("point").LimitToLast(50)
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    int count = snapshot.Children.Count() - 1;
                    // Do something with snapshot...
                    foreach (var VARIABLE in snapshot.Children)
                    {
                        String buffer = VARIABLE.Child("name").Value.ToString();
                        Char[] char_buffer = buffer.ToCharArray();
                        char_buffer[1] = 'X';

                        String result = "";
                        foreach (var value in char_buffer)
                        {
                            result += value;
                        }
                        texts[count].id = VARIABLE.Key;
                        texts[count].name = result;
                        texts[count].lv = "Lv " + VARIABLE.Child("lv").Value.ToString();
                        texts[count].point = VARIABLE.Child("point").Value.ToString();
                        count--;
                    }

                    condition = 1;
                }
            });
    }
}