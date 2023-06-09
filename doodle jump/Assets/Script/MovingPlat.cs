using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    [SerializeField] private float speed = 0.001f;
    [SerializeField] private bool lOrR;
    [SerializeField] private float changeDirTime;
    private CamFollow camFollow;
    private Vector3 dir;

    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        camFollow = FindObjectOfType<CamFollow>();
        dir = Random.value > 0.5f ? Vector2.right : Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= camFollow.MinX)
        {
            dir = Vector3.right;
        }
        else if (transform.position.x >= camFollow.MaxX)
        {
            dir = Vector3.left;
        }
        transform.position += dir * speed;
    }
}
