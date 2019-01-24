using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
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
        
                    //開始觸碰
                    if (Input.touches[0].phase == TouchPhase.Began)
                    {
                        //紀錄觸碰位置
                        m_screenPos = Input.touches[0].position;
                        //手指移動
                    }
                    else if (Input.touches[0].phase == TouchPhase.Moved)
                    {
                        gameObject.transform.position += new Vector3( Input.touches[0].deltaPosition.x / 100, 0);
                    }
                }
    
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
        if (other.gameObject.name.Equals("Left_Board"))
        {
            gameObject.transform.position = new Vector3(1.532f, -4.43f, 0);
            
        }

        if (other.gameObject.name.Equals("Right_Board"))
        {
            gameObject.transform.position = new Vector3(-1.57f, -4.43f, 0);
        }
        
        if (other.gameObject.name.Equals("Ball"))
        {
            Vector2 transform = gameObject.transform.position;
            
            transform += new Vector2(0,0.5f);
            other.gameObject.transform.position = transform;
        }
    }
    
    
}