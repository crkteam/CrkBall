using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(-0.05f, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(0.05f, 0, 0);
        }
    }


    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Right_Block"))
        {
            gameObject.transform.position = new Vector3(1.49f, -4.43f, 0);
        }

        if (other.gameObject.name.Equals("Left_Block"))
        {
            gameObject.transform.position = new Vector3(-1.485f, -4.43f, 0);
        }
    }
}