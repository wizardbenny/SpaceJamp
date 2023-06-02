using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReappearPlatform : DisappearPlat
{
    // Start is called before the first frame update
    bool maxre = false;
    private Collider2D newCollider2D;
    public override void Start()
    {
        base.Start();
        newCollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!newCollider2D.enabled && !maxre)
        {
            maxre = true;
            StartCoroutine(Reappear());
        }
    }
    protected IEnumerator Reappear()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        for (float i = 0; i <= 1; i+= 0.01f)
        {
            
            currentColor.a = i;
            this.gameObject.GetComponent<SpriteRenderer>().color = currentColor;
            yield return new WaitForEndOfFrame();
        }
        maxre = 0;
    }
} 
