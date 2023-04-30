using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    private CamFollow camFollow;
    [SerializeField] GameObject Player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "Player")
        {
            anim.Play("BreatPlat");
            this.GetComponent<BoxCollider2D>().enabled = false;
        }  
    }
        
}
