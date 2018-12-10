using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Vector2 m_screenPos;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
//            //開始觸碰
//            if (Input.touches[0].phase == TouchPhase.Began)
//            {
//                //紀錄觸碰位置
//                m_screenPos = Input.touches[0].position;
//
//                //手指移動
//            }
//            else if (Input.touches[0].phase == TouchPhase.Moved)
//            {
//                rigidbody2D.velocity = new Vector2(Input.touches[0].deltaPosition.x/2,0);
//            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            GameObject block_x = GameObject.Find("RightBlock");
            
            if(!block_x.GetComponentInChildren<BoxCollider2D>().OverlapPoint(gameObject.transform.position + (gameObject.transform.right/2)*gameObject.transform.localScale.x))
                gameObject.transform.position += new Vector3(0.05f,0);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GameObject block_x = GameObject.Find("LeftBlock");
            
            if(!block_x.GetComponentInChildren<BoxCollider2D>().OverlapPoint(gameObject.transform.position - (gameObject.transform.right/2)*gameObject.transform.localScale.x))
                gameObject.transform.position += new Vector3(-0.05f,0);

        }
    }
}