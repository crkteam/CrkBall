using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Ball"))
        {
            GameObject.Find("Skill").GetComponent<Skill_burst>().use();
            Destroy(gameObject);
        }
    }
}