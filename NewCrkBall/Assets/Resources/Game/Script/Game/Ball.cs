using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Vector2 v;
    
    [SerializeField]
    private int ballAttack;
    public GameController gameController;
    
    //Particle System
    public ParticleSystem death_particle;
    // Use this for initialization
    
    // SpriteRenderer
    public SpriteRenderer left, right;
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
            Vector3 current = death_particle.GetComponent<Transform>().transform.position;
            current.x = gameObject.transform.position.x;

            death_particle.GetComponent<Transform>().transform.position = current;
            death_particle.Play();
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
        
        if (other.gameObject.name.Equals("Left_Block"))
        {
            
            
            left.enabled = true;
            Invoke("closeLeft",.125f);
        }

        if (other.gameObject.name.Equals("Right_Block"))
        {
            right.enabled = true;
            Invoke("closeRight",.125f);

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
}