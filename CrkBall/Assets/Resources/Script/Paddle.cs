using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Vector2 m_screenPos;
    private bool start = true;

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
                if (start)
                {
                    GameObject.Find("game_music").GetComponent<AudioSource>().Play();
                    GameObject.Find("Main Camera").GetComponent<Game_Controller>().enabled = true;
                    GameObject.Find("ball").GetComponent<Ball>().enabled = true;
                    start = false;
                }
                //紀錄觸碰位置
                m_screenPos = Input.touches[0].position;
                //手指移動
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                if(gameObject.transform.position.x <1.6 && gameObject.transform.position.x >-1.6)
                    gameObject.transform.position += new Vector3(Input.touches[0].deltaPosition.x / 300, 0);
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