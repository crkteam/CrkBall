﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public GameObject block, line, block_holder;
    public int blockHP = 0;

    public void createLIne()
    {
        int[] random = getRandom();
        int width = 0;
        GameObject b_line = Instantiate(line, block_holder.transform, true);


        for (int i = 0; i < 7; i++)
        {
            int Case = random[i];

            if (Case != 0)
            {
                GameObject b_block = getBlock(Case,b_line.transform);
                b_line.GetComponent<Line>().blocks[i] = b_block;
                b_block.GetComponent<Block>().blockHP = setBlockHP();
                b_block.transform.position += new Vector3(width, 0, 0);
            }

            width += 180; // 每隔要移動
        }

        b_line.transform.localPosition = new Vector3(-700, 870);
        block_holder.GetComponent<BlockHolder>().addLine(b_line);
    }

    int setBlockHP()
    {
        int buffer;
        buffer = blockHP + Random.Range(0, blockHP + 1);
        return buffer;
    }

    GameObject getBlock(int i,Transform father)
    {
        GameObject b_block;
        switch (i)
        {
            case 1:
                b_block = Instantiate(block,father);
                break;
            default:
                return null;
        }

        return b_block;
    }

    int[] getRandom()
    {
        int[] random = new int[7];

        for (int i = 0; i < 7; i++)
        {
            random[i] = Random.Range(0, 2);
        }

        return random;
    }
}