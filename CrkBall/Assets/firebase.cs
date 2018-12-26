using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class firebase : MonoBehaviour {
    DatabaseReference reference;
    List<DataSnapshot> data;
    GameObject line;
    bool flag = false;
    // Use this for initialization
    void Start () {
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://crkball-49368.firebaseio.com/");
        line = Resources.Load<GameObject>("Nameline");
            // Get the root reference location of the database.
            reference = FirebaseDatabase.DefaultInstance.RootReference;
        data = new List<DataSnapshot>();
        write();
    }
    void write() {
        FirebaseDatabase.DefaultInstance.GetReference("user").LimitToLast(3).OrderByChild("point").GetValueAsync().ContinueWith(task => {
           if (task.IsFaulted)
           {
               Debug.Log("錯誤");
              // Handle the error...
          }
           else if (task.IsCompleted)
           {
               DataSnapshot snapshot = task.Result;
                foreach (var child in snapshot.Children) {
                    data.Add(child);
                }
                flag = true;
              // Do something with snapshot...
          }
        });
        InvokeRepeating("print", 0, 0.1f);
    }

    void print() {

        if (flag == true) {
            int rank = 1;
            int height = 0;
            for (int i = data.Count - 1; i >= 0; i--)
            {
                GameObject prefabInstance = Instantiate(line);
                prefabInstance.GetComponentsInChildren<Text>()[0].text = rank.ToString();
                prefabInstance.GetComponentsInChildren<Text>()[1].text = data[i].Key;
                prefabInstance.GetComponentsInChildren<Text>()[2].text = data[i].Child("name").Value.ToString();
                prefabInstance.GetComponentsInChildren<Text>()[3].text = data[i].Child("point").Value.ToString();

                prefabInstance.transform.parent = gameObject.transform;
                prefabInstance.transform.localPosition = new Vector3(0, height, 0);
                height -= 100;
                rank++;
            }
            flag = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
