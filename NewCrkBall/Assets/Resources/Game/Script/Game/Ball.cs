using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour
{
    [SerializeField] Vector2 currentSpeed;

    [SerializeField] private int ballAttack;
    public GameController gameController;

    public bool speedHandlerSwitch = true;

    //Particle System
    public ParticleSystem death_particle;
    // Use this for initialization
    //Music
    public AudioSource attack;

    // SpriteRenderer
    public SpriteRenderer left, right;
    private float SpeedControllValue = 0.2f; //handle速度

    void Start()
    {
        ballAttack = 1;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(11, 4);
    }

    public void addBallAttack()
    {
        attack.Play();
        ballAttack++;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = gameObject.GetComponent<Rigidbody2D>().velocity;

        if (gameObject.transform.position.y < -5.3)
        {
            Vector3 current = death_particle.GetComponent<Transform>().transform.position;
            current.x = gameObject.transform.position.x;

            death_particle.GetComponent<Transform>().transform.position = current;
            death_particle.Play();
            gameController.gameover();
            Destroy(gameObject);
        }

        // 速度維持器
        if (speedHandlerSwitch)
        {
            speedHandler();
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

        if (other.gameObject.name.Equals("Left_Block"))
        {
            left.enabled = true;
            Invoke("closeLeft", .125f);
            GameObject.Find("HitWall").GetComponent<AudioSource>().Play();

        }

        if (other.gameObject.name.Equals("Right_Block"))
        {
            right.enabled = true;
            Invoke("closeRight", .125f);
            GameObject.Find("HitWall").GetComponent<AudioSource>().Play();

        }
    }

    void closeRight()
    {
        right.enabled = false;
    }

    void closeLeft()
    {
        left.enabled = false;
    }

    void speedHandler()
    {
        float judge = Math.Abs(currentSpeed.x) + Math.Abs(currentSpeed.y);
        if (judge > 12)
        {
            Vector2 bufferSpeed = currentSpeed;
            if (bufferSpeed.x > 0)
            {
                bufferSpeed.x -= SpeedControllValue;
            }
            else
            {
                bufferSpeed.x += SpeedControllValue;
            }

            if (bufferSpeed.y > 0)
            {
                if (bufferSpeed.y < .5f) //速度過快但垂直速度過低
                {
                    bufferSpeed.y += SpeedControllValue*.5f;
                }
                else
                {
                    bufferSpeed.y -= SpeedControllValue;
                }
               
            }
            else
            {
                if (bufferSpeed.y > -.5f) //速度過慢但垂直速度過低
                {
                    bufferSpeed.y -= SpeedControllValue*.5f;
                }
                else
                {
                     bufferSpeed.y += SpeedControllValue;
                }
               
            }

            gameObject.GetComponent<Rigidbody2D>().velocity = bufferSpeed;
        }

        if (judge < 11)
        {
            Vector2 bufferSpeed = currentSpeed;
            if (bufferSpeed.x > 0)
            {
                bufferSpeed.x += SpeedControllValue;
            }
            else
            {
                bufferSpeed.x -= SpeedControllValue;
            }

            if (bufferSpeed.y > 0)
            {
                bufferSpeed.y += SpeedControllValue;
            }
            else
            {
                bufferSpeed.y -= SpeedControllValue;
            }

            gameObject.GetComponent<Rigidbody2D>().velocity = bufferSpeed;
        }
    }
}