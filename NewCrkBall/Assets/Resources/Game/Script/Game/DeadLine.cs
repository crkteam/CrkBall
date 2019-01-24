﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    public GameController gameController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Block(Clone)"))
        {
            gameController.gameover();
        }

        if (other.gameObject.name.Equals("Attack(Clone)"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Equals("Burst(Clone)"))
        {
            Destroy(other.gameObject);
        }
    }
}
