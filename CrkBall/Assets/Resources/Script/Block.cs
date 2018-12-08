using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int block_hp;
    private int ball_attack;
    private TextMesh hp_text;
    private int cash;

    // Use this for initialization
    void Start()
    {
        cash = block_hp;
        hp_text = gameObject.GetComponentInChildren<TextMesh>();
        ball_attack = GameObject.Find("Main Camera").GetComponent<Game_Controller>().ball_attack;
        hp_text.text = block_hp.ToString();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {  
        if (other.gameObject.name == "ball")
        {
            block_hp -= ball_attack;

            if (block_hp <= 0)
            {
                gameObject.GetComponentInParent<LineCreator>().LineCount -= 1;
                GameObject.Find("Main Camera").GetComponent<Game_Controller>().cash += cash;
                Destroy(gameObject);
            }


            hp_text.text = block_hp.ToString();
        }
    }
}