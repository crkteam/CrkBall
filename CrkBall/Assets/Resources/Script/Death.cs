﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("Light").GetComponent<Animator>().transform.position = other.transform.position;
        GameObject.Find("Light").GetComponent<Animator>().SetTrigger("Light");
        
        Invoke("wait",1);
    }

    void wait()
    {
        GameObject.Find("Main Camera").GetComponent<Game_Controller>().death();
    }

    // Update is called once per frame
    void Update()
    {
    }
}