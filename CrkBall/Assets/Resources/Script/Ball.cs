using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    public float speedX;
    public float speedY;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        
        rigidbody2D.velocity = new Vector2(5, 8);
    }

    // Update is called once per frame
    void Update()
    {
        speedX = rigidbody2D.velocity.x;
        speedY = rigidbody2D.velocity.y;
        
        handle();
    }

    void handle()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,speedhandleY());
    }

    float speedhandleY()
    {
        if (speedY < 7 && speedY > 0)
            return speedY += 1;
        else if (speedY > -7 && speedY < 0)
            return speedY -= 1;
        else if (speedY > 9)
            return speedY -= 1;
        else if (speedY < -9)
            return speedY += 1;
        else
            return rigidbody2D.velocity.y;
    }
    
//    float speedhandleX()
//    {
//        if (speedY < 8)
//            return speedY += 2;
//        else
//            return rigidbody2D.velocity.y;
//    }
}