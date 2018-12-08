﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    private GameObject Block;
    private int[] type;
    private int Block_Hp;
    public int LineCount;

    private void Awake()
    {
        //init
        Block_Hp = GameObject.Find("Main Camera").GetComponent<Game_Controller>().Lv;
        Block = Resources.Load<GameObject>("Block");
        LineCount = 0;
        //execute
        create();
    }

    void create()
    {
        float width = 0;
        randomBlock();
        foreach (var value in type)
        {
            switch (value)
            {
                case 0:
                    width += 0.7f;
                    break;
                case 1:
                    LineCount += 1;
                    createBlock(width);
                    width += 0.7f;
                    break;
            }
        }

    }

    void randomBlock()
    {
        type = new int[7];
        for (int i = 0; i < 7; i++)
        {
            type[i] = Random.Range(0, 2);
        }
    }

    void createBlock(float width)
    {
        GameObject prefabInstance = Instantiate(Block);
        prefabInstance.GetComponent<Block>().block_hp = Block_Hp + Random.Range(0, 11);

        prefabInstance.transform.parent = gameObject.transform;
        prefabInstance.transform.localPosition = new Vector3(width, 0, 0);
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (LineCount <= 0)
            Destroy(gameObject);
    }
}