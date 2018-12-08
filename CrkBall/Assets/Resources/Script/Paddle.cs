using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private Vector2 m_screenPos;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
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

        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * 10, 0);
    }
}