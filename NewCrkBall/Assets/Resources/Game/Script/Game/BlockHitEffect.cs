    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHitEffect : MonoBehaviour
{
    private Animator animator;
    public GameObject Particle;

    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Ball"))
        {
            animator.SetTrigger("BlockHit");
            Vector3 ParticlePosition = new Vector3(Particle.transform.position.x, other.transform.position.y,
                Particle.transform.position.z);
            Particle.transform.position = ParticlePosition;
            Particle.GetComponent<ParticleSystem>().Play();
        }
    }
}