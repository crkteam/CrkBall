using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [Header("行")] public GameObject[] blocks;

    void Awake()
    {
        blocks = new GameObject[7];
    }

    public void checkDestroy()
    {
        int check = 6;
        foreach (var VARIABLE in blocks)
        {
            if (VARIABLE == null)
            {
                check--;
            }
        }

        if (check <= 0)
        {
            Destroy(gameObject);
        }
    }
}