using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        Debug.Log("Obstacle Spawn");
    }

    public void StartDestroy(float delay)
    {
        Debug.Log($"Delay:  {delay}");

        Invoke(nameof(SelfDestroy), delay);
    }
    private void SelfDestroy()
    {
        ObstacleSpawn.OnObstacleDespawned?.Invoke();
        Destroy(gameObject, 0.1f);
    }
}
