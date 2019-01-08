using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour{
    [Header("行")]
    public GameObject[] blocks;

    void Awake()
    {
        blocks = new GameObject[7];
    }
}
