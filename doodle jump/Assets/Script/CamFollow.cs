using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    [SerializeField] private bool isFollow = true;
    private float maxHeight;
    private Camera cam;

    public float MinY { get { return minY; } }
    private float minY;
    public float MaxX { get { return maxX; } }
    private float maxX;
    public float MinX { get { return minX; } }
    private float minX;

    private void Awake()
    {
        cam = Camera.main;
        CalculateCamBound();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isFollow)
        {
            maxHeight = Mathf.Max(maxHeight, Ball.transform.position.y);
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }

        CalculateCamBound();
        ScreenWrap();
    }

    void CalculateCamBound()
    {
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        float minXBound = cam.transform.position.x - width / 2f;
        float maxXBound = cam.transform.position.x + width / 2f;

        float minY = cam.transform.position.y - height / 2f;

        this.minX = minXBound;
        this.maxX = maxXBound;
        this.minY = minY;
    }
    void ScreenWrap()
    {

        if (transform.position.x > this.MaxX)
        {
            transform.position = new Vector2(this.minX, transform.position.y);
        }
        else if (transform.position.x < this.minX)
        {
            transform.position = new Vector2(this.maxX, transform.position.y);
        }
    }
}
