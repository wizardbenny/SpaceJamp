using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;

    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horiz * speed * Time.deltaTime, rb.velocity.y);
        /*        transform.position += new Vector3(horiz * speed * Time.deltaTime, 0, 0);*/
    }
    public void Bounce()
    {
        //if (!isGround) return;
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            isGround = true;
            Bounce();
        }
    }
}

