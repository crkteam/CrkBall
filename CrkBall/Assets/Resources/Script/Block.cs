using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int block_hp;
    public int ball_attack;
    private TextMesh hp_text;
    public int cash;
    private StatusController statusController;

    private void Awake()
    {
        statusController = GameObject.Find("Main Camera").GetComponent<StatusController>();
    }

    // Use this for initialization
    void Start()
    {
        statusController._baseStatus.blockStart(gameObject);
        
        cash = block_hp;
        hp_text = gameObject.GetComponentInChildren<TextMesh>();
        ball_attack = GameObject.Find("Main Camera").GetComponent<Game_Controller>().ball_attack;
        hp_text.text = block_hp.ToString();
    }


    public void Beaten()
    {
        statusController._baseStatus.blockBeatean(gameObject);
        block_hp -= ball_attack;

        if (block_hp <= 0)
        {
            GameObject.Find("burst").GetComponent<AudioSource>().Play();
            gameObject.GetComponent<ParticleSystem>().Play();
            gameObject.GetComponentInParent<LineCreator>().LineCount -= 1;
            GameObject.Find("Main Camera").GetComponent<Game_Controller>().addCash(cash);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("Destroy",1);
        }
        else
        {
            GameObject.Find("hit").GetComponent<AudioSource>().Play();
        }


        hp_text.text = block_hp.ToString();
        }

    void Destroy()
    {
        Destroy(gameObject);
    }
}

   