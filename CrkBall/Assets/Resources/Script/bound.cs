using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bound : MonoBehaviour {
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "ball")
        {
            gameObject.GetComponentInChildren<ParticleSystem>().transform.position =
                other.gameObject.transform.position;
            
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            
        }
    }
}
