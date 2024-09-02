using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ObstacleSpawn : MonoBehaviour
{
    public static Action OnObstacleDespawned; //todo Consultar si esta bien llamar al evento asi, como llamarlo || si deberia estar aca o en Obstacle.cs

    [SerializeField] private Transform[] spawnPointsObstaclesList;
    [SerializeField] private PoolController poolController;
    [SerializeField, Range(1.0f, 20.0f)] private float obstacleSpawnInterval;
    
    private GameObject _obstacle;

    private void OnEnable()
    {
        OnObstacleDespawned += StartRespawnObstacle;
    }
    void Start()
    {
        SpawnObstacle();
    }
    private void OnDisable()
    {
        OnObstacleDespawned -= StartRespawnObstacle;
    }
    private void SpawnObstacle()
    {
        int randomPosition = RandomIntBetween(0, spawnPointsObstaclesList.Length);
        _obstacle = poolController.GetObjectFromPool(ObjectType.Obstacle);
        _obstacle.transform.position = spawnPointsObstaclesList[randomPosition].position;
        _obstacle.SetActive(true);
        // GameObject obstacle = Instantiate(obstaclePrefab, spawnPointsObstaclesList[randomPosition].position, Quaternion.identity);
        _obstacle.GetComponent<Obstacle>().StartDestroy(RandomIntBetween(3, 8));
    }
    private void StartRespawnObstacle()
    {
        poolController.ReturnToPool(ObjectType.Obstacle, _obstacle);
        Invoke(nameof(SpawnObstacle), obstacleSpawnInterval);
    }
    private int RandomIntBetween(int min, int max)
    {
        return Random.Range(min, max);
    }
}
