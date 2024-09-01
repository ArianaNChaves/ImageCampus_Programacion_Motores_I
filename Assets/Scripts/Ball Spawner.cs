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
    

    public void SpawnBall()
    {
        _ball = poolController.GetObjectFromPool(ObjectType.Ball);
        _ball.SetActive(true);
        _ballScript = _ball.GetComponent<Ball>();
        ShootBall();
    }

    public void ShootBall()
    {
        _ballScript.Initiate(spawnPoint);
    }
    
    
    
}
