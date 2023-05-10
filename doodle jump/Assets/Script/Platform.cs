using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private CamFollow camFollow;
    // Start is called before the first frame update
    void Start()
    {
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
}
