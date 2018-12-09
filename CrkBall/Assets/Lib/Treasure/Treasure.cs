using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure
{
    private int[] lv1, lv2, lv3;

    public Treasure()
    {
        lv1 = new[] {0, 1, 2, 3};
        lv2 = new[] {4, 5, 6};
        lv3 = new[] {7, 8, 9};
    }

    public int Lv1()
    {
        int random = Random.Range(0, 101);

        if (random >= 90)
        {
            return lv3[Random.Range(0, lv3.Length)];
        }
        else if (random >= 60)
        {
            return lv2[Random.Range(0, lv2.Length)];
        }
        else
        {
            return lv1[Random.Range(0, lv1.Length)];
        }
    }
}