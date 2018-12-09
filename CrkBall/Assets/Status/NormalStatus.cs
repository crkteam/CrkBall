using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStatus : BaseStatus
{
    public void blockStart(GameObject gameObject)
    {
    }

    public void blockBeatean(GameObject gameObject)
    {
    }

    public void ballStart(GameObject gameObject)
    {
    }

    public void ballCollision(GameObject gameObject, Collision2D other)
    {
        if (other.gameObject.name == "Block(Clone)")
        {
            other.gameObject.GetComponent<Block>().Beaten();
        }
    }

    public void ballTrigger(GameObject gameObject, Collider2D other)
    {
    }
}