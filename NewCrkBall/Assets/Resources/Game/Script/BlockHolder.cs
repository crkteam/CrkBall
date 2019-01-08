using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHolder : MonoBehaviour{
    
    GameObject[] lines;

    private void Awake()
    {
        lines = new GameObject[11];
    }
}
