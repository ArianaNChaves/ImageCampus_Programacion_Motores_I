using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private PoolController poolController;

    private GameObject _ball;
    private Ball _ballScript;
    
    private bool _canSpawnBall;
    private void Start()
    {
        SpawnBall();
    }
    
    public void SpawnBall()
    {
        _ball = poolController.GetObjectFromPool(ObjectType.Ball);
        _ball.SetActive(true);
        _ballScript =_ball.GetComponent<Ball>();
        
        Debug.Log(_ball.transform.position);
        WaitToShoot();
    }

    private void WaitToShoot()
    {
        _ballScript.Initiate(spawnPoint);
    }
    
}
