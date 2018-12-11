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
            gameObject.GetComponentInParent<LineCreator>().LineCount -= 1;
            GameObject.Find("Main Camera").GetComponent<Game_Controller>().cash += cash;
            Destroy(gameObject);
        }


        hp_text.text = block_hp.ToString();
    }
    
    
}