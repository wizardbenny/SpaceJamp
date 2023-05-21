using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Portal : MonoBehaviour
{
    float xValue = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xValue += 0.3f;
        transform.localEulerAngles = new Vector3(0, 0, xValue);
    }
}
