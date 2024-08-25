using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawn : MonoBehaviour
{
    public static Action OnObstacleDespawned; //todo Consultar si esta bien llamar al evento asi, como llamarlo || si deberia estar aca o en Obstacle.cs

    [SerializeField] private Transform[] spawnPointsObstaclesList;
    [SerializeField] private GameObject obstaclePrefab;
    
    [SerializeField, Range(3.0f, 7.0f)] private float obstacleDespawnInterval;
    [SerializeField, Range(1.0f, 20.0f)] private float obstacleSpawnInterval;
    
    private void OnEnable()
    {
        OnObstacleDespawned += StartRespawnObstacle;
    }
    void Start()
    {
        StartRespawnObstacle();
    }
    private void OnDisable()
    {
        OnObstacleDespawned -= StartRespawnObstacle;
    }
    private void SpawnObstacle()
    {
        Debug.Log("Obstacle Spawn - Spawning Obstacle");
        int randomPosition = RandomIntBetween(0, spawnPointsObstaclesList.Length);
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPointsObstaclesList[randomPosition].position, Quaternion.identity);
        obstacle.GetComponent<Obstacle>().StartDestroy(RandomIntBetween(3, 8));
    }
    private void StartRespawnObstacle()
    {
        Invoke(nameof(SpawnObstacle), obstacleSpawnInterval);
    }
    private int RandomIntBetween(int min, int max)
    {
        return Random.Range(min, max);
    }
}
