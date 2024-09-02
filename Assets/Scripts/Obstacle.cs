using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public void StartDestroy(float delay)
    {
        Invoke(nameof(SelfDestroy), delay);
    }
    private void SelfDestroy()
    {
        ObstacleSpawn.OnObstacleDespawned?.Invoke();
    }
}
