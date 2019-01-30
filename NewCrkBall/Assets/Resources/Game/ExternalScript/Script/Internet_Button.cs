using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internet_Button : MonoBehaviour
{
    public GameObject chdisconnect, endisconnect;

    // Use this for initialization
    void Start()
    {
        chdisconnect.GetComponent<MeshRenderer>().sortingLayerName = "Disconnect_UI";
        endisconnect.GetComponent<MeshRenderer>().sortingLayerName = "Disconnect_UI";
        chdisconnect.GetComponent<MeshRenderer>().sortingOrder = 3;
        endisconnect.GetComponent<MeshRenderer>().sortingOrder = 3;
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