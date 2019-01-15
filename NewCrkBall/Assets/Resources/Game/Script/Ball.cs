using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Vector2 v;

    public int ballAttack;
    public GameController gameController;
    
    // Use this for initialization
    void Start()
    {
        ballAttack = 1;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(6,3);
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
    }
}