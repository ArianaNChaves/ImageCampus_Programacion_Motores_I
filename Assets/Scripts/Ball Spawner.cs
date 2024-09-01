using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private PoolController poolController;

    private const float TIME_TO_SHOOT = 2.0f;
    
    private GameObject _ball;
    private Ball _ballScript;
    
    public void SpawnBall()
    {
        _ball = poolController.GetObjectFromPool(ObjectType.Ball);
        _ball.transform.position = spawnPoint.position;
        _ball.SetActive(true);
        _ballScript = _ball.GetComponent<Ball>();
        
        Invoke(nameof(ShootBall), TIME_TO_SHOOT);
    }

    public void ShootBall()
    {
        _ballScript.Initiate(spawnPoint);
    }
    
    
    
}
