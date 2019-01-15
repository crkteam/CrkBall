using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public LineController lineController;
    public BlockHolder blockHolder;
    public TextMesh pointUI;
    // script
    [SerializeField]
    private int round,point;
    // attribute

    // Use this for initialization
    void Start()
    {
        init();
        InvokeRepeating("nextRound", 5, 5f);
    }

    void init()
    {
        round = 0;
        nextRound();
    }

    public void setPoint(int point)
    {
        this.point += point;
        pointUI.GetComponent<TextMesh>().text = this.point.ToString();
        
    }

    void nextRound()
    {
        round++;
        foreach (var gameObject in blockHolder.lines)
        {
            if (gameObject != null)
                gameObject.transform.position += new Vector3(0, -0.725f);
        }

        lineController.blockHP = round;
        lineController.createLIne();
    }

    public void gameover()
    {
        CancelInvoke("nextRound");
        Debug.Log("death");
    }
}