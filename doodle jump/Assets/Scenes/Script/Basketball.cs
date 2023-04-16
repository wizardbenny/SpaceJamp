using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;

    private bool isGround;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ScreenWrap();
        float horiz = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horiz * speed * Time.deltaTime, rb.velocity.y);
        /*        transform.position += new Vector3(horiz * speed * Time.deltaTime, 0, 0);*/
    }
    public void Bounce()
    {
        //if (!isGround) return;
        
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    }

    void ScreenWrap()
    {
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        float minXBound = cam.transform.position.x - width / 2f;
        float maxXBound = cam.transform.position.x + width / 2f;

        float minY = cam.transform.position.y - height / 2f;

        if (transform.position.x > maxXBound)
        {
            transform.position = new Vector2(minXBound, transform.position.y);
        }
        else if (transform.position.x < minXBound)
        {
            transform.position = new Vector2(maxXBound, transform.position.y);
        }

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

