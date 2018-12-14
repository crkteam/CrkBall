using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Vector2 m_screenPos;
    float block_x;
    float block_y;
    private bool start = true;

    // Use this for initialization
    void Start()
    {
        block_x = GameObject.Find("RightBlock").transform.position.x -
                  GameObject.Find("RightBlock").transform.right.x / 2;
        block_y = GameObject.Find("LeftBlock").transform.position.x +
                  GameObject.Find("LeftBlock").transform.right.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            float limit_x = 0;
            float limit_y = 0;
            //開始觸碰
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                GameObject.Find("ball").GetComponent<Ball>().enabled = true;

                //紀錄觸碰位置
                m_screenPos = Input.touches[0].position;

                limit_x = -gameObject.transform.right.x - limit_x;
                limit_y = gameObject.transform.right.x + limit_y;
                //手指移動
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                gameObject.transform.position +=
                    new Vector3(Mathf.Clamp(Input.touches[0].deltaPosition.x / 200, -limit_x, limit_y), 0);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (start)
            {
                GameObject.Find("game_music").GetComponent<AudioSource>().Play();
                GameObject.Find("Main Camera").GetComponent<Game_Controller>().enabled = true;
                GameObject.Find("ball").GetComponent<Ball>().enabled = true;

                start = false;
            }
            Destroy(GameObject.Find("start_text"));


            GameObject block_x = GameObject.Find("RightBlock");

            if (!block_x.GetComponentInChildren<BoxCollider2D>().OverlapPoint(
                gameObject.transform.position + (gameObject.transform.right / 2) * gameObject.transform.localScale.x))
                gameObject.transform.position += new Vector3(0.05f, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (start)
            {
                GameObject.Find("game_music").GetComponent<AudioSource>().Play();
                GameObject.Find("Main Camera").GetComponent<Game_Controller>().enabled = true;
                GameObject.Find("ball").GetComponent<Ball>().enabled = true;

                start = false;
            }
            Destroy(GameObject.Find("start_text"));


            GameObject block_x = GameObject.Find("LeftBlock");

            if (!block_x.GetComponentInChildren<BoxCollider2D>().OverlapPoint(
                gameObject.transform.position - (gameObject.transform.right / 2) * gameObject.transform.localScale.x))
                gameObject.transform.position += new Vector3(-0.05f, 0);
        }
    }
}