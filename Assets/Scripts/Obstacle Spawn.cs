using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPointsObstaclesList;
    [SerializeField] private GameObject obstaclePrefab;
    
    [SerializeField, Range(3.0f, 7.0f)] private float obstacleDespawnInterval;
    [SerializeField, Range(1.0f, 10.0f)] private float obstacleSpawnInterval;
    void Start()
    {
        SpawnObstacle();
    }
    
    private void SpawnObstacle()
    {
        int randomPosition = Random.Range(0, spawnPointsObstaclesList.Count);
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPointsObstaclesList[randomPosition].transform.position, Quaternion.identity);
        obstacle.GetComponent<Obstacle>().StartDestroyCoroutine(obstacleDespawnInterval);
    }
}
