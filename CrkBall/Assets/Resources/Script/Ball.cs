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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        statusController._baseStatus.ballCollision(gameObject, other);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        statusController._baseStatus.ballTrigger(gameObject, other);
    }

//    void handle()
//    {
//        rigidbody2D.velocity = new Vector2(speedhandleX(), rigidbody2D.velocity.y);
//    }
//
//    float speedhandleX()
//    {
//        if (speedX > 100 && speedX > 0)
//            return speedX = 6;
//        else if (speedX < -100 && speedX < 0)
//            return speedX = -6;
//        else
//            return rigidbody2D.velocity.x;
//    }
}