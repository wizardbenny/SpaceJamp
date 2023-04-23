using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformGen : MonoBehaviour
{
    public int rows = 1;
    [SerializeField] Vector2 rangeY;
    [SerializeField] int maxPlatform;
    [SerializeField] GameObject platformPrefab;
    [SerializeField] 
    // Start is called before the first frame update
    void Start()
    {
        GenPlatform(); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void GenPlatform()
    {
        for (int i = 0; i < maxPlatform; i++) {
            Vector2 position = new Vector2(Random.Range(1, 5), Random.Range(rangeY.x, rangeY.y));
            Instantiate(platformPrefab, position, Quaternion.identity);
        }
    }
}
