using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlat : MonoBehaviour
{
    // Start is called before the first frame update
    private Color currentColor;
    private bool touchPlayer;
    private 
    void Start()
    {
        currentColor = this.gameObject.GetComponent<SpriteRenderer>().color;

    }

    // Update is called once per frame
    void Update()
    {
        //if (touchPlayer)
        //{
        //    currentColor.a -= 0.01f;
        //    this.gameObject.GetComponent<SpriteRenderer>().color = currentColor;
        //}
        //if (currentColor.a <= 0)
        //{
        //    Destroy(this.gameObject);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bool isFall = collision.relativeVelocity.y <= 0;
            if (isFall)
            {
                StartCoroutine(Fading());
            }
            
            
        }
    }
    IEnumerator Fading()
    {
        for (float i = currentColor.a; i>=0; i-=0.01f)
        {
            currentColor.a = i;
            this.gameObject.GetComponent<SpriteRenderer>().color = currentColor;
            yield return new WaitForEndOfFrame();
        }
        Destroy(this.gameObject);
    }
}
