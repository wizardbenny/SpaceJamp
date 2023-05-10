using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    private CamFollow camFollow;
    private Animator anim;
    private Basketball player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Basketball>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        camFollow = FindObjectOfType<CamFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < camFollow.MinY)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && player.IsFalling())
        {
            anim.Play("BreatPlat");
        }
        
    }
}
