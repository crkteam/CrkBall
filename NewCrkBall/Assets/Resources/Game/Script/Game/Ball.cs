﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Vector2 v;
    
    [SerializeField]
    private int ballAttack;
    public GameController gameController;
    
    // Use this for initialization
    void Start()
    {
        ballAttack = 1;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(8,4);
    }

    public void addBallAttack()
    {
        ballAttack++;
    }

    // Update is called once per frame
    void Update()
    {
        v = gameObject.GetComponent<Rigidbody2D>().velocity;

        if (gameObject.transform.position.y < -5.3)
        {
            gameController.gameover();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag.Equals("Block"))
        {
            other.gameObject.GetComponent<Block>().hit(ballAttack);            
        }
        
        if (other.gameObject.name.Equals("Board"))
        {
            GameObject.Find("Connect").GetComponent<AudioSource>().Play();
        }
        
    }
}