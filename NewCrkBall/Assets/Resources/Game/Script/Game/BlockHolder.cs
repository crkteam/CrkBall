using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHolder : MonoBehaviour
{
    [SerializeField] public GameObject[] lines;

    private void Awake()
    {
        lines = new GameObject[11];
    }

    public void addLine(GameObject line)
    {
        pushDown();
        lines[0] = line;
    }

    private void pushDown()
    {
        for (int i = 10; i > 0; i--)
        {
            lines[i] = lines[i - 1];
        }
    }

}