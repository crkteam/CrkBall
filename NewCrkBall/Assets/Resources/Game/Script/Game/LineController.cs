using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D;

public class LineController : MonoBehaviour
{
    //object
    public GameObject block, attack, line, block_holder, burst;
    //attribute
    public int blockHP = 0;
    public bool burstCheck = true;

    //colorBlock
    public Sprite[] colorBlock = new Sprite[5];
    public void createLIne()
    {
        int[] random = getRandom();
        float width = 0;
        GameObject b_line = Instantiate(line, block_holder.transform);


        for (int i = 0; i < 7; i++)
        {
            int Case = random[i];

            if (Case != 0)
            {
                GameObject b_block = getBlock(Case, b_line.transform);
                b_line.GetComponent<Line>().blocks[i] = b_block;
                b_block.transform.position += new Vector3(width, 0, 0);
            }

            width += 0.71f; // 每隔要移動
        }

        block_holder.GetComponent<BlockHolder>().addLine(b_line);
    }

    int setBlockHP()
    {
        int buffer;
        buffer = blockHP + Random.Range(0, blockHP + 1);
        return buffer;
    }

    GameObject getBlock(int i, Transform father)
    {
        GameObject b_block, r_block; // b = buffer, r = return

        switch (i)
        {
            case 1: // normal
                b_block = block;
                break;
            case 2: // attack
                if (Random.value > 0.25f)
                    b_block = attack;
                else
                    b_block = block;
                break;
            case 3: // burst
                if (Random.value > 0.75f)
                {
                    if (burstCheck)
                    {
                        burstCheck = false;
                        b_block = burst;
                    }
                    else
                    {
                        b_block = block;
                    }
                }
                else
                {
                    b_block = block;
                }

                break;
            default:
                return null;
        }

        r_block = Instantiate(b_block, father);

        if (r_block.gameObject.name.Equals("Block(Clone)"))
        {
            r_block.GetComponent<Block>().initBlockHP(setBlockHP());
            r_block.GetComponent<SpriteRenderer>().sprite = colorBlock[Random.Range(0, 5)];
        }

        return r_block;
    }

    int[] getRandom()
    {
        int[] random = new int[7];

        for (int i = 0; i < 7; i++)
        {
            random[i] = Random.Range(0, 4);
        }

        return random;
    }
}