using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [Header("HP")] int blockHP;

    private int r_blockHP; // use for return

    void Start()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().sortingLayerName = "3";
        gameObject.GetComponentInChildren<TextMesh>().text = blockHP.ToString();
    }

    public void initBlockHP(int blockHP)
    {
        r_blockHP = blockHP;
        this.blockHP = blockHP;
    }

    public void hit(int attack)
    {
        Color full = gameObject.GetComponentsInChildren<SpriteRenderer>()[1].color;
        full.a = 255;
        gameObject.GetComponentsInChildren<SpriteRenderer>()[1].color = full;
        Invoke("flash", 0.2f);

        blockHP -= attack;
        gameObject.GetComponentInChildren<TextMesh>().text = blockHP.ToString();

        if (blockHP <= 0)
        {
            dead();
        }
    }

    private void flash()
    {
        Color current = gameObject.GetComponentsInChildren<SpriteRenderer>()[1].color;
        current.a = 0;
        gameObject.GetComponentsInChildren<SpriteRenderer>()[1].color = current;
    }

    void dead()
    {
        GameObject.Find("Main Camera").GetComponent<GameController>().setPoint(r_blockHP);
        gameObject.GetComponentInParent<Line>().checkDestroy();
        gameObject.AddComponent<Explodable>();
        gameObject.GetComponent<Explodable>().explode();
    }
}