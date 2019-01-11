using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour {

    public GameObject block,line,block_holder;
    

	// Use this for initialization
	void Start () {
        createLIne();
        createLIne();

    }

    void createLIne() {
        int[] random = getRandom();
        int width = 0;
        GameObject b_line = Instantiate(line);
        b_line.transform.parent = block_holder.transform;


        for (int i = 0; i < 7; i++)
        {
            int Case = random[i];

            if (Case != 0) {
                GameObject b_block = getBlock(Case);
                b_line.GetComponent<Line>().blocks[i] = b_block;
                b_block.transform.parent = b_line.transform;
                b_block.transform.position += new Vector3(width, 0, 0);           
            }

            width += 180;
        }

        block_holder.GetComponent<BlockHolder>().addLine(b_line);
    }

    GameObject getBlock(int i) {
        GameObject b_block;
        switch (i) {
            case 1:
                b_block = Instantiate(block);
                break;
            default:
                return null;
        }

        return b_block;
    }

    int[] getRandom() {
        int[] random = new int[7];
        
        for (int i = 0; i < 7; i++) {
            random[i] = Random.Range(0,2);
        }

        return random; 
    }
}
