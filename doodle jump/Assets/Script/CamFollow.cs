using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    private float maxHeight;
    private Camera cam;

    
    public float MinY { get { return minY; } }
    private float minY;
    public float MaxX { get { return maxX; } }
    private float maxX;
    public float MinX { get { return minX; } }
    private float minX;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        maxHeight = Mathf.Max(maxHeight, Ball.transform.position.y);
        transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        ScreenWrap();
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

        this.minX = minXBound;
        this.maxX = maxXBound;
        this.minY = minY;
    }
}
