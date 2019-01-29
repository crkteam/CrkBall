using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_burst : MonoBehaviour
{
    [SerializeField] private GameObject ball, board, gameController;
    [SerializeField] private Material invert;
    [SerializeField] private TextMesh TimeCount;
    public Burst_music burstMusic;

    [SerializeField] private LineController lineController;

    private Vector2 currentSpeed,currentPosition;
    private int timer;

    public void use()
    {
//		blockHolder.destroyBurst();
        ball.GetComponent<Ball>().speedHandlerSwitch = false;
        setBall();
    }

    private void setBall()
    {
        //處理ball
        timer = 0;
        currentSpeed = ball.GetComponent<Rigidbody2D>().velocity;
        currentPosition = board.GetComponent<Transform>().position;
        ball.GetComponent<Rigidbody2D>().Sleep();
        //處理block
        gameController.GetComponent<GameController>().stopNextRound();
        //處理board
        ball.GetComponentsInChildren<ParticleSystem>()[0].Play();
        burstMusic.changePitch();
        InvokeRepeating("quickBall", 2f, 1f);
    }

    private void quickBall()
    {
          TimeCount.GetComponent<TextMesh>().text = (5 - timer).ToString();
        if (timer == 0)
        {
            invert.SetFloat("_InvertColors", 1);
            ball.GetComponentsInChildren<ParticleSystem>()[2].Play();
            ball.GetComponent<Rigidbody2D>().velocity = currentSpeed * 3f;
            
            board.transform.localScale = new Vector3(10, 1);
        }
        else
        {
            
            if (timer >= 5)
            {
                timer = 0;
                invert.SetFloat("_InvertColors", 0);
                Vector2 doubleSpeed = ball.GetComponent<Rigidbody2D>().velocity;
                ball.GetComponent<Rigidbody2D>().velocity = doubleSpeed / 3f;
               
                board.transform.localScale = new Vector3(0.6f, 0.6f);
                board.GetComponent<Transform>().position = currentPosition;
                lineController.burstCheck = true;
                ball.GetComponent<Ball>().speedHandlerSwitch = true;
                TimeCount.GetComponent<TextMesh>().text =null;
                CancelInvoke("quickBall");
                
            }
        }

        timer++;
        
    }

}