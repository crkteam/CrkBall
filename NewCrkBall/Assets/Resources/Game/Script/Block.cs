using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [Header("HP")]
    public int blockHP;

    void Start()
    {
        gameObject.GetComponentInChildren<Text>().text = blockHP.ToString();
    }

    public void hit(int attack)
    {
        blockHP -= attack;
        gameObject.GetComponentInChildren<Text>().text = blockHP.ToString();

        if (blockHP <= 0)
        {
            dead();
        }
    }

    void dead()
    {
        gameObject.GetComponentInParent<Line>().checkDestroy();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
