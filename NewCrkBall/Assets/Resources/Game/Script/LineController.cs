using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public GameObject block, attack, line, block_holder,burst;
    public int blockHP = 0;

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

            width += 0.725f; // 每隔要移動
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
        GameObject b_block;
        switch (i)
        {
            case 1:
                b_block = Instantiate(block, father);
                b_block.GetComponent<Block>().initBlockHP(setBlockHP());
                break;
            case 2:
                if (Random.value > 0.5f)
                {
                    b_block = Instantiate(attack, father);
                }
                else
                {
                    b_block = Instantiate(block, father);
                    b_block.GetComponent<Block>().initBlockHP(setBlockHP());
                }
                break;
            case 3:
                if (Random.value > 0.75f)
                {
                    b_block = Instantiate(burst, father);
                }
                else
                {
                    b_block = Instantiate(block, father);
                    b_block.GetComponent<Block>().initBlockHP(setBlockHP());
                }
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
            random[i] = Random.Range(0, 4);
        }

        return random;
    }
}