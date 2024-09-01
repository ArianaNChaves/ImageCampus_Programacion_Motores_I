using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private PoolController poolController;

    private const int DESVIATION = 2;
    
    private bool _canSpawnBall;
    private void Start()
    {
        SpawnBall();
    }
    
    public void SpawnBall()
    {
        GameObject ball = poolController.GetObjectFromPool(ObjectType.Ball);
        ball.SetActive(true);
        ball.GetComponent<Ball>().Initiate(spawnPoint);
    }
    
}
