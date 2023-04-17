using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    private float maxHeight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        maxHeight = Mathf.Max(maxHeight, Ball.transform.position.y);
        transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
    }
}
