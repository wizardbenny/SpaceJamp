using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Basketball : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;
    [SerializeField] private CamFollow camFollow;
    private bool isGround;

    public UnityEvent OnPlayerLose;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < camFollow.MinY)
        {
            OnPlayerLose.Invoke();
        }

    }

    private void FixedUpdate()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horiz * speed * Time.deltaTime, rb.velocity.y);
        /*        transform.position += new Vector3(horiz * speed * Time.deltaTime, 0, 0);*/

    }
    public void Bounce()
    {
        //if (!isGround) return;
        Vector2 velocity = rb.velocity;
        velocity.y = jumpforce;
        rb.velocity = velocity;
        //rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            if (collision.relativeVelocity.y < 0) return;
            isGround = true;
            Bounce();
        }
    }

    public bool IsFalling()
    {
        return rb.velocity.y < 0;
    }
}

