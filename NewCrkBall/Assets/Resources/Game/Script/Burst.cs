using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour
{
    [SerializeField]
    private GameObject ball, board, gameController;

    private Vector2 currentSpeed;
    private int timer;
    public void use()
    {
         setBall();
    }

    private void setBall()
    {
        //處理ball
        timer = 0;
        currentSpeed = ball.GetComponent<Rigidbody2D>().velocity;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //處理block
        gameController.GetComponent<GameController>().stopNextRound();
        //處理board
        
        InvokeRepeating("quickBall", 2f,1f);

    }

    private void quickBall()
    {
        if (timer == 0)
        {
            ball.GetComponent<Rigidbody2D>().velocity = currentSpeed * 3;
            board.transform.localScale = new Vector3(10,1);
        }
        else
        {
            if (timer > 5)
            {
                timer = 0;
                Vector2 doubleSpeed = ball.GetComponent<Rigidbody2D>().velocity;
                ball.GetComponent<Rigidbody2D>().velocity = doubleSpeed / 3;
                board.transform.localScale = new Vector3(2,1);
                CancelInvoke("quickBall");
            }  
        }
        
        timer++;
    }
}
