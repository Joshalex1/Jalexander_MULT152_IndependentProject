using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform[] spawnPoints;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2f, 3f);
    }

    void SpawnObstacle()
    {
        int randomObstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(obstaclePrefabs[randomObstacleIndex], spawnPoints[randomSpawnIndex].position, Quaternion.identity);
    }
} 

 

