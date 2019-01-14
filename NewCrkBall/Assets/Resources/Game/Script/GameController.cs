using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public LineController lineController;
    public BlockHolder blockHolder;
    private int round;

    // Use this for initialization
    void Start()
    {
        init();     
        InvokeRepeating("nextRound",5,5f);
    }

    void init()
    {
        round = 0;
        nextRound();
    }

    void nextRound()
    {
        round++;
        foreach (var gameObject in blockHolder.lines)
        {
            if(gameObject!=null)
                gameObject.transform.position += new Vector3(0, -180);
        }
 
        lineController.blockHP = round;
        lineController.createLIne();
        
    }
    
    
}