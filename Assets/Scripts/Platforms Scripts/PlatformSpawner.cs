using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlatformSpawner instance;
    private float distanceBetweenTwoPlatforms;
    private int platforms_Spawned; // count spawned
    [SerializeField]
    private Transform platformsParrent; // Left Platforms and Right Platforms will be children of platFormsParrent
    [SerializeField]
    private GameObject leftPlatforms, rightPlatforms, coins;
    public int spawnCount = 7;
    [SerializeField] private GameObject bomb;

    void Awake()
    {
        Make_Instance();
    }

    void Start()
    {
        distanceBetweenTwoPlatforms = transform.position.y; // Instantiate distance y Between Left Platforms and Right Platforms
        SpawnPlatforms();
    }

    void Make_Instance() // can call function in this script
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #region Spawn Platforms
    public void SpawnPlatforms()
    {
        Vector2 temp = transform.position;
        GameObject newPlatform = null;
        for(int i = 0; i < spawnCount; i++)
        {
            temp.y = distanceBetweenTwoPlatforms;
            if (Random.Range(0, 5) < 2)
            {
                temp.x = Random.Range(-2f, 1f);
                newPlatform = Instantiate(coins, temp, Quaternion.identity);
                newPlatform.transform.parent = platformsParrent;
            }

            if(platforms_Spawned % 2 == 0) // even is Right, odd is left
            {
                temp.x = Random.Range(-2f, -1f);
                newPlatform = Instantiate(leftPlatforms, temp, Quaternion.identity);
            }
            else
            {
                temp.x = Random.Range(1f, 2f);
                newPlatform = Instantiate(rightPlatforms, temp, Quaternion.identity);
            }
            newPlatform.transform.parent = platformsParrent; 
            distanceBetweenTwoPlatforms += Random.Range(1.3f,1.5f);
            platforms_Spawned++;
        }

        if (Random.Range(0,5) > 2)
        {
            SpawnBoom();
        }
    }
    #endregion

    #region SpawnBoom
    private void SpawnBoom()
    {
        Vector2 temp = transform.position;
        temp.x = Random.Range(-2, 2);
        temp.y += 5f;
        GameObject newBoom = Instantiate(bomb, temp, Quaternion.identity);
        newBoom.transform.parent = platformsParrent;
    }
    #endregion
}
