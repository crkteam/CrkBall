using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField]
    Vector2 v;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1500, 1000);
	}
	
	// Update is called once per frame
	void Update () {
        v = gameObject.GetComponent<Rigidbody2D>().velocity;
    }
}
