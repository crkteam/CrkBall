using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internet_Button : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        GameObject.Find("Click").GetComponent<AudioSource>().Play();


        GameObject.Find("internetBackground").SetActive(false);
    }
}