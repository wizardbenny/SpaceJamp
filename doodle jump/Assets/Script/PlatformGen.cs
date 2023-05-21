using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformGen : MonoBehaviour
{
    public int rows = 1;
    [SerializeField] Vector2 rangeY;
    [SerializeField] int maxPlatform;
    [SerializeField] GameObject[] platformPrefabs;
    [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] Transform playerTransform;
    [SerializeField] private CamFollow cameraFollow;
    [SerializeField] private GameObject portal;

    [SerializeField] [Range(0f, 1f)]
    private float enemySpawnRate = 0.1f;
    private int maxPortal = 1;

    private Vector2 previousPos;
    private Vector2 offset = new Vector2(0, 1f);
    [SerializeField] private float portalSpawn;
    // Start is called before the first frame update
    void Start()
    {
        if(cameraFollow == null) 
        {
            cameraFollow = FindObjectOfType<CamFollow>();
        }
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
        if(playerTransform.position.y >= portalSpawn &&  maxPortal == 1)
        {
            Instantiate(portal, new Vector3(0, playerTransform.position.y + 15, 0),Quaternion.identity);
            maxPortal = 0;
        }
    }

    void GenPlatform()
    {
        for (int i = 0; i < maxPlatform; i++) {
            float posX = Random.Range(cameraFollow.MinX, cameraFollow.MaxX);
            int posY = (int)previousPos.y + Random.Range((int)rangeY.x, (int)rangeY.y);
            Vector2 position = new Vector2(posX, posY);
            Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)],
                        position,
                        Quaternion.identity);

            if(Random.Range(0f, 1f) <= enemySpawnRate) GenerateEnemy(position);
            previousPos = position;
        }
    }

    void GenerateEnemy(Vector2 platformPos)
    {
        int randIndx = Random.Range(0, enemyPrefabs.Length);
        if (enemyPrefabs.Length == 0)
        {
            return;
        }
        Instantiate(enemyPrefabs[randIndx], platformPos + offset, Quaternion.identity);
    }
}
