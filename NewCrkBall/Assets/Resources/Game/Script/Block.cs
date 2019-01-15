using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{  
    [Header("HP")]
    int blockHP;

    private int r_blockHP; // use for return

    void Start()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().sortingLayerName = "3" ;
        gameObject.GetComponentInChildren<TextMesh>().text = blockHP.ToString();
    }

    public void initBlockHP(int blockHP)
    {
        r_blockHP = blockHP;
        this.blockHP = blockHP;
    }

    public void hit(int attack)
    {
        blockHP -= attack;
        gameObject.GetComponentInChildren<TextMesh>().text = blockHP.ToString();

        if (blockHP <= 0)
        {
            dead();
        }
    }

    void dead()
    {
        GameObject.Find("Main Camera").GetComponent<GameController>().setPoint(r_blockHP);
        gameObject.GetComponentInParent<Line>().checkDestroy();
        
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
