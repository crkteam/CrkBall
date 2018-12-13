using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseStatus
{
    void blockStart(GameObject gameObject);
    void blockBeatean(GameObject gameObject);
    void ballStart(GameObject gameObject);
    void ballCollision(GameObject gameObject,Collision2D other);
    void ballTrigger(GameObject gameObject, Collider2D other);
}
