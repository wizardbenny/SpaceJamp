using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHoop : MonoBehaviour
{
    private Collider2D collider;
    [SerializeField] private CamFollow camFollow;
    [SerializeField] private float speed = 0.001f;

    [SerializeField] private float MAX_TIME = 3;
    [SerializeField] private ParticleSystem hoopParticle;

    private float timeElapsed;
    private Vector3 dir = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(!collider.enabled)
        {
            timeElapsed += Time.deltaTime;
        }
        if(timeElapsed > MAX_TIME)
        {
            timeElapsed = 0;
            collider.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(collision.relativeVelocity.y <= 0)
            {
                collider.enabled = false;
                PlayParticle();
            }
        }
    }

    private void PlayParticle()
    {
        hoopParticle.Play();
    }

    private void Movement()
    {
        if (transform.position.x <= camFollow.MinX)
        {
            dir = Vector3.right;
        }
        else if (transform.position.x >= camFollow.MaxX)
        {
            dir = Vector3.left;
        }
        transform.position += dir * speed;
    }
}
