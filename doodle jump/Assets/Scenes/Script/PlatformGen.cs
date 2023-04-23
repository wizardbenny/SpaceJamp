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
    [SerializeField] Transform playerTransform;
    private Vector2 previousPos;
    // Start is called before the first frame update
    void Start()
    {
        previousPos = transform.position;
        GenPlatform();     
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.y > previousPos.y - 10f)
        {
            GenPlatform();
        }
    }

    void GenPlatform()
    {
        for (int i = 0; i < maxPlatform; i++) {
            float posX = Random.Range(-6.0f, 6.0f);
            int posY = (int)previousPos.y + Random.Range((int)rangeY.x, (int)rangeY.y);
            Vector2 position = new Vector2(posX, posY);
            Instantiate(platformPrefab, position, Quaternion.identity);

            previousPos = position;
        }
    }
}
