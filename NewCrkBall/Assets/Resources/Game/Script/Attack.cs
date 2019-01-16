using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Ball")) {
            GameObject.Find("Ball").GetComponent<Ball>().addBallAttack();
            other.gameObject.GetComponentsInChildren<ParticleSystem>()[3].Play();
            Destroy(gameObject);
        }
    } 
}
