using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private StatusController statusController;
    public float speedX;
    public float speedY;

    private void Awake()
    {
        statusController = GameObject.Find("Main Camera").GetComponent<StatusController>();
    }

    // Use this for initialization
    void Start()
    {
        statusController._baseStatus.ballStart(gameObject);

        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(4, 7);
    }

    // Update is called once per frame
    void Update()
    {
        speedX = rigidbody2D.velocity.x;
        speedY = rigidbody2D.velocity.y;
        
        handle();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        statusController._baseStatus.ballCollision(gameObject, other);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        statusController._baseStatus.ballTrigger(gameObject, other);
    }

    void handle()
    {
        rigidbody2D.velocity = speedhandle();
    }

    Vector2 speedhandle()
    {
        float bsx = speedX;
        float bsy = speedY;
        if (speedX < 0)
        {
            bsx = bsx * -1;
        }

        if (speedY < 0)
        {
            bsy = bsy * -1;
        }

        if (bsx + bsy < 12)
        {
            if (bsx > 0)
            {
                bsx++;
            }
            else
            {
                bsx--;
            }

            if (bsy > 0)
            {
                bsy++;
            }
            else
            {
                bsy--;
            }
            
            return new Vector2(bsx,bsy);
        }
        
        if (bsx + bsy > 14)
        {
            if (bsx > 0)
            {
                bsx-=1;
            }
            else
            {
                bsx+=1;
            }

            
            
            if (bsy > 0)
            {
                bsy-=1;
            }
            else
            {
                bsy+=1;
            }
            
            return new Vector2(bsx,bsy);
        }

        return new Vector2(speedX, speedY);
    }
}