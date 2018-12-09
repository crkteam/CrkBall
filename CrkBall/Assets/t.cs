using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        
        Treasure t = new Treasure();
        
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(t.Lv1());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}